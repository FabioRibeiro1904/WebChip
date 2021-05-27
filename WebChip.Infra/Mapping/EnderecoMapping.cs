using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WebChip.Domain.Entities;

namespace WebChip.Infra.Context
{
    public class EnderecoMapping : IEntityTypeConfiguration<Endereco>
    {
        public void Configure(EntityTypeBuilder<Endereco> builder)
        {
            builder.ToTable("Endereco");

            builder.HasKey(x => x.IdEndereco);

            builder.Property(x => x.Cep)
            .HasColumnType("varchar(8)");

            builder.Property(x => x.Rua)
            .HasColumnType("varchar(30)");

            builder.Property(x => x.Numero)
            .IsRequired();

            builder.Property(x => x.Complemento)
            .HasColumnType("varchar(30)")
            .IsRequired();

            builder.Property(x => x.Bairro)
                .HasColumnType("varchar(20)")
                .IsRequired();
            
            builder.Property(x => x.Cidade)
                .HasColumnType("varchar(20)")
               .IsRequired();

            builder.Property(X => X.Estado)
                .HasColumnType("varchar(2)")
                .IsRequired();



        }
    }
}
