using Hassie.HassiumEngine.System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hassie.HassiumEngine.Entity
{
    /// <summary>
    /// An interface for an entity provider.
    /// An entity provider allows entities to be requested.
    /// </summary>
    public interface IEntityProvider
    {
        /// <summary>
        /// Requests an entity from the entity manager.
        /// </summary>
        /// <typeparam name="T">The entity type.</typeparam>
        /// <param name="position">The starting position of the entity.</param>
        /// <returns>A reference to the entity.</returns>
        IEntity RequestEntity<T>(Vector3 position) where T : AbstractEntity, new();
    }
}