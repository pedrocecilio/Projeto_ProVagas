using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using Api.Provagas.ViewModels;
using Api.Provagas.Domains;
using Api.Provagas.Interfaces;
using Api.Provagas.Repositories;
using System;

namespace Api.Provagas.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private ICandidatoRepository _candidatoRepository { get; set; }
        private IEmpresaRepository _empresaRepository { get; set; }
        private IAdministradorRepository _administradorRepository { get; set; }

        private IUsuarioRepository _usuarioRepository { get; set; }

        public LoginController()
        {
            _candidatoRepository = new CandidatoRepository();

            _empresaRepository = new EmpresaRepository();

            _administradorRepository = new AdministradorRepository();

            _usuarioRepository = new UsuarioRepository();

        }

        /// <summary>
        /// Realizar login
        /// </summary>
        /// <param name="login"></param>
        /// <returns>Retorna o token do login</returns>
        [HttpPost]
        public IActionResult Post(LoginViewModels login)
        {
            try
            {
                var usuarioGenerico = _usuarioRepository.VerificarTipoUsuario(login.Email, login.Senha);

                string tipoRole;
                if (usuarioGenerico != null)
                {
                    if (usuarioGenerico is Administrador)
                    {
                        tipoRole = "Administrador";
                        Administrador administradorBuscado = _administradorRepository.Login(login.Email, login.Senha);

                        return Ok(CriacaoToken(administradorBuscado.IdUsuarioNavigation.Email, administradorBuscado.IdAdministrador, tipoRole));
                    }
                    if (usuarioGenerico is Candidato)
                    {
                        tipoRole = "Candidato";
                        Candidato alunoBuscado = _candidatoRepository.Login(login.Email, login.Senha);

                        return Ok(CriacaoToken(alunoBuscado.IdEnderecoNavigation.IdUsuarioNavigation.Email, alunoBuscado.IdCandidato, tipoRole));
                    }
                    if (usuarioGenerico is Empresa)
                    {
                        tipoRole = "Empresa";
                        Empresa empresaBuscado = _empresaRepository.Login(login.Email, login.Senha);

                        return Ok(CriacaoToken(empresaBuscado.IdEnderecoNavigation.IdUsuarioNavigation.Email, empresaBuscado.IdEmpresa, tipoRole));
                    }
                    else
                    {
                        return NotFound("Email ou senha inválidos");
                    }
                }
                else
                {
                    return NotFound("Usuário Informado não existe");
                }
            }
            catch (Exception error)
            {
                return BadRequest(error);
            }

        }

        [NonAction]
        private IActionResult CriacaoToken(string email, int rawId, string tipoRole)
        {
            var id = Convert.ToInt32(rawId);
            try
            {
                var claims = new[]
                {
                    // Armazena na Claim o e-mail do usuário autenticado
                    new Claim(JwtRegisteredClaimNames.Email, email),

                    // Armazena na Claim o ID do usuário autenticado
                    new Claim(JwtRegisteredClaimNames.Jti, id.ToString()),

                    // Armazena na Claim o tipo de usuário que foi autenticado (Administrador ou Comum)
                    new Claim(ClaimTypes.Role, tipoRole),

                    new Claim("Role", tipoRole),

                    new Claim("Id", id.ToString())

                };

                // Define a chave de acesso ao token
                var key = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes("Provagas-chave-autenticacao"));

                // Define as credenciais do token - Header
                var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

                // Gera o token
                var token = new JwtSecurityToken(
                    issuer: "Api.Provagas",                 // emissor do token
                    audience: "Api.Provagas",               // destinatário do token
                    claims: claims,                        // dados definidos acima
                    expires: DateTime.Now.AddMinutes(30),  // tempo de expiração
                    signingCredentials: creds              // credenciais do token
                );

                // Retorna Ok com o token
                return Ok(new
                {
                    token = new JwtSecurityTokenHandler().WriteToken(token),
                    id = rawId
                }); ;
            }
            catch (Exception error)
            {
                return BadRequest(new
                {
                    mensagem = "Não foi possível gerar o token",
                    error
                });
            }
        }
    }
}
