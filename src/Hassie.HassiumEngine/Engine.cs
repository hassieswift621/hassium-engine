using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Hassie.HassiumEngine.Collision;
using Hassie.HassiumEngine.Entity;
using Hassie.HassiumEngine.Render;
using Hassie.HassiumEngine.Scene;
using Hassie.HassiumEngine.Update;
using Hassie.HassiumEngine.System;
using Hassie.HassiumEngine.Load;
using Hassie.HassiumEngine.Input;

namespace Hassie.HassiumEngine
{
    /// <summary>
    /// Game engine.
    /// The engine class contains everything required to run a game.
    /// It is left abstract so that a game implements it and provides its own components, 
    /// which ensures that game code stays truly separate to the base engine code.
    /// </summary>
    public abstract class Engine : Game
    {
        /// <summary>
        /// The game background colour after flushing graphics.
        /// </summary>
        protected Color backgroundColour;

        /// <summary>
        /// The graphics device manager.
        /// </summary>
        protected readonly GraphicsDeviceManager graphics;

        /// <summary>
        /// The entity manager.
        /// </summary>
        protected readonly IEntityProvider entityManager;

        /// <summary>
        /// The scene manager.
        /// </summary>
        protected readonly ISceneManager sceneManager;

        /// <summary>
        /// The collision system.
        /// </summary>
        private readonly ISystem collisionSystem;

        /// <summary>
        /// The input system.
        /// </summary>
        private readonly ISystem inputSystem;

        /// <summary>
        /// The load system.
        /// </summary>
        private readonly ISystem loadSystem;

        /// <summary>
        /// The render system.
        /// </summary>
        private readonly ISystem renderSystem;

        /// <summary>
        /// The update system.
        /// </summary>
        private readonly ISystem updateSystem;

        /// <summary>
        /// Constructor for the engine.
        /// </summary>
        /// <param name="collisionComponent">The collision component to use for collision detection.</param>
        /// <param name="backgroundColour">The game background colour after flushing graphics.
        /// Transparent by default.</param>
        public Engine(ICollisionComponent collisionComponent, Color? backgroundColour = null)
        {
            // Setup graphics device manager and content directory.
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";

            // Set background colour.
            if (backgroundColour.HasValue)
            {
                this.backgroundColour = backgroundColour.Value;
            }
            else
            {
                this.backgroundColour = Color.Transparent;
            }

            // Initialise systems.
            collisionSystem = new CollisionSystem(collisionComponent);
            inputSystem = new InputSystem();
            loadSystem = new LoadSystem(Content);
            renderSystem = new RenderSystem(graphics);
            updateSystem = new UpdateSystem();

            // Create scene manager and entity manager.
            sceneManager = new SceneManager(collisionSystem, inputSystem, renderSystem, updateSystem);
            entityManager = new EntityManager(loadSystem, sceneManager, (ISceneStateManager) sceneManager);
        }

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content. Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {
            // Base initialisation.
            base.Initialize();
        }

        /// <summary>
        /// LoadContent is called once per game and is the place to load
        /// all of the content.
        /// </summary>
        protected override void LoadContent()
        {
            // Load entities.
            loadSystem.Update(new GameTime());

            // Base load.
            base.LoadContent();
        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// game-specific content.
        /// </summary>
        protected override void UnloadContent() { }

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {
            // Update systems.
            inputSystem.Update(gameTime);
            collisionSystem.Update(gameTime);
            updateSystem.Update(gameTime);

            // Base update.
            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            // Flush graphics.
            GraphicsDevice.Clear(backgroundColour);

            // Load pending entities.
            loadSystem.Update(gameTime);

            // Render.
            renderSystem.Update(gameTime);

            // Base draw.
            base.Draw(gameTime);
        }
    }
}
