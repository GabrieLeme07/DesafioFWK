using DesafioFWK_Domain.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DesafioFWK_Infra.EntityConfig.Fruits
{
    public class FruitConfig : IEntityTypeConfiguration<Fruit>
    {
        public void Configure(EntityTypeBuilder<Fruit> entity)
        {
            entity.HasKey(e => e.Id);

            entity.Property(e => e.Nome)
                .HasMaxLength(255);

            entity.Property(e => e.Descricao)
                .HasMaxLength(255);
        }
    }
}
