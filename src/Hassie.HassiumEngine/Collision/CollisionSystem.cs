using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Hassie.HassiumEngine.System;

namespace Hassie.HassiumEngine.Collision
{
    /// <summary>
    /// Collision system.
    /// The collision system is responsible for handling the collision detection in the game.
    /// </summary>
    public class CollisionSystem : ISystem
    {
        // Collision component to use for collision detection.
        private readonly ICollisionComponent collisionComponent;

        /// <summary>
        /// Constructor for the collision system.
        /// </summary>
        /// <param name="collisionComponent">The collision component to use.</param>
        public CollisionSystem(ICollisionComponent collisionComponent)
        {
            // Store collision component.
            this.collisionComponent = collisionComponent;
        }

        /// <summary>
        /// Adds an entity to the system.
        /// </summary>
        /// <param name="entity">The entity to add.</param>
        public void AddEntity(IEntity entity)
        {
            // Add entity to collision component.
            collisionComponent.AddEntity(entity);
        }

        /// <summary>
        /// Removes an entity from the system.
        /// </summary>
        /// <param name="id">The ID of the entity.</param>
        public void RemoveEntity(int id)
        {
            // Remove entity from collision component.
            collisionComponent.RemoveEntity(id);
        }

        /// <summary>
        /// Update method.
        /// </summary>
        /// <param name="gameTime">Snapshot of elapsed time values.</param>
        public void Update(GameTime gameTime)
        {
            // Update collision component.
            collisionComponent.Update(gameTime);
        }
    }
}
