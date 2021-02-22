using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TailorITTeste.Domain.AutenticacaoContext.Sexo;

namespace TailorITTeste.Repository.AutenticacaoContext.Sexo
{
    public class SexoMap : EntityTypeConfiguration<SexoModel>
    {
        public SexoMap()
        {
            ToTable("Sexo", "Autenticacao");
            HasKey(s => s.SexoId);
            Property(u => u.SexoId).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(u => u.Descricao).HasMaxLength(15);
        }
    }
}
