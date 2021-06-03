using DesafioFWK_Domain.Interfaces;
using DesafioFWK_Infra.Context;
using System.Threading.Tasks;

namespace DesafioFWK_Infra.Configuration
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly MeuDataContext _context;

        public UnitOfWork(MeuDataContext context)
            => _context = context;

        public async Task<bool> Commit()
            => await _context.SaveChangesAsync() > 0;

        public void Dispose()
            => _context.Dispose();
    }
}
