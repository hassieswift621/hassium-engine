using Hassie.HassiumEngine.Event;
using Hassie.HassiumEngine.System;
using Hassie.HassiumEngine.Update;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hassie.HassiumEngine.Input
{
    /// <summary>
    /// Input system.
    /// The input system is responsible for updating input handlers.
    /// </summary>
    public class InputSystem : ISystem
    {
        private readonly IDictionary<int, IEntity> entities; // Map of entities.
        private readonly IEventHandler<KeyboardEvent> keyboardInput; // Keyboard input handler.
        private readonly IEventHandler<LeftMouseEvent> leftMouseInput; // Left mouse input handler.
        private readonly IEventHandler<RightMouseEvent> rightMouseEvent; // Right mouse input handler.

        /// <summary>
        /// Constructor for the input system.
        /// </summary>
        public InputSystem()
        {
            // Initialise map.
            entities = new Dictionary<int, IEntity>();

            // Initialise input handlers.
            keyboardInput = new KeyboardInputHandler();
            leftMouseInput = new LeftMouseEventHandler();
            rightMouseEvent = new RightMouseEventHandler();
        }

        /// <summary>
        /// Adds an entity to the system.
        /// </summary>
        /// <param name="entity">The entity to add.</param>
        public void AddEntity(IEntity entity)
        {
            // If entity already exists, don't attempt to add.
            if (entities.ContainsKey(entity.Id)) return;

            // If entity is listening to keyboard input, add to system and keyboard input handler.
            if (entity is IEventListener<KeyboardEvent>)
            {
                keyboardInput.Subscribe(((IEventListener<KeyboardEvent>)entity).OnEvent);
                entities.Add(entity.Id, entity);
            }

            // If entity is listening to left mouse input, add to system and left mouse input handler.
            if (entity is IEventListener<LeftMouseEvent>)
            {
                leftMouseInput.Subscribe(((IEventListener<LeftMouseEvent>)entity).OnEvent);
                entities.Add(entity.Id, entity);
            }

            // If entity is listening to right mouse input, add to system and right mouse input handler.
            if (entity is IEventListener<RightMouseEvent>)
            {
                rightMouseEvent.Subscribe(((IEventListener<RightMouseEvent>)entity).OnEvent);
                entities.Add(entity.Id, entity);
            }
        }

        /// <summary>
        /// Removes an entity from the system.
        /// </summary>
        /// <param name="id">The ID of the entity.</param>
        public void RemoveEntity(int id)
        {
            // Check if entity is in the input system.
            if (entities.ContainsKey(id))
            {
                // Get and remove entity.
                IEntity entity = entities[id];
                entities.Remove(id);

                // If entity is listening to keyboard input, remove from keyboard input handler.
                if (entity is IEventListener<KeyboardEvent>)
                {
                    keyboardInput.Unsubscribe(((IEventListener<KeyboardEvent>)entity).OnEvent);
                }

                // If entity is listening to left mouse input, remove from left mouse input handler.
                if (entity is IEventListener<LeftMouseEvent>)
                {
                    leftMouseInput.Unsubscribe(((IEventListener<LeftMouseEvent>)entity).OnEvent);
                }

                // If entity is listening to right mouse input, remove from right mouse input handler.
                if (entity is IEventListener<RightMouseEvent>)
                {
                    rightMouseEvent.Unsubscribe(((IEventListener<RightMouseEvent>)entity).OnEvent);
                }
            }
        }

        /// <summary>
        /// Update method.
        /// </summary>
        /// <param name="gameTime">Snapshot of elapsed time values.</param>
        public void Update(GameTime gameTime)
        {
            // Update input handlers.
            keyboardInput.Update(gameTime);
            leftMouseInput.Update(gameTime);
            rightMouseEvent.Update(gameTime);
        }
    }
}
