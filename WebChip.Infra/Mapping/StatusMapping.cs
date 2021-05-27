using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WebChip.Domain.Entities;

namespace WebChip.Infra.Context
{
    internal class StatusMapping : IEntityTypeConfiguration<Status>
    {
        public void Configure(EntityTypeBuilder<Status> builder)
        {
            builder.ToTable("Status");
            builder.HasKey(x => x.IdStatus);

            builder.Property(x => x.DescricaoStatus)
                .HasColumnType("varchar(30)")
                .IsRequired();

            builder.Property(x => x.Finaliza)
                .HasColumnType("varchar(3)");

            builder.Property(x => x.ContabilizaVenda)
                .HasColumnType("varchar(3)");

            builder.Property(x => x.StatusCliente)
                .HasColumnType("varchar(12)");

            builder.Property(X => X.StatusCliente)
                .HasColumnType("bit");

            builder.HasOne(x => x.Cliente)
                    .WithOne(x => x.Status)
                    .HasForeignKey<Cliente>(x => x.StatusId);
        }
    }
}