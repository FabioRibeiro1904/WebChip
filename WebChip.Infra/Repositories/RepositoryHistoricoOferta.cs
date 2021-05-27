using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using WebChip.Infra.Context;
using WebChip.Domain.Entities;
using WebChip.Domain.Repository;
using WebChip.Domain.Consulta;
using System.Linq;

namespace WebChip.Infra.Repositories
{
    public class RepositoryHistoricoOferta : IRepositoryHistoricoOferta
    {
        private DataContext _context;
        public RepositoryHistoricoOferta(DataContext context)
        {
            _context = context;
        }
        public void Create(HistoricoOferta historico)
        {
             _context.HistoricoOferta.Add(historico);
            _context.SaveChanges();
        }

        public IEnumerable<HistoricoOferta> GetList(int id)
        {
            return _context.HistoricoOferta.Where(HistoricoOfertaQuerie.HistoricoOferta(id)).ToList();
        }
    }
}
