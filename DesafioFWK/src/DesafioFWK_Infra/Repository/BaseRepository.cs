
using DesafioFWK_Core.Interfaces;
using DesafioFWK_Domain.Interfaces;
using DesafioFWK_Infra.Context;
using System;
using System.Threading.Tasks;

namespace DesafioFWK_Infra.Repository
{
    public abstract class BaseRepository : IDisposable
    {
        #region :: Constructors

        public BaseRepository(MeuDataContext context)
            => Db = context;

        #endregion

        #region :: Properties

        /// <summary>
        /// Project Data context
        /// </summary>
        protected readonly MeuDataContext Db;

        /// <summary>
        /// Unit Of Work
        /// </summary>
        public IUnitOfWork UnitOfWork => Db;

        #endregion

        #region :: Protected Methods

        /// <summary>
        /// Adds a new entity to a database
        /// </summary>
        protected virtual void Add<TEntity>(IEntity entity) where TEntity : IEntity
             => Db.Add((TEntity)entity);


        /// <summary>
        /// Adds a new entity to a database
        /// </summary>
        protected async virtual Task AddAsync<TEntity>(IEntity entity) where TEntity : IEntity
           => await Db.AddAsync((TEntity)entity);
        

        /// <summary>
        /// Update a entity in database
        /// </summary>
        protected virtual void Update<TEntity>(IEntity entity) where TEntity : IEntity
            => Db.Update((TEntity)entity);

        #endregion

        #region :: Public Methods

        public virtual void Dispose()
            => Db.Dispose();

        #endregion
    }
}
