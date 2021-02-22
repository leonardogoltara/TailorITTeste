using System.Collections.Generic;

namespace TailorITTeste.Domain.AutenticacaoContext.Usuario
{
    public interface IUsuarioRepository
    {
        UsuarioModel Find(int id);
        void Save(UsuarioModel usuario);
        void Delete(int id);
        IEnumerable<UsuarioModel> List(string nome, bool? ativo);
    }
}
