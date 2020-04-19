using Hassie.HassiumEngine.Collision;
using Hassie.HassiumEngine.Entity;
using Hassie.HassiumEngine.Load;
using Hassie.HassiumEngine.Render;
using Hassie.HassiumEngine.Update;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hassie.HassiumEngine.MegaPong.Entity
{
    /// <summary>
    /// Pong ball.
    /// </summary>
    public class Ball : AbstractEntity, ICollidable, ILoadable, IRenderable, IUpdatable
    {
        public override int Height { get => Texture != null ? Texture.Height : 0; }

        public override int Width { get => Texture != null ? Texture.Width : 0; }

        public int RenderOrder => 100;

        /// <summary>
        /// The heading direction along the x axis.
        /// </summary>
        public int DirectionX { get; set; }

        /// <summary>
        /// The heading direction along the y axis.
        /// </summary>
        public int DirectionY { get; set; }

        /// <summary>
        /// The texture.
        /// </summary>
        public Texture2D Texture { get; set; }

        /// <summary>
        /// The velocity of the ball along the x axis.
        /// </summary>
        public float VelocityX { get; set; }

        /// <summary>
        /// The velocity of the ball along the y axis.
        /// </summary>
        public float VelocityY { get; set; }

        public void Load(ContentManager contentManager)
        {
            // Load texture.
            Texture = contentManager.Load<Texture2D>("square");
        }

        public void OnCollide(IDisplayableEntity collidedEntity)
        {
            // Check if the entity was a paddle.
            if (collidedEntity is Paddle paddle)
            {
                // Check player index, update direction and velocity accordingly.
                DirectionX = paddle.PlayerIndex == 1 ? 1 : -1;
                VelocityX *= 1.25f;
            }
        }

        public void Render(GameTime gameTime, SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(Texture, new Vector2(Position.Value.X, Position.Value.Y), null, Color.Black, 
                0, new Vector2(0, 0), 0.35f, SpriteEffects.None, 0);
        }

        public void Update(GameTime gameTime)
        {
            // If past screen bounds along x axis, reset in middle and update score.
            if (Position.Value.X >= Game.GameWidth)
            {
                VelocityX = 2.5f;
                Position = new Vector3((Game.GameWidth / 2) - 50, (Game.GameHeight / 2) - 50, 0);
                ScoreText.Player1Score += 1;
            }
            else if (Position.Value.X <= 0)
            {
                VelocityX = 2.5f;
                Position = new Vector3((Game.GameWidth / 2) - 50, (Game.GameHeight / 2) - 50, 0);
                ScoreText.Player2Score += 1;
            }

            // If past screen bounds along y axis, switch direction.
            if (Position.Value.Y >= Game.GameHeight)
            {
                DirectionY = -1;
            }
            else if (Position.Value.Y <= 0)
            {
                DirectionY = 1;
            }

            // Update position.
            Position = new Vector3(Position.Value.X + (VelocityX * DirectionX), Position.Value.Y + (VelocityY * DirectionY), Position.Value.Z);
        }
    }
}
