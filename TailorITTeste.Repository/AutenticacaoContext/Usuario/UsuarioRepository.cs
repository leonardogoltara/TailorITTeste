using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TailorITTeste.Domain.AutenticacaoContext.Usuario;

namespace TailorITTeste.Repository.AutenticacaoContext.Usuario
{
    public class UsuarioRepository : IUsuarioRepository
    {
        public void Delete(int id)
        {
            using (var ctx = new Context())
            {
                var Usuario = ctx.Usuarios.Find(id);
                if (Usuario != null)
                {
                    ctx.Usuarios.Remove(Usuario);
                    ctx.SaveChanges();
                }
            }
        }

        public UsuarioModel Find(int id)
        {
            using (var ctx = new Context())
            {
                var Usuario = ctx.Usuarios.Find(id);
                return Usuario;
            }
        }

        public IEnumerable<UsuarioModel> List(string nome, bool? ativo)
        {
            using (var ctx = new Context())
            {
                return ctx.Usuarios
                    .Include("Sexo")
                    .Where(u => (ativo == null || u.Ativo == ativo) && (string.IsNullOrEmpty(nome) || u.Nome.ToLower().Contains(nome.ToLower()))).ToList();
            }
        }

        public void Save(UsuarioModel usuario)
        {
            using (var ctx = new Context())
            {
                var usuarioOld = ctx.Usuarios.Find(usuario.UsuarioId);
                if (usuarioOld != null)
                {
                    usuarioOld.Atualizar(usuario.Nome, usuario.DataNascimento, usuario.Email, usuario.Senha, usuario.SexoId);

                    if (usuario.Ativo)
                        usuarioOld.Ativar();
                    else
                        usuarioOld.Desativar();

                    ctx.SaveChanges();
                } else
                {
                    ctx.Usuarios.Add(usuario);
                    ctx.SaveChanges();
                }
            }
        }
    }
}
