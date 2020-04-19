using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Hassie.HassiumEngine.Entity;
using Hassie.HassiumEngine.System;

namespace Hassie.HassiumEngine.Collision
{
    /// <summary>
    /// Abstract collision component.
    /// The abstract collision component contains an abstract check collision method, 
    /// where the method to check for collisions is specified.
    /// The update method calls this method to check for collisions between two entities.
    /// </summary>
    public abstract class AbstractCollisionComponent : ICollisionComponent
    {
        private readonly IDictionary<int, IDisplayableEntity> entities; // Map of entities.

        /// <summary>
        /// Constructor for the collision component.
        /// </summary>
        public AbstractCollisionComponent()
        {
            // Initialise entities map.
            entities = new Dictionary<int, IDisplayableEntity>();
        }

        /// <summary>
        /// The method to use to check for collision between two entities.
        /// </summary>
        /// <param name="entity1"></param>
        /// <param name="entity2"></param>
        /// <returns>True if entities have collided, false otherwise.</returns>
        protected abstract bool CheckCollision(IDisplayableEntity entity1, IDisplayableEntity entity2);

        /// <summary>
        /// Adds an entity to the collision component.
        /// </summary>
        /// <param name="entity">The entity to add.</param>
        public void AddEntity(IEntity entity)
        {
            // If entity already exists or is not displayable, don't attempt to add.
            if (entities.ContainsKey(entity.Id) || !(entity is IDisplayableEntity)) return;

            // Add entity to map.
            entities.Add(entity.Id, (IDisplayableEntity)entity);
        }

        /// <summary>
        /// Removes an entity from the collision component.
        /// </summary>
        /// <param name="id">The ID of the entity.</param>
        public void RemoveEntity(int id)
        {
            // Check if the map contains the entity.
            if (entities.ContainsKey(id))
            {
                // Remove entity from map.
                entities.Remove(id);
            }
        }

        /// <summary>
        /// Collision component update method.
        /// </summary>
        /// <param name="gameTime">Snapshot of elapsed time values.</param>
        public void Update(GameTime gameTime)
        {
            // Get entities.
            IReadOnlyList<IDisplayableEntity> entities = this.entities.Values.ToList();

            // Run through entities and check if they collide.
            // Condition to terminate is list size - 1, because the last entity will already have been 
            // checked with the other entities; this saves a wasteful iteration.
            for (int i = 0; i < entities.Count - 1; i++)
            {
                // Get entity 1.
                IDisplayableEntity entity1 = entities.ElementAt(i);

                // Run through the other entities to check against.
                // Here the loop count is i + 1, because we want to skip entities already checked and avoid checking 
                // against itself:
                // i.e. entity index 0 is checked with index 3, when index 3 is being iterated in the main loop, 
                // setting it to i + 1 means it will start checking index 3 against index 4; 
                // this saves many wasteful iterations.
                for (int j = i + 1; j < entities.Count; j++)
                {
                    // Get entity 2.
                    IDisplayableEntity entity2 = entities.ElementAt(j);

                    // Check if entities collide.
                    if (CheckCollision(entity1, entity2))
                    {
                        // If entity is collidable, call on collide.
                        if (entity1 is ICollidable)
                        {
                            ((ICollidable)entity1).OnCollide(entity2);
                        }
                        if (entity2 is ICollidable)
                        {
                            ((ICollidable)entity2).OnCollide(entity1);
                        }
                    }
                }
            }
        }
    }
}
