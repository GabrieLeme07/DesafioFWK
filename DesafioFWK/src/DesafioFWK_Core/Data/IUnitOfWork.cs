using System.Threading.Tasks;

namespace DesafioFWK_Core.Data
{
    public interface IUnitOfWork
    {
        Task<bool> Commit();
    }
}
