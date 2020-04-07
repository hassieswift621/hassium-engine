using Hassie.HassiumEngine.Entity;
using Hassie.HassiumEngine.Load;
using Hassie.HassiumEngine.Render;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hassie.HassiumEngine.Pong.Entity
{
    /// <summary>
    /// Renderable text entity.
    /// </summary>
    public class RenderText : AbstractEntity, ILoadable, IRenderable
    {
        // The font to use to render.
        protected SpriteFont font;

        /// <summary>
        /// The colour to use to render.
        /// </summary>
        public Color Colour { get; set; }

        public int RenderOrder => 3;

        /// <summary>
        /// The text to render.
        /// </summary>
        public string Text { get; set; }

        public void Load(ContentManager contentManager)
        {
            // Load font.
            font = contentManager.Load<SpriteFont>("Exo-2-SemiBold");
        }

        public virtual void Render(GameTime gameTime, SpriteBatch spriteBatch)
        {
            spriteBatch.DrawString(font, Text, new Vector2(Position.Value.X, Position.Value.Y), Colour);
        }
    }
}
