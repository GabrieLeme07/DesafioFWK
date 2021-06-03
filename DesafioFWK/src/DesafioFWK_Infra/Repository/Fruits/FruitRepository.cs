using DesafioFWK_Domain.Interfaces;
using DesafioFWK_Domain.Model;
using DesafioFWK_Infra.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DesafioFWK_Infra.Repository.Fruits
{
    public class FruitRepository : BaseRepository, IFruitRepository
    {
        public FruitRepository(MeuDataContext context)
            : base(context)
        {
        }

        public async Task Add(Fruit fruit)
            => await base.AddAsync<Fruit>(fruit);

        public Task<Fruit> GetById(Guid id)
            => Db.Fruits.Where(e => e.Id == id).FirstOrDefaultAsync();

        public void Update(Fruit fruit)
            => base.Update<Fruit>(fruit);

        public Task<List<Fruit>> GetAll()
            => Db.Fruits.ToListAsync();

        public async Task<EntityEntry> Delete(Guid id)
        {
            var instance = await Db.Fruits.FirstOrDefaultAsync(e => e.Id == id);
            var result = Db.Fruits.Remove(instance);
            return result;
        }
    }
}
