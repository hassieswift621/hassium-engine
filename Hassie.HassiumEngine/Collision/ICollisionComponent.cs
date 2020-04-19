using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hassie.HassiumEngine.Update;
using Hassie.HassiumEngine.System;

namespace Hassie.HassiumEngine.Collision
{
    /// <summary>
    /// An interface for a collision component.
    /// The interface allows entities to be added and removed from a collision component, as well 
    /// as updating it.
    /// </summary>
    public interface ICollisionComponent : IUpdatable
    {
        /// <summary>
        /// Adds an entity to the collision component.
        /// </summary>
        /// <param name="entity">The entity to add.</param>
        void AddEntity(IEntity entity);

        /// <summary>
        /// Removes an entity from the collision component.
        /// </summary>
        /// <param name="id">The ID of the entity.</param>
        void RemoveEntity(int id);
    }
}
