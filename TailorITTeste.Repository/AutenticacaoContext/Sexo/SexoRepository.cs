using System.Collections.Generic;
using System.Linq;
using TailorITTeste.Domain.AutenticacaoContext.Sexo;

namespace TailorITTeste.Repository.AutenticacaoContext.Sexo
{
    public class SexoRepository : ISexoRepository
    {
        public void Delete(int id)
        {
            using (var ctx = new Context())
            {
                var sexo = ctx.Sexo.Find(id);
                if (sexo != null)
                {
                    ctx.Sexo.Remove(sexo);
                    ctx.SaveChanges();
                }
            }
        }

        public SexoModel Find(int id)
        {
            using (var ctx = new Context())
            {
                var sexo = ctx.Sexo.Find(id);
                return sexo;
            }
        }

        public IEnumerable<SexoModel> List()
        {
            using (var ctx = new Context())
            {
                return ctx.Sexo.ToList();
            }
        }

        public void Save(SexoModel sexo)
        {
            using (var ctx = new Context())
            {
                var sexoOld = ctx.Sexo.Find(sexo.SexoId);
                if (sexo != null)
                {
                    sexoOld.Atualizar(sexo.Descricao);
                    ctx.SaveChanges();
                }
            }
        }
    }
}
