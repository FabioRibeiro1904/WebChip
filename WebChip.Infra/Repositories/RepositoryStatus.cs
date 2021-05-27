using Microsoft.EntityFrameworkCore;
using System.Linq;
using WebChip.Infra.Context;
using WebChip.Domain.Entities;
using WebChip.Domain.Repository;

namespace WebChip.Infra.Repositories
{
    public class RepositoryStatus : IRepositoryStatus
    {
        private DataContext _context;
            public RepositoryStatus(DataContext context)
        {
            _context = context;
        }
        public Status GetStatus(int id)
        {
            return _context.Status.AsNoTracking().FirstOrDefault(x => x.IdStatus == id);
        }
    }
}
