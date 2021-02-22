using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using TailorITTeste.Domain.AutenticacaoContext.Usuario;

namespace TailorITTeste.Repository.AutenticacaoContext.Usuario
{
    public class UsuarioMap : EntityTypeConfiguration<UsuarioModel>
    {
        public UsuarioMap()
        {
            ToTable("Usuario", "Autenticacao");
            HasKey(s => s.UsuarioId);
            Property(u => u.UsuarioId).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            Property(u => u.Nome).HasMaxLength(200);
            Property(u => u.Email).HasMaxLength(100);
            Property(u => u.Senha).HasMaxLength(30);

            HasRequired(x => x.Sexo)
                .WithMany()
                .HasForeignKey(x => x.SexoId);
        }
    }

}
