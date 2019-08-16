using Hassie.HassiumEngine.Update;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hassie.HassiumEngine.Event
{
    /// <summary>
    /// An interface for an event handler.
    /// An event handler allows listeners to subscribe and unsubscribe from it
    /// </summary>
    /// <typeparam name="T">The type of event received.</typeparam>
    public interface IEventHandler<T> : IUpdatable where T : EventArgs
    {
        /// <summary>
        /// Subscribes a listener to the event handler.
        /// </summary>
        /// <param name="eventHandler">The listener to subscribe.</param>
        void Subscribe(EventHandler<T> eventHandler);

        /// <summary>
        /// Unsubscribes a listener from the event handler.
        /// </summary>
        /// <param name="eventHandler">The listener to unsubscribe.</param>
        void Unsubscribe(EventHandler<T> eventHandler);
    }
}
