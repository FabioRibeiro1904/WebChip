using WebChip.Domain.Entities;

namespace WebChip.Domain.Repository
{
    public interface IRepositoryProduto
    {
        Produtos GetProduto(int id);
    }
}
