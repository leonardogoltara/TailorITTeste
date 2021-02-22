using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Infrastructure.Annotations;
using System.Data.Entity.ModelConfiguration.Configuration;

namespace TailorITTeste.Repository
{
    internal static class MappingExtensions
    {
        public static PrimitivePropertyConfiguration IsUnique(this PrimitivePropertyConfiguration configuration,
            string name,
            int order)
        {
            return configuration.IsRequired()
                .HasColumnAnnotation("Index",
                    new IndexAnnotation(
                        new IndexAttribute(name, order) { IsUnique = true }));
        }
    }
}
