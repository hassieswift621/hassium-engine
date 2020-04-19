using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hassie.HassiumEngine.MegaPong.Entity
{
    public class ScoreText : RenderText
    {
        /// <summary>
        /// Player 1 score.
        /// </summary>
        public static int Player1Score { get; set; }

        /// <summary>
        /// Player 2 score.
        /// </summary>
        public static int Player2Score { get; set; }

        /// <summary>
        /// The player no.
        /// </summary>
        public int Player { get; set; }

        public override void Render(GameTime gameTime, SpriteBatch spriteBatch)
        {
            if (Player == 1)
            {
                spriteBatch.DrawString(font, Player1Score.ToString(), new Vector2(Position.Value.X, Position.Value.Y), Colour);
            }
            else
            {
                spriteBatch.DrawString(font, Player2Score.ToString(), new Vector2(Position.Value.X, Position.Value.Y), Colour);
            }
        }
    }
}
