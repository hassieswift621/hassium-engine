using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hassie.HassiumEngine.Scene;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Hassie.HassiumEngine.Entity
{
    /// <summary>
    /// An abstract class for all entities.
    /// The abstract class implements the IDisplayableEntity interface.
    /// </summary>
    public abstract class AbstractEntity : IDisplayableEntity
    {
        protected IEntityTerminator entityTerminator; // Entity terminator.
        protected ISceneStateManager sceneStateManager; // Scene state manager.

        /// <summary>
        /// The height of the entity.
        /// </summary>
        public virtual int Height { get; protected set; } = 0;

        /// <summary>
        /// The unique ID of the entity.
        /// </summary>
        public int Id { get; private set; }

        /// <summary>
        /// The position of the entity.
        /// </summary>
        public virtual Vector3? Position { get; set; } = null;

        /// <summary>
        /// The scale of the entity.
        /// </summary>
        public virtual float Scale { get; set; } = 1;

        /// <summary>
        /// The width of the entity.
        /// </summary>
        public virtual int Width { get; protected set; } = 0;

        /// <summary>
        /// Initialises the entity to its initial state.
        /// </summary>
        /// <param name="position">The starting position of the entity.</param>
        /// <param name="entityTerminator">The entity terminator.</param>
        /// <param name="sceneStateManager">The scene state manager.</param>
        public virtual void Initialise(Vector3 position, IEntityTerminator entityTerminator, ISceneStateManager sceneStateManager)
        {
            Position = position;
            this.entityTerminator = entityTerminator;
            this.sceneStateManager = sceneStateManager;
        }

        /// <summary>
        /// Sets up the entity, assigning the unique ID.
        /// </summary>
        /// <param name="id">The unique ID of the entity.</param>
        public void Setup(int id)
        {
            Id = id;
        }
    }
}
