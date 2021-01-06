using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using Newtonsoft.Json;

namespace Api.Provagas
{
    public class Startup
    {

        public void ConfigureServices(IServiceCollection services)
        {

            services.AddControllers().AddNewtonsoftJson(options =>
            {
                options.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
                options.SerializerSettings.NullValueHandling = NullValueHandling.Ignore;
            });

            services
           // Define a forma de autenticação
           .AddAuthentication(options =>
           {
               options.DefaultAuthenticateScheme = "JwtBearer";
               options.DefaultChallengeScheme = "JwtBearer";
           })

           // Define os parâmetros de validação do token
           .AddJwtBearer("JwtBearer", options =>
           {
               options.RequireHttpsMetadata = false;

               options.SaveToken = true;

               options.TokenValidationParameters = new TokenValidationParameters

               {
                       // Quem está solicitando
                       ValidateIssuer = true,

                       // Quem está validando
                       ValidateAudience = true,

                       // Definindo o tempo de expiração
                       ValidateLifetime = true,

                       // Forma de criptografia
                       IssuerSigningKey = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes("provagas-chave-autenticacao")),

                       // Tempo de expiração do token
                       ClockSkew = TimeSpan.FromMinutes(30),

                       // Nome da issuer, de onde está vindo
                       ValidIssuer = "Api.Provagas",

                       // Nome da audience, de onde está vindo
                       ValidAudience = "Api.Provagas"
               };

           });

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "ProVagas", Version = "v1" });

                var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                c.IncludeXmlComments(xmlPath);
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseCors(options => options.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod());

            app.UseAuthentication();

            app.UseRouting();

            app.UseAuthorization();

            app.UseSwagger();

            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "ProVagas");
                c.RoutePrefix = string.Empty;
            });

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
