using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hassie.HassiumEngine.Entity;

namespace Hassie.HassiumEngine.Collision
{
    /// <summary>
    /// Hitbox collision component.
    /// The hitbox collision component uses the hitbox collision method 
    /// by using MonoGame's built in rectangle tool.
    /// </summary>
    public class HitboxCollisionComponent : AbstractCollisionComponent
    {
        protected override bool CheckCollision(IDisplayableEntity entity1, IDisplayableEntity entity2)
        {
            // Get bounds of entity 1.
            Rectangle entity1Bounds = new Rectangle
            {
                X = (int)entity1.Position.Value.X,
                Y = (int)entity1.Position.Value.Y,
                Height = entity1.Height,
                Width = entity1.Width
            };

            // Get bounds of entity 2.
            Rectangle entity2Bounds = new Rectangle
            {
                X = (int)entity2.Position.Value.X,
                Y = (int)entity2.Position.Value.Y,
                Height = entity2.Height,
                Width = entity2.Width
            };

            // Check if the entity bounds intersect.
            if (entity1Bounds.Intersects(entity2Bounds))
            {
                return true;
            }

            return false;
        }
    }
}
