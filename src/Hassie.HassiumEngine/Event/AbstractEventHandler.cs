using Hassie.HassiumEngine.Update;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hassie.HassiumEngine.Event
{
    /// <summary>
    /// Abstract event handler.
    /// </summary>
    /// <typeparam name="T">The type of event received.</typeparam>
    public abstract class AbstractEventHandler<T> : IEventHandler<T> where T : EventArgs
    {
        protected event EventHandler<T> EventHandler ; // The event handler.

        /// <summary>
        /// Whether the event has listeners.
        /// </summary>
        protected bool HasListeners
        {
            get
            {
                // Concurrent safe check.
                // Assigning the event handler to another variable copies the handlers
                // because it's not an object reference.
                EventHandler<T> handler = EventHandler;
                return handler != null;
            }
        }

        /// <summary>
        /// Fires the event.
        /// </summary>
        /// <param name="e">The event args.</param>
        protected void OnEvent(T e)
        {
            // Fire event.
            // Concurrent safe.
            EventHandler<T> handler = EventHandler;
            handler?.Invoke(this, e);
        }

        /// <summary>
        /// Subscribes a listener to the event handler.
        /// </summary>
        /// <param name="eventHandler">The listener to subscribe.</param>
        public virtual void Subscribe(EventHandler<T> eventHandler)
        {
            EventHandler += eventHandler;
        }

        /// <summary>
        /// Unsubscribes a listener from the event handler.
        /// </summary>
        /// <param name="eventHandler">The listener to unsubscribe.</param>
        public virtual void Unsubscribe(EventHandler<T> eventHandler)
        {
            EventHandler -= eventHandler;
        }

        /// <summary>
        /// Update method.
        /// </summary>
        /// <param name="gameTime">Snapshot of elapsed time values.</param>
        public abstract void Update(GameTime gameTime);
    }
}
