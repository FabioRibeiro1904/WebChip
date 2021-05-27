using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WebChip.Domain.Entities;

namespace WebChip.Infra.Mapping
{
    public class HistoricoOfertaMapping : IEntityTypeConfiguration<HistoricoOferta>
    {
        public void Configure(EntityTypeBuilder<HistoricoOferta> builder)
        {
            builder.HasKey(x => x.IdHistoricoOferta);

            builder.Property(x => x.DataOferta);

            builder.HasOne(x => x.Produtos)
                .WithOne(x => x.HistoricoOferta)
                .HasForeignKey<HistoricoOferta>(x => x.ProdutoId);

            builder.HasOne(x => x.Clientes)
            .WithOne(x => x.HistoricoOferta)
            .HasForeignKey<Cliente>(x => x.HistoricoOfertaId);
        }
    }
}
