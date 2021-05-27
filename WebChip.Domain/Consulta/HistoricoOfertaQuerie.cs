using System;
using System.Linq.Expressions;
using WebChip.Domain.Entities;

namespace WebChip.Domain.Consulta
{
    public class HistoricoOfertaQuerie
    {
        public static Expression<Func<HistoricoOferta, bool>> HistoricoOferta(int id)
        {
            return x => x.IdHistoricoOferta == id;
        }
    }
}
