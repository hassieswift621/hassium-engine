using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hassie.HassiumEngine.Scene;
using Hassie.HassiumEngine.System;
using Hassie.HassiumEngine.Load;

namespace Hassie.HassiumEngine.Entity
{
    /// <summary>
    /// The entity manager.
    /// The entity manager allows entities to be requested.
    /// It makes use of object pooling to reuse entities.
    /// </summary>
    public class EntityManager : IEntityProvider, IEntityTerminator
    {
        private IDictionary<int, AbstractEntity> activeEntities; // Active entities.
        private IDictionary<Type, IList<AbstractEntity>> inactiveEntities; // Inactive entities.
        private int entitiesCreated; // The number of entities created, used to generate IDs.
        private readonly ISystem loadSystem; // The load system.
        private readonly ISceneManager sceneManager; // Reference to a scene manager.
        private readonly ISceneStateManager sceneStateManager; // Reference to a scene state manager.

        /// <summary>
        /// Constructor for the entity manager.
        /// </summary>
        /// <param name="loadSystem">The load system.</param>
        /// <param name="sceneManager">The reference to a scene manager.</param>
        /// <param name="sceneStateManager">The reference to a scene state manager.</param>
        public EntityManager(ISystem loadSystem, ISceneManager sceneManager, ISceneStateManager sceneStateManager)
        {
            // Initialise maps.
            activeEntities = new Dictionary<int, AbstractEntity>();
            inactiveEntities = new Dictionary<Type, IList<AbstractEntity>>();

            // Store managers and systems.
            this.loadSystem = loadSystem;
            this.sceneManager = sceneManager;
            this.sceneStateManager = sceneStateManager;
        }

        /// <summary>
        /// Requests an entity from the entity manager.
        /// </summary>
        /// <typeparam name="T">The entity type.</typeparam>
        /// <param name="position">The starting position of the entity.</param>
        /// <returns>A reference to the entity.</returns>
        public IEntity RequestEntity<T>(Vector3 position) where T : AbstractEntity, new()
        {
            // Store the type of entity requested.
            Type entityType = typeof(T);

            // Variable to hold requested entity.
            AbstractEntity entity = null;

            // Check if there is an inactive entity.
            if (inactiveEntities.ContainsKey(entityType))
            {
                if (inactiveEntities[entityType].Count > 0)
                {
                    // Get entity.
                    entity = inactiveEntities[entityType].ElementAt(0);

                    // Set ID.
                    entity.Setup(++entitiesCreated);

                    // Remove entity from the map.
                    inactiveEntities[entityType].RemoveAt(0);
                }
            }

            // Else, create new entity.
            else
            {
                // Create new entity.
                entity = new T();

                // Set ID.
                entity.Setup(++entitiesCreated);

                // Check if entity is loadable.
                // If loadable, add to load system.
                if (entity is ILoadable)
                {
                    loadSystem.AddEntity(entity);
                }
            }

            // Initialise entity.
            entity.Initialise(position, this, sceneStateManager);

            // Add entity to active pool.
            activeEntities.Add(entity.Id, entity);

            // Return entity as IEntity.
            return entity;
        }

        /// <summary>
        /// Terminates an entity.
        /// </summary>
        /// <param name="id">The ID of the entity.</param>
        public void Terminate(int id)
        {
            // Remove entity from scene.
            sceneManager.RemoveEntity(id);

            // Get entity from active pool.
            AbstractEntity entity = activeEntities[id];

            // Get entity type.
            Type entityType = entity.GetType();

            // Remove entity from active pool.
            activeEntities.Remove(id);

            // Add entity to inactive pool.
            // Check if the inactive pool contains the entity type.
            if (inactiveEntities.ContainsKey(entityType))
            {
                // Add to list.
                inactiveEntities[entityType].Add(entity);
            }

            // Else, create list for entity type and add to map.
            else
            {
                IList<AbstractEntity> entities = new List<AbstractEntity>
                {
                    entity
                };
                inactiveEntities[entityType] = entities;
            }
        }
    }
}
