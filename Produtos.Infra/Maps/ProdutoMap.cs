using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Produtos.Domain.ProdutoAggregate;

namespace Produtos.Infra.Maps
{
    public class ProdutoMap : IEntityTypeConfiguration<Produto>
    {
        public void Configure(EntityTypeBuilder<Produto> builder)
        {
            builder
                .HasKey(x => x.Id);

            builder
                .Property(x => x.Codigo)
                .IsRequired()
                .IsUnicode();

            builder
                .Property(x => x.Valor)
                .HasColumnType("Decimal")
                .HasPrecision(18,2);
        }
    }
}
