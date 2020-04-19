using Hassie.HassiumEngine.Entity;
using Hassie.HassiumEngine.Pong.Entity;
using Hassie.HassiumEngine.Scene;
using Hassie.HassiumEngine.System;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hassie.HassiumEngine.Pong.Scene
{
    /// <summary>
    /// Main game scene.
    /// </summary>
    public class PongScene : AbstractScene
    {
        public PongScene(IEntityProvider entityProvider, IEntityTerminator entityTerminator) : base(entityProvider, entityTerminator)
        {
        }

        public override IReadOnlyList<IEntity> Run(bool initialise)
        {
            // If initialise, setup.
            if (initialise)
            {
                sceneGraph = new MapSceneGraph();

                // Create ball.
                Ball ball = (Ball)entityProvider.RequestEntity<Ball>(new Vector3((Game.GameWidth / 2) - 50, (Game.GameHeight / 2) - 50, 0));
                ball.DirectionX = 1;
                ball.DirectionY = 1;
                ball.VelocityX = 2.5f;
                ball.VelocityY = 2.5f;
                AddEntity(ball);

                // Create player one paddle.
                Paddle paddleA = (Paddle)entityProvider.RequestEntity<Paddle>(new Vector3(0, (Game.GameHeight / 2) - 75, 0));
                paddleA.PlayerIndex = 1;
                AddEntity(paddleA);

                // Create player two paddle.
                Paddle paddleB = (Paddle)entityProvider.RequestEntity<Paddle>(
                    new Vector3(Game.GameWidth - 50, (Game.GameHeight / 2) - 75, 0));
                paddleB.PlayerIndex = 2;
                AddEntity(paddleB);
            }

            return base.Run(initialise);
        }
    }
}
