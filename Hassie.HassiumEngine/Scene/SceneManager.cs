using Hassie.HassiumEngine.Collision;
using Hassie.HassiumEngine.Render;
using Hassie.HassiumEngine.System;
using Hassie.HassiumEngine.Update;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hassie.HassiumEngine.Scene
{
    /// <summary>
    /// The scene manager.
    /// The scene manager is responsible for rendering and updating entities in scenes.
    /// </summary>
    public class SceneManager : ISceneManager, ISceneStateManager
    {
        private readonly IDictionary<int, IScene> scenes; // Map of scenes.
        private readonly ISystem collisionSystem; // The collision system.
        private readonly ISystem inputSystem; // The input system.
        private readonly ISystem renderSystem; // The render system.
        private readonly ISystem updateSystem; // The update system.

        public SceneManager(ISystem collisionSystem, ISystem inputSystem, ISystem renderSystem, ISystem updateSystem)
        {
            // Store systems.
            this.collisionSystem = collisionSystem;
            this.inputSystem = inputSystem;
            this.renderSystem = renderSystem;
            this.updateSystem = updateSystem;

            // Initialise scenes map.
            scenes = new Dictionary<int, IScene>();
        }

        /// <summary>
        /// Adds an entity to a scene.
        /// </summary>
        /// <param name="sceneId">The ID of the scene.</param>
        /// <param name="entity">The entity to add.</param>
        public void AddEntity(int sceneId, IEntity entity)
        {
            // Check if scene exists.
            if (scenes.ContainsKey(sceneId))
            {
                // Get scene.
                IScene scene = scenes[sceneId];

                // Add entity.
                scenes[sceneId].AddEntity(entity);

                // If scene is running, add to systems.
                if (((ISceneState)scene).State == SceneState.Running)
                {
                    collisionSystem.AddEntity(entity);
                    inputSystem.AddEntity(entity);
                    if (entity is IRenderable) renderSystem.AddEntity(entity);
                    if (entity is IUpdatable) updateSystem.AddEntity(entity);
                }

                // Else if, scene is paused, add to render system only.
                else if (((ISceneState)scene).State == SceneState.Paused)
                {
                    if (entity is IRenderable) renderSystem.AddEntity(entity);
                }
            }
        }

        /// <summary>
        /// Adds a scene to the scene manager.
        /// </summary>
        /// <param name="id">The ID of the scene.</param>
        /// <param name="scene">The scene to add.</param>
        public void AddScene(int id, IScene scene)
        {
            scenes.Add(id, scene);
        }

        /// <summary>
        /// Pauses a scene.
        /// A paused scene is continued to be rendered but is not updated.
        /// </summary>
        /// <param name="id">The ID of the scene.</param>
        public void PauseScene(int id)
        {
            // Check if the scene exists.
            if (scenes.ContainsKey(id))
            {
                // Get scene as scene state.
                ISceneState state = (ISceneState)scenes[id];

                // If scene is already paused or stopped, don't attempt to pause; return.
                if (state.State == SceneState.Paused || state.State == SceneState.Stopped) return;

                // Pause scene.
                IReadOnlyList<IEntity> entities = state.Pause();

                // Remove entities from collision, input and update systems.
                foreach (IEntity entity in entities)
                {
                    collisionSystem.RemoveEntity(entity.Id);
                    inputSystem.RemoveEntity(entity.Id);
                    updateSystem.RemoveEntity(entity.Id);
                }
            }
        }

        /// <summary>
        /// Removes an entity from the scene.
        /// </summary>
        /// <param name="id">The ID of the entity.</param>
        public void RemoveEntity(int id)
        {
            // Get scenes.
            IReadOnlyList<IScene> scenes = this.scenes.Values.ToList();
            foreach (IScene scene in scenes)
            {
                scene.RemoveEntity(id);
            }

            // Remove from systems.
            collisionSystem.RemoveEntity(id);
            renderSystem.RemoveEntity(id);
            inputSystem.RemoveEntity(id);
            updateSystem.RemoveEntity(id);
        }

        /// <summary>
        /// Removes a scene from the scene manager.
        /// </summary>
        /// <param name="id">The ID of the scene.</param>
        public void RemoveScene(int id)
        {
            scenes.Remove(id);
        }

        /// <summary>
        /// Runs a scene.
        /// </summary>
        /// <param name="id">The ID of the scene.</param>
        /// <param name="initialise">Whether to intialise the scene.</param>
        public void RunScene(int id, bool initialise)
        {
            // Check if the scene exists.
            if (scenes.ContainsKey(id))
            {
                // Get scene as scene state.
                ISceneState state = (ISceneState)scenes[id];

                // If scene is already running, return.
                if (state.State == SceneState.Running) return;

                // Else if scene is paused, then we want to remove the entities from the render system.
                else if (state.State == SceneState.Paused)
                {
                    // Get renderable entities from scene.
                    IReadOnlyList<IEntity> renderables = scenes[id].GetEntities().Where(entity => entity is IRenderable).ToList();

                    // Remove entities from render system.
                    foreach (IEntity entity in renderables)
                    {
                        renderSystem.RemoveEntity(entity.Id);
                    }
                }

                // Run scene.
                IReadOnlyList<IEntity> entities = state.Run(initialise);

                // Add entities to systems.
                foreach (IEntity entity in entities)
                {
                    collisionSystem.AddEntity(entity);
                    inputSystem.AddEntity(entity);
                    if (entity is IRenderable) renderSystem.AddEntity(entity);
                    if (entity is IUpdatable) updateSystem.AddEntity(entity);
                }
            }
        }

        /// <summary>
        /// Stops a scene.
        /// A stopped scene is not rendered nor updated.
        /// </summary>
        /// <param name="id">The ID of the scene.</param>
        public void StopScene(int id)
        {
            // Check if scene exists.
            if (scenes.ContainsKey(id))
            {
                // Get scene as state.
                ISceneState state = (ISceneState)scenes[id];

                // If scene is already stopped, return.
                if (state.State == SceneState.Stopped) return;

                // If scene is paused, remove entities from render system.
                else if (state.State == SceneState.Paused)
                {
                    // Get renderable entities.
                    IReadOnlyList<IEntity> renderables = state.Stop().Where(entity => entity is IRenderable).ToList();

                    // Remove entities from render system.
                    foreach (IEntity entity in renderables)
                    {
                        renderSystem.RemoveEntity(entity.Id);
                    }
                }

                // Else, remove entities from all systems.
                else
                {
                    // Get entities.
                    IReadOnlyList<IEntity> entities = state.Stop();

                    // Remove entities from systems.
                    foreach (IEntity entity in entities)
                    {
                        collisionSystem.RemoveEntity(entity.Id);
                        inputSystem.RemoveEntity(entity.Id);
                        renderSystem.RemoveEntity(entity.Id);
                        updateSystem.RemoveEntity(entity.Id);
                    }
                }
            }
        }
    }
}
