using Microsoft.EntityFrameworkCore;
using WebChip.Infra.Mapping;
using WebChip.Domain.Entities;

namespace WebChip.Infra.Context
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }
        public DbSet<Endereco> Enderecos { get; set; }

        public DbSet<Status> Status { get; set; }

        public DbSet<Produtos> Produtos { get; set; }

        public DbSet<Cliente> Cliente { get; set; }


        public DbSet<HistoricoOferta> HistoricoOferta { get; private set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ClienteMapping());
            modelBuilder.ApplyConfiguration(new EnderecoMapping());
            modelBuilder.ApplyConfiguration(new StatusMapping());
            modelBuilder.ApplyConfiguration(new ProdutosMapping());

        }
    }
}
