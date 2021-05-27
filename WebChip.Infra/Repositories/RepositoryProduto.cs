

using Microsoft.EntityFrameworkCore;
using System.Linq;
using WebChip.Infra.Context;
using WebChip.Domain.Repository;
using WebChip.Domain.Entities;

namespace WebChip.Infra.Repositories
{
    public class RepositoryProduto : IRepositoryProduto
    {
        private DataContext _context;
        public RepositoryProduto(DataContext context)
        {
            _context = context;
        }

        public Produtos GetProduto(int id)
        {
            return _context.Produtos.AsNoTracking().FirstOrDefault(x => x.IdProduto == id); 
        }
    }
}
