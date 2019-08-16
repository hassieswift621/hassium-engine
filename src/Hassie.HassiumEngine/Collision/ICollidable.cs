using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hassie.HassiumEngine.Entity;

namespace Hassie.HassiumEngine.Collision
{
    /// <summary>
    /// An interface for entities which may react to collision events.
    /// </summary>
    public interface ICollidable
    {
        /// <summary>
        /// On collide event.
        /// The entity responds to the collision event.
        /// </summary>
        /// <param name="collidedEntity">The collided entity.</param>
        void OnCollide(IDisplayableEntity collidedEntity);
    }
}
