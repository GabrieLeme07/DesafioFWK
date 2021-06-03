using System.Threading.Tasks;

namespace DesafioFWK_Domain.Interfaces
{
    public interface IUnitOfWork
    {
        Task<bool> Commit();
    }
}
