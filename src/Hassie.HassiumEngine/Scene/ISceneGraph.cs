using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hassie.HassiumEngine.System;

namespace Hassie.HassiumEngine.Scene
{
    /// <summary>
    /// A scene graph holds references to all entities currently in the scene.
    /// </summary>
    public interface ISceneGraph
    {
        /// <summary>
        /// Adds an entity to the scene.
        /// </summary>
        /// <param name="entity">The entity to add.</param>
        /// <returns>True if the entity was successfully added to the scene, false otherwise.</returns>
        bool AddEntity(IEntity entity);

        /// <summary>
        /// Checks if the scene contains the entity.
        /// </summary>
        /// <param name="id">The ID of the entity.</param>
        /// <returns>True if the entity is in the scene, false otherwise.</returns>
        bool ContainsEntity(int id);

        /// <summary>
        /// Gets an entity currently in the scene.
        /// </summary>
        /// <param name="id">The ID of the entity.</param>
        /// <returns>The entity.</returns>
        IEntity GetEntity(int id);

        /// <summary>
        /// Gets a list of entities in the scene.
        /// </summary>
        /// <returns>A list of entities in the scene.</returns>
        IReadOnlyList<IEntity> GetEntities();

        /// <summary>
        /// Removes an entity from the scene.
        /// </summary>
        /// <param name="id">The ID of the entity.</param>
        /// <returns>True if the entity was successfully removed from the scene, false otherwise.</returns>
        bool RemoveEntity(int id);
    }
}
