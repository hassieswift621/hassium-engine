using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hassie.HassiumEngine.Input
{
    /// <summary>
    /// Keyboard event.
    /// </summary>
    public class KeyboardEvent : EventArgs
    {
        /// <summary>
        /// A list of pressed keys.
        /// </summary>
        public IReadOnlyList<Keys> PressedKeys { get; }

        /// <summary>
        /// A list of released keys.
        /// </summary>
        public IReadOnlyList<Keys> ReleasedKeys { get; }

        /// <summary>
        /// Constructor for the keyboard event.
        /// </summary>
        /// <param name="pressedKeys">A list of keys which have been pressed.</param>
        /// <param name="releasedKeys">A list of keys which have been released.</param>
        public KeyboardEvent(IReadOnlyList<Keys> pressedKeys, IReadOnlyList<Keys> releasedKeys)
        {
            // Store pressed and released keys.
            PressedKeys = pressedKeys;
            ReleasedKeys = releasedKeys;
        }
    }
}
