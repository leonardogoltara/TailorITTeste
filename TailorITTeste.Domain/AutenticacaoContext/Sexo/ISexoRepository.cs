using System.Collections.Generic;

namespace TailorITTeste.Domain.AutenticacaoContext.Sexo
{
    public interface ISexoRepository
    {
        SexoModel Find(int id);
        void Save(SexoModel usuario);
        void Delete(int id);
        IEnumerable<SexoModel> List();
    }
}
