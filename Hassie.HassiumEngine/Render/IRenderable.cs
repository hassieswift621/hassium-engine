using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hassie.HassiumEngine.Render
{
    /// <summary>
    /// IRenderable interface.
    /// The interface allows an entity to render.
    /// </summary>
    public interface IRenderable
    {
        /// <summary>
        /// Render method.
        /// </summary>
        /// <param name="gameTime">Snapshot of elapsed time values.</param>
        /// <param name="spriteBatch">The sprite batch used to render.</param>
        void Render(GameTime gameTime, SpriteBatch spriteBatch);

        /// <summary>
        /// The render order of this entity.
        /// </summary>
        int RenderOrder { get; }
    }
}
