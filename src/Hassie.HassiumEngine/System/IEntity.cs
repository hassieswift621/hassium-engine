using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hassie.HassiumEngine.System
{
    /// <summary>
    /// An interface for all entities.
    /// The interface contains the unique ID of the entity.
    /// </summary>
    public interface IEntity
    {
        /// <summary>
        /// The unique ID of the entity.
        /// </summary>
        int Id { get; }
    }
}
