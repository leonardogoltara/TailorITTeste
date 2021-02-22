using System;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Data.Entity.Validation;
using TailorITTeste.Domain.AutenticacaoContext.Sexo;
using TailorITTeste.Domain.AutenticacaoContext.Usuario;
using TailorITTeste.Repository.AutenticacaoContext.Sexo;
using TailorITTeste.Repository.AutenticacaoContext.Usuario;

namespace TailorITTeste.Repository
{
    public class Context : DbContext
    {
        public Context() : base("DefaultConnection")
        {
            Configuration.LazyLoadingEnabled = true;
            Configuration.ProxyCreationEnabled = false;
        }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //Aqui vamos remover a pluralização padrão do Etity Framework que é em inglês
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();

            /*Desabilitamos o delete em cascata em relacionamentos 1:N evitando
             ter registros filhos     sem registros pai*/
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();

            //Basicamente a mesma configuração, porém em relacionamenos N:N
            modelBuilder.Conventions.Remove<ManyToManyCascadeDeleteConvention>();

            /*Toda propriedade do tipo string na entidade POCO
             seja configurado como VARCHAR no SQL Server*/
            modelBuilder.Properties<string>()
                      .Configure(p => p.HasColumnType("varchar"));

            modelBuilder.Configurations.Add(new SexoMap());
            modelBuilder.Configurations.Add(new UsuarioMap());
            
        }
        private void FixEfProviderServicesProblem()
        {
            // The Entity Framework provider type 'System.Data.Entity.SqlServer.SqlProviderServices, EntityFramework.SqlServer'
            // for the 'System.Data.SqlClient' ADO.NET provider could not be loaded. 
            // Make sure the provider assembly is available to the running application. 
            // See http://go.microsoft.com/fwlink/?LinkId=260882 for more information.
            var instance = System.Data.Entity.SqlServer.SqlProviderServices.Instance;
        }
        public override int SaveChanges()
        {
            try
            {
                return base.SaveChanges();
            }
            catch (DbEntityValidationException dbEx)
            {
                string message = "";
                foreach (var validationErrors in dbEx.EntityValidationErrors)
                {
                    foreach (var validationError in validationErrors.ValidationErrors)
                    {
                        message += $"Class: {validationErrors.Entry.Entity.GetType().Name}" +
                            $" Property: {validationError.PropertyName}" +
                            $" Error: {validationError.ErrorMessage}" +
                            Environment.NewLine;
                    }
                }
                throw new DbEntityValidationException(message, dbEx);
            }
            catch (Exception)
            {
                throw;  // You can also choose to handle the exception here...
            }
        }
        public DbSet<UsuarioModel> Usuarios { get; set; }
        public DbSet<SexoModel> Sexo { get; set; }
    }
}
