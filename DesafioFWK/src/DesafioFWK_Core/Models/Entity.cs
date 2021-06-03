using DesafioFWK_Core.Interfaces;
using System;

namespace DesafioFWK_Core.Models
{
    public abstract class Entity<TId> : IEntity
    {
        public TId Id { get; set; }

        /// <summary>
        /// Returns de raw object class id
        /// </summary>
        public object GetId() => Id;
    }

    ///<summary>
    /// Default base class for all system entities
    ///</summary>
    public abstract class Entity : Entity<Guid>
    {
        public Entity()
        {
            Id = Guid.NewGuid();
        }
    }
}
