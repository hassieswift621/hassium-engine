using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hassie.HassiumEngine.System;
using Microsoft.Xna.Framework;

namespace Hassie.HassiumEngine.Scene
{
    /// <summary>
    /// Implementation of the scene graph which uses a map (dictionary) as the data structure.
    /// </summary>
    public class MapSceneGraph : ISceneGraph
    {
        // Map to hold the entities.
        private readonly IDictionary<int, IEntity> entities;

        /// <summary>
        /// Constructor for the scene graph.
        /// </summary>
        public MapSceneGraph()
        {
            // Initialise entities map.
            entities = new Dictionary<int, IEntity>();
        }

        /// <summary>
        /// Adds an entity to the scene.
        /// </summary>
        /// <param name="entity">The entity to add.</param>
        public bool AddEntity(IEntity entity)
        {
            // Add entity to entities map.
            entities.Add(entity.Id, entity);

            return true;
        }

        /// <summary>
        /// Checks if the scene contains the entity.
        /// </summary>
        /// <param name="id">The ID of the entity.</param>
        /// <returns>True if the entity is in the scene, false otherwise.</returns>
        public bool ContainsEntity(int id)
        {
            // Return whether the map contains the entity.
            return entities.ContainsKey(id);
        }

        /// <summary>
        /// Gets an entity currently in the scene.
        /// </summary>
        /// <param name="id">The ID of the entity.</param>
        /// <returns>The entity.</returns>
        public IEntity GetEntity(int id)
        {
            return entities[id];
        }

        /// <summary>
        /// Gets a list of entities in the scene.
        /// </summary>
        /// <returns>A list of entities in the scene.</returns>
        public IReadOnlyList<IEntity> GetEntities()
        {
            return entities.Values.ToList();
        }

        /// <summary>
        /// Removes an entity from the scene.
        /// </summary>
        /// <param name="id">The ID of the entity.</param>
        /// <returns>True if the entity was successfully removed from the scene, false otherwise.</returns>
        public bool RemoveEntity(int id)
        {
            // Try and remove entity from the scene.
            return entities.Remove(id);
        }
    }
}
