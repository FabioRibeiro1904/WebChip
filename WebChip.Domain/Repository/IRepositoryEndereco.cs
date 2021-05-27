using WebChip.Domain.Entities;

namespace WebChip.Domain.Repository
{
    public interface IRepositoryEndereco
    {
        void Create(Endereco client);

        Endereco GetIdEndereco(int id);

        void AtualizarEndereco(Endereco Endereco);
    }
}
