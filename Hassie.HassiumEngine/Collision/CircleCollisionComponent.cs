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
    /// Circle collision component.
    /// The circle collision component uses the bounding circle as the collision method.
    /// </summary>
    public class CircleCollisionComponent : AbstractCollisionComponent
    {
        protected override bool CheckCollision(IDisplayableEntity entity1, IDisplayableEntity entity2)
        {
            // Calculate the radius of the entities.
            float r1 = (entity1.Scale * entity1.Width) / 2;
            float r2 = (entity2.Scale * entity2.Width) / 2;

            // Check if the distance between the vectors is less than the radii.
            if (Vector3.Distance(entity1.Position.Value, entity2.Position.Value) < (r1 + r2))
            {
                return true;
            }

            return false;
        }
    }
}
