using Hassie.HassiumEngine.Entity;
using Hassie.HassiumEngine.System;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hassie.HassiumEngine.Scene
{
    /// <summary>
    /// Abstract scene.
    /// A scene contains a scene graph which contains all the entities in the scene.
    /// A scene also has a state, allowing it to be paused, run and stopped.
    /// </summary>
    public abstract class AbstractScene : IScene, ISceneState
    {
        protected readonly IEntityProvider entityProvider; // The entity provider.
        protected readonly IEntityTerminator entityTerminator; // The entity terminator.
        protected ISceneGraph sceneGraph; // The scene graph.

        /// <summary>
        /// The current state of the scene.
        /// </summary>
        public SceneState State { get; protected set; } = SceneState.Stopped;

        /// <summary>
        /// Constructor for the scene.
        /// </summary>
        /// <param name="entityProvider">The entity provider.</param>
        /// <param name="entityTerminator">The entity terminator.</param>
        public AbstractScene(IEntityProvider entityProvider, IEntityTerminator entityTerminator)
        {
            // Store entity provider and terminator.
            this.entityProvider = entityProvider;
            this.entityTerminator = entityTerminator;
        }

        /// <summary>
        /// Adds an entity to the scene.
        /// </summary>
        /// <param name="entity">The entity to add.</param>
        public void AddEntity(IEntity entity)
        {
            sceneGraph.AddEntity(entity);
        }

        /// <summary>
        /// Gets the entities in the scene.
        /// </summary>
        /// <returns>A list of entities in the scene.</returns>
        public IReadOnlyList<IEntity> GetEntities()
        {
            if (sceneGraph == null)
            {
                return new List<IEntity>(0);
            }
            return sceneGraph.GetEntities();
        }

        /// <summary>
        /// Pauses the scene.
        /// A paused scene is continued to be rendered but is not updated.
        /// </summary>
        /// <returns>A list of entities in the scene.</returns>
        public virtual IReadOnlyList<IEntity> Pause()
        {
            // Set state to paused.
            State = SceneState.Paused;

            return sceneGraph.GetEntities();
        }

        /// <summary>
        /// Removes an entity from the scene.
        /// </summary>
        /// <param name="id">The ID of the entity.</param>
        public void RemoveEntity(int id)
        {
            if (sceneGraph != null)
            {
                sceneGraph.RemoveEntity(id);
            }
        }

        /// <summary>
        /// Runs the scene.
        /// </summary>
        /// <param name="initialise">Whether to intialise the scene first, such as creating entities.</param>
        /// <returns>A list of entities in the scene.</returns>
        public virtual IReadOnlyList<IEntity> Run(bool initialise)
        {
            // Set state to running.
            State = SceneState.Running;

            return sceneGraph.GetEntities();
        }

        /// <summary>
        /// Stops the scene.
        /// A stopped scene is not rendered nor updated.
        /// </summary>
        /// <returns>A list of entities in the scene.</returns>
        public virtual IReadOnlyList<IEntity> Stop()
        {
            // Set state to stopped.
            State = SceneState.Stopped;

            return sceneGraph.GetEntities();
        }
    }
}
