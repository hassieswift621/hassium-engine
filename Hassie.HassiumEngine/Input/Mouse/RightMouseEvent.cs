using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hassie.HassiumEngine.Input
{
    /// <summary>
    /// Right mouse button event.
    /// </summary>
    public class RightMouseEvent : EventArgs
    {
        /// <summary>
        /// The position of the mouse button click.
        /// </summary>
        public Vector2? Position { get; }

        /// <summary>
        /// The state of the mouse button.
        /// </summary>
        public ButtonState State { get; }

        /// <summary>
        /// Constructor for the right mouse button event.
        /// </summary>
        /// <param name="position">The position of the mouse button click.</param>
        /// <param name="state">The state of the mouse button.</param>
        public RightMouseEvent(Vector2? position, ButtonState state)
        {
            Position = position;
            State = state;
        }
    }
}
