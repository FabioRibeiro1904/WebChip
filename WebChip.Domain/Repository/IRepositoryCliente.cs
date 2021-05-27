using System.Collections.Generic;
using WebChip.Domain.Entities;

namespace WebChip.Domain.Repository
{
    public interface IRepositoryCliente
    {
        void Create(Cliente client);

        Cliente GetId(int id);

        void AtualizaClienteDados(Cliente cliente);

        Cliente GetCpf(string cpf);

        IEnumerable<Cliente> ListCpf(string cpf, string nome);
    }
}
