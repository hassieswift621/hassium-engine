using Hassie.HassiumEngine.System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hassie.HassiumEngine.Load
{
    /// <summary>
    /// Load system.
    /// The load system is responsible for loading entities such as textures and fonts.
    /// </summary>
    public class LoadSystem : ISystem
    {
        private readonly ContentManager contentManager; // The content manager to use to load entities.
        private IDictionary<int, ILoadable> entities; // Map of loadable entities.

        /// <summary>
        /// Constructor for the load system.
        /// </summary>
        /// <param name="contentManager">The content manager to use to load entities</param>
        public LoadSystem(ContentManager contentManager)
        {
            // Initialise map.
            entities = new Dictionary<int, ILoadable>();

            // Store content manager.
            this.contentManager = contentManager;
        }

        /// <summary>
        /// Adds an entity to the system.
        /// </summary>
        /// <param name="entity">The entity to add.</param>
        public void AddEntity(IEntity entity)
        {
            // If entity already exists, don't attempt to add.
            if (entities.ContainsKey(entity.Id)) return;

            entities.Add(entity.Id, (ILoadable)entity);
        }

        /// <summary>
        /// Removes an entity from the system.
        /// </summary>
        /// <param name="id">The ID of the entity.</param>
        public void RemoveEntity(int id)
        {
            entities.Remove(id);
        }

        /// <summary>
        /// Update method.
        /// </summary>
        /// <param name="gameTime">Snapshot of elapsed time values.</param>
        public void Update(GameTime gameTime)
        {
            // Check if there are entities to load.
            if (entities.Count > 0)
            {
                // Get entities.
                IReadOnlyList<KeyValuePair<int, ILoadable>> loadables = entities.ToList();

                // Load entity and remove from map.
                foreach(KeyValuePair<int, ILoadable> loadable in loadables)
                {
                    loadable.Value.Load(contentManager);
                    RemoveEntity(loadable.Key);
                }
            }
        }
    }
}
