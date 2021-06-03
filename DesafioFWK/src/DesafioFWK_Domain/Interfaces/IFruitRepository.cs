using DesafioFWK_Domain.Model;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DesafioFWK_Domain.Interfaces
{
    public interface IFruitRepository : IRepository
    {
        Task Add(Fruit fruit);

        Task<Fruit> GetById(Guid id);

        void Update(Fruit fruit);

        Task<List<Fruit>> GetAll();

        Task<EntityEntry> Delete(Guid id);
    }
}
