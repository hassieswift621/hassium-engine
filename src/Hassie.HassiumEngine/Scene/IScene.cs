using Hassie.HassiumEngine.System;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hassie.HassiumEngine.Scene
{
    /// <summary>
    /// An interface for a scene, allowing entities to be added and removed to/from the scene.
    /// </summary>
    public interface IScene
    {
        /// <summary>
        /// Adds an entity to the scene.
        /// </summary>
        /// <param name="entity">The entity to add.</param>
        void AddEntity(IEntity entity);

        /// <summary>
        /// Gets the entities in the scene.
        /// </summary>
        /// <returns>A list of entities in the scene.</returns>
        IReadOnlyList<IEntity> GetEntities();

        /// <summary>
        /// Removes an entity from the scene.
        /// </summary>
        /// <param name="id">The ID of the entity.</param>
        void RemoveEntity(int id);
    }
}
