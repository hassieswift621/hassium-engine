using Hassie.HassiumEngine.Entity;
using Hassie.HassiumEngine.Event;
using Hassie.HassiumEngine.Input;
using Hassie.HassiumEngine.Load;
using Hassie.HassiumEngine.Render;
using Hassie.HassiumEngine.Update;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hassie.HassiumEngine.MegaPong.Entity
{
    /// <summary>
    /// Player paddle.
    /// </summary>
    public class Paddle : AbstractEntity, IEventListener<KeyboardEvent>, ILoadable, IRenderable, IUpdatable
    {
        public override int Height { get => Texture != null ? Texture.Height : 0; }

        public override int Width { get => Texture != null ? Texture.Width : 0; }

        /// <summary>
        /// The player index.
        /// </summary>
        public int PlayerIndex { get; set; }

        public int RenderOrder => 2;

        public Texture2D Texture { get; set; }

        /// <summary>
        /// The velocity of the paddle.
        /// </summary>
        public int Velocity { get; set; }

        public void Load(ContentManager contentManager)
        {
            // Load texture.
            Texture = contentManager.Load<Texture2D>("paddle");
        }

        public void OnEvent(object sender, KeyboardEvent e)
        {
            // Player 1.
            if (PlayerIndex == 1)
            {
                if (e.PressedKeys.Contains(Keys.W))
                {
                    Velocity = -3;
                }
                else if (e.PressedKeys.Contains(Keys.S))
                {
                    Velocity = 3;
                }
                else if (e.ReleasedKeys.Contains(Keys.W) || e.ReleasedKeys.Contains(Keys.S))
                {
                    Velocity = 0;
                }
            }
            // Player 2.
            else
            {
                if (e.PressedKeys.Contains(Keys.Up))
                {
                    Velocity = -3;
                }
                else if (e.PressedKeys.Contains(Keys.Down))
                {
                    Velocity = 3;
                }
                else if (e.ReleasedKeys.Contains(Keys.Up) || e.ReleasedKeys.Contains(Keys.Down))
                {
                    Velocity = 0;
                }
            }
        }

        public void Render(GameTime gameTime, SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(Texture, new Vector2(Position.Value.X, Position.Value.Y), null, Color.White,
                0, new Vector2(0, 0), 1, SpriteEffects.None, 0);
        }

        public void Update(GameTime gameTime)
        {
            // Update position.
            Position = new Vector3(Position.Value.X, Position.Value.Y + Velocity, Position.Value.Z);
        }
    }
}
