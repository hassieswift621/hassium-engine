using Hassie.HassiumEngine.Entity;
using Hassie.HassiumEngine.MegaPong.Entity;
using Hassie.HassiumEngine.Scene;
using Hassie.HassiumEngine.System;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hassie.HassiumEngine.MegaPong.Scene
{
    /// <summary>
    /// The HUD scene.
    /// </summary>
    public class HudScene : AbstractScene
    {
        public HudScene(IEntityProvider entityProvider, IEntityTerminator entityTerminator) : base(entityProvider, entityTerminator)
        {
        }

        public override IReadOnlyList<IEntity> Run(bool initialise)
        {
            if (initialise)
            {
                // Initialise scene graph.
                sceneGraph = new MapSceneGraph();

                // Create pong text entity.
                RenderText pongText = (RenderText)entityProvider.RequestEntity<RenderText>(new Vector3(Game.GameWidth / 2 - 40, 50, 0));
                pongText.Text = "MEGA PONG";
                pongText.Colour = Color.Black;
                AddEntity(pongText);

                // Create player 1 score entity.
                ScoreText player1Score = (ScoreText)entityProvider.RequestEntity<ScoreText>(new Vector3(50, 50, 0));
                player1Score.Player = 1;
                player1Score.Colour = Color.Black;
                AddEntity(player1Score);

                // Create player 2 score entity.
                ScoreText player2Score = (ScoreText)entityProvider.RequestEntity<ScoreText>(new Vector3(Game.GameWidth - 75, 50, 0));
                player2Score.Player = 2;
                player2Score.Colour = Color.Black;
                AddEntity(player2Score);
            }

            return base.Run(initialise);
        }
    }
}
