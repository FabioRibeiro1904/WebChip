using System;
using System.Linq.Expressions;
using WebChip.Domain.Entities;

namespace WebChip.Domain.Consulta
{
    public class ClienteStatusQueries
    {
        public static Expression<Func<Cliente, bool>> CpfDisponivel(string cpf)
        {
            return x => x.Cpf == cpf && x.Status.Finaliza == "Nao";
        }

        public static Expression<Func<Cliente, bool>> NomeDisponivel(string firstName)
        {

            return x => x.Nome.StartsWith(firstName) && x.Status.Finaliza == "Nao";
            //return x => x.Nome.StartsWith(firstName) && x.Nome.EndsWith(lastName)
        }
    }
}
