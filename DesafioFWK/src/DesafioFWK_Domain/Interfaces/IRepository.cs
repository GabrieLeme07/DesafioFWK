using System;

namespace DesafioFWK_Domain.Interfaces
{
    public interface IRepository : IDisposable
    {
        IUnitOfWork UnitOfWork { get; }
    }
}
