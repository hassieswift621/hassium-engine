using Hassie.HassiumEngine.Collision;
using Hassie.HassiumEngine.Entity;
using Hassie.HassiumEngine.MegaPong.Scene;
using Hassie.HassiumEngine.Scene;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;

namespace Hassie.HassiumEngine.MegaPong
{
    /// <summary>
    /// Pong game.
    /// </summary>
    public class Game : Engine
    {
        public static int GameHeight { get; } = 720;

        public static int GameWidth { get; } = 1280;

        /// <summary>
        /// Number of balls to spawn.
        /// </summary>
        public static int BallCount { get; } = 500;

        public Game() : base(new HitboxCollisionComponent(), Color.DarkOrange)
        {
            // Set height and width to 1280x720.
            graphics.PreferredBackBufferWidth = 1280;
            graphics.PreferredBackBufferHeight = 720;
        }

        protected override void Initialize()
        {
            // Create pong scene.
            PongScene pongScene = new PongScene(entityManager, (IEntityTerminator)entityManager);
            sceneManager.AddScene(1, pongScene);
            ((ISceneStateManager)sceneManager).RunScene(1, true);

            // Create HUD scene.
            HudScene hudScene = new HudScene(entityManager, (IEntityTerminator)entityManager);
            sceneManager.AddScene(2, hudScene);
            ((ISceneStateManager)sceneManager).RunScene(2, true);

            base.Initialize();
        }
    }
}
