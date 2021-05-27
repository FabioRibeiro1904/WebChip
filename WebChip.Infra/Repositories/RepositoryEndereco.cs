

using Microsoft.EntityFrameworkCore;
using System.Linq;
using WebChip.Infra.Context;
using WebChip.Domain.Repository;
using WebChip.Domain.Entities;

namespace WebChip.Infra.Repositories
{
    public class RepositoryEndereco : IRepositoryEndereco
    {
        private readonly DataContext _context;

        public RepositoryEndereco(DataContext context)
        {
            _context = context;
        }
        public void AtualizarEndereco(Endereco endereco)
        {
            _context.Entry(endereco).State = EntityState.Modified;
            _context.SaveChanges();
        }

        public void Create(Endereco client)
        {
            _context.Enderecos.Add(client);
            _context.SaveChanges();
        }

        public Endereco GetIdEndereco(int id)
        {
            return _context.Enderecos.AsNoTracking().FirstOrDefault(x => x.IdEndereco == id);
        }
    }
}
