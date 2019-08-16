using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hassie.HassiumEngine.System
{
    /// <summary>
    /// An interface for an engine system.
    /// </summary>
    public interface ISystem
    {
        /// <summary>
        /// Adds an entity to the system.
        /// </summary>
        /// <param name="entity">The entity to add.</param>
        void AddEntity(IEntity entity);

        /// <summary>
        /// Removes an entity from the system.
        /// </summary>
        /// <param name="id">The ID of the entity.</param>
        void RemoveEntity(int id);

        /// <summary>
        /// Update method.
        /// </summary>
        /// <param name="gameTime">Snapshot of elapsed time values.</param>
        void Update(GameTime gameTime);
    }
}
