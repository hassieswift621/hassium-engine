using Hassie.HassiumEngine.System;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hassie.HassiumEngine.Entity
{
    /// <summary>
    /// An interface for all entities.
    /// The base entity interface extends IEntity 
    /// and contains the common display properties such as position and scale.
    /// </summary>
    public interface IDisplayableEntity : IEntity
    {
        /// <summary>
        /// The height of the entity.
        /// </summary>
        int Height { get; }

        /// <summary>
        /// The position of the entity.
        /// </summary>
        Vector3? Position { get; }

        /// <summary>
        /// The scale of the entity.
        /// </summary>
        float Scale { get; }

        /// <summary>
        /// The width of the entity.
        /// </summary>
        int Width { get; }
    }
}
