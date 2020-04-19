using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Hassie.HassiumEngine.System;

namespace Hassie.HassiumEngine.Render
{
    /// <summary>
    /// Render system.
    /// The render system is responsible for rendering any renderable entities.
    /// </summary>
    public class RenderSystem : ISystem
    {
        private readonly IList<KeyValuePair<int, IRenderable>> entities; // Renderable entities.
        private readonly GraphicsDeviceManager graphicsDeviceManager; // Graphics device manager.
        private SpriteBatch spriteBatch; // The sprite batch to use to render.

        /// <summary>
        /// Constructor for the render system.
        /// </summary>
        /// <param name="graphicsDeviceManager">The graphics device manager.</param>
        public RenderSystem(GraphicsDeviceManager graphicsDeviceManager)
        {
            // Initialise map.
            entities = new List<KeyValuePair<int, IRenderable>>();

            // Store graphics device manager.
            this.graphicsDeviceManager = graphicsDeviceManager;

            // On graphics device creation, run the event.
            this.graphicsDeviceManager.DeviceCreated += GraphicsDeviceManager_DeviceCreated;
        }

        /// <summary>
        /// On create graphics device event.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void GraphicsDeviceManager_DeviceCreated(object sender, EventArgs e)
        {
            // Create sprite batch.
            spriteBatch = new SpriteBatch(graphicsDeviceManager.GraphicsDevice);
        }

        /// <summary>
        /// Adds an entity to the system.
        /// </summary>
        /// <param name="entity">The entity to add.</param>
        public void AddEntity(IEntity entity)
        {
            // If entity already exists, don't attempt to add.
            foreach (KeyValuePair<int, IRenderable> renderableEntity in entities)
            {
                if (renderableEntity.Key == entity.Id) return;
            }

            // Cast entity to renderable.
            IRenderable renderable = (IRenderable)entity;

            // Check if the list is empty.
            if (entities.Count == 0)
            {
                entities.Add(new KeyValuePair<int, IRenderable>(entity.Id, (IRenderable)entity));
            }

            // Else, check if the entity render order is the highest, 
            // or equal to the current highest render order.
            else if (renderable.RenderOrder >= entities.Last().Value.RenderOrder)
            {
                entities.Add(new KeyValuePair<int, IRenderable>(entity.Id, renderable));
            }
            // Else, add the entity at the index based on the render order.
            else
            {
                int i = 0;
                bool added = false;
                while (i < entities.Count && !added)
                {
                    // If the entity render order is less than the current iterated entity, 
                    // add to list at that index.
                    if (renderable.RenderOrder < entities[i].Value.RenderOrder)
                    {
                        entities.Insert(i, new KeyValuePair<int, IRenderable>(entity.Id, renderable));

                        // Set added to true.
                        added = true;

                        // If entity has a changeable renderable order, hook it up to the event.
                        if (entity is IRenderOrderChangeable)
                        {
                            ((IRenderOrderChangeable)entity).RenderOrderChanged += RenderSystem_RenderOrderChanged;
                        }
                    }

                    // Increment i.
                    i++;
                }
            }
        }

        /// <summary>
        /// On render order changed event.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void RenderSystem_RenderOrderChanged(object sender, RenderOrderChangeEvent e)
        {
            // Remove and readd entity.
            RemoveEntity(e.Entity.Id);
            AddEntity(e.Entity);
        }

        /// <summary>
        /// Removes an entity from the system.
        /// </summary>
        /// <param name="id">The ID of the entity.</param>
        public void RemoveEntity(int id)
        {
            // Find entity and remove.
            int i = 0;
            bool found = false;
            while (i < entities.Count && !found)
            {
                // Get key value pair.
                KeyValuePair<int, IRenderable> entity = entities.ElementAt(i);

                // If key is the entity ID, remove and set found to true.
                if (entity.Key == id)
                {
                    entities.RemoveAt(i);
                    found = true;

                    // If entity had a changeable render order, unhook it from the event.
                    if (entity.Value is IRenderOrderChangeable)
                    {
                        ((IRenderOrderChangeable)entity.Value).RenderOrderChanged -= RenderSystem_RenderOrderChanged;
                    }
                }

                // Increment i.
                i++;
            }
        }

        /// <summary>
        /// Update method.
        /// </summary>
        /// <param name="gameTime">Snapshot of elapsed time values.</param>
        public void Update(GameTime gameTime)
        {
            // Begin sprite batch.
            spriteBatch.Begin();

            // Render entities.
            foreach (KeyValuePair<int, IRenderable> renderable in entities)
            {
                renderable.Value.Render(gameTime, spriteBatch);
            }

            // End sprite batch.
            spriteBatch.End();
        }
    }
}
