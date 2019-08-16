using Hassie.HassiumEngine.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hassie.HassiumEngine.Event
{
    /// <summary>
    /// An interface for an event listener.
    /// </summary>
    /// <typeparam name="T">The type of event received.</typeparam>
    public interface IEventListener<T> where T : EventArgs
    {
        /// <summary>
        /// On event method.
        /// </summary>
        /// <param name="sender">The event sender.</param>
        /// <param name="e">The event args.</param>
        void OnEvent(object sender, T e);
    }
}