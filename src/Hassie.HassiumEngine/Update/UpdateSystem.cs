using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Hassie.HassiumEngine.System;

namespace Hassie.HassiumEngine.Update
{
    /// <summary>
    /// Update system.
    /// The update system is responsible for updating any updatable entities.
    /// </summary>
    public class UpdateSystem : ISystem
    {
        private readonly IDictionary<int, IUpdatable> entities; // Map of entities.

        /// <summary>
        /// Constructor for the update system.
        /// </summary>
        public UpdateSystem()
        {
            // Initialise map.
            entities = new Dictionary<int, IUpdatable>();
        }

        /// <summary>
        /// Adds an entity to the system.
        /// </summary>
        /// <param name="entity">The entity to add.</param>
        public void AddEntity(IEntity entity)
        {
            // If entity already exists, don't attempt to add.
            if (entities.ContainsKey(entity.Id)) return;

            entities.Add(entity.Id, (IUpdatable)entity);
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
            // Update entities.
            IReadOnlyList<IUpdatable> updatables = entities.Values.ToList();
            foreach (IUpdatable updatable in updatables)
            {
                updatable.Update(gameTime);
            }
        }
    }
}
