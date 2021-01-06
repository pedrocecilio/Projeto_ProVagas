using Microsoft.EntityFrameworkCore;
using Api.Provagas.Contexts;
using Api.Provagas.Domains;
using Api.Provagas.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api.Provagas.Repositories
{
    public class UsuarioRepository : RepositoryBase<Usuario>, IUsuarioRepository
    {
        ProVagasContext ctx = new ProVagasContext();
       


        public Usuario Login(string email, string senha)
        {
            // Busca o primeiro usuário encontrado para o e-mail e a senha informados e armazena no objeto usuarioBuscado
            Usuario usuarioBuscado = ctx.Usuarios
                // Busca as informações referentes ao tipo de usuário
                .Include(u => u.IdTipoUsuarioNavigation)
                .FirstOrDefault(u => u.Email == email && u.Senha == senha);

            // Verifica se o usuário foi encontrado
            if (usuarioBuscado != null)
            {
                // Retorna o usuário encontrado
                return usuarioBuscado;
            }

            // Caso não seja encontrado, retorna nulo
            return null;
        }

        public int CadastrarUsuario(Usuario usuario)
        {
            ctx.Usuarios.Add(usuario);
            ctx.SaveChanges();

            return usuario.IdUsuario;
        }

        public Object VerificarTipoUsuario(string email, string senha)
        {
            Usuario usuarioBuscado = ctx.Usuarios.FirstOrDefault(u => u.Email == email && u.Senha == senha);
            IEnumerable<Administrador> administradores = ctx.Administrador.Include(a => a.IdUsuarioNavigation).ToList();
            IEnumerable<Candidato> candidatos = ctx.Candidato.Include(a => a.IdEnderecoNavigation.IdUsuarioNavigation).ToList();
            IEnumerable<Empresa> empresas = ctx.Empresa.Include(a => a.IdEnderecoNavigation.IdUsuarioNavigation).ToList();

            if (usuarioBuscado != null)
            {
                foreach (var tipoUsuario in administradores)
                {
                    if (usuarioBuscado.Email == tipoUsuario.IdUsuarioNavigation.Email &&
                        usuarioBuscado.Senha == tipoUsuario.IdUsuarioNavigation.Senha)
                    {
                        return tipoUsuario;
                    }
                }

                foreach (var tipoUsuario in candidatos)
                {
                    if (usuarioBuscado.Email == tipoUsuario.IdEnderecoNavigation.IdUsuarioNavigation.Email &&
                        usuarioBuscado.Senha == tipoUsuario.IdEnderecoNavigation.IdUsuarioNavigation.Senha)
                    {
                        return tipoUsuario;
                    }
                }

                foreach (var tipoUsuario in empresas)
                {
                    if (usuarioBuscado.Email == tipoUsuario.IdEnderecoNavigation.IdUsuarioNavigation.Email &&
                        usuarioBuscado.Senha == tipoUsuario.IdEnderecoNavigation.IdUsuarioNavigation.Senha)
                    {
                        return tipoUsuario;
                    }
                }
            }

            return null;
        }

  
    }
}
