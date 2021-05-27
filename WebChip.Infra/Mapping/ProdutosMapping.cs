using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WebChip.Domain.Entities;

namespace WebChip.Infra.Context
{
    public class ProdutosMapping : IEntityTypeConfiguration<Produtos>
    {
        public void Configure(EntityTypeBuilder<Produtos> builder)
        {
            builder.ToTable("Produto");
            builder.HasKey(x => x.IdProduto);
            builder.Property(x => x.DescricaoProduto)
                .HasColumnType("varchar(15)");
            builder.Property(x => x.Preco)
                    .HasColumnType("money");

            builder.Property(x => x.Tipo)
                .HasColumnType("varchar(8)");

            builder.Property(x => x.CodigoProduto)
                   .IsRequired();

            builder.HasOne(x => x.HistoricoOferta)
                .WithOne(x => x.Produtos)
                .HasForeignKey<HistoricoOferta>(x => x.ProdutoId);
        }
    }
}