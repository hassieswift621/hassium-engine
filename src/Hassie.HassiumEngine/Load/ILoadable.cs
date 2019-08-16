using Microsoft.Xna.Framework.Content;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hassie.HassiumEngine.Load
{
    /// <summary>
    /// ILoadable interface.
    /// The loadable interface allows an entity to load itself.
    /// </summary>
    public interface ILoadable
    {
        /// <summary>
        /// Loads the entity.
        /// </summary>
        /// <param name="contentManager">The content manager to use to load the entity.</param>
        void Load(ContentManager contentManager);
    }
}
