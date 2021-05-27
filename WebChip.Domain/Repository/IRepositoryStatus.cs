using WebChip.Domain.Entities;

namespace WebChip.Domain.Repository
{
    public interface IRepositoryStatus
    {
        Status GetStatus(int id);
    }
}
