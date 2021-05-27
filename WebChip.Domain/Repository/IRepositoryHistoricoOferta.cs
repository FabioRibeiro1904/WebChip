using System.Collections.Generic;
using WebChip.Domain.Entities;

namespace WebChip.Domain.Repository
{
    public interface IRepositoryHistoricoOferta
    {
        void Create(HistoricoOferta historico);

        IEnumerable<HistoricoOferta> GetList(int id);
    }
}
