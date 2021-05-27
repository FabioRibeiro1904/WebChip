using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WebChip.Domain.Entities;

namespace WebChip.Infra.Mapping
{
    public class ClienteMapping : IEntityTypeConfiguration<Cliente>
    {
        public void Configure(EntityTypeBuilder<Cliente> builder)
        {
            builder.ToTable("Cliente");

            builder.HasKey(x => x.IdCliente);
            builder.Property(x => x.Nome)
                .HasColumnType("varchar(60)")
                .IsRequired();

            builder.Property(x => x.Cpf)
                .HasColumnType("varchar(11)");

            builder.Property(x => x.Credito)
                .HasColumnType("decimal")
                .HasPrecision(18,2);

            builder.Property(x => x.Telefone)
                .HasColumnType("varchar(11)");

            builder.HasOne(x => x.Status)
                .WithOne(x => x.Cliente)
                .HasForeignKey<Cliente>(x => x.StatusId);

            builder.HasOne(x => x.Endereco)
                .WithOne(x => x.Cliente)
                .HasForeignKey<Cliente>(x => x.EnderecoId);
            
            


        }
    }
}
