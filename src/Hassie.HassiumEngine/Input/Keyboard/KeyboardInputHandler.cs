using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hassie.HassiumEngine.Event;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace Hassie.HassiumEngine.Input
{
    /// <summary>
    /// Keyboard input handler.
    /// </summary>
    public class KeyboardInputHandler : AbstractEventHandler<KeyboardEvent>
    {
        private IList<Keys> keyboardState; // The last keyboard state.

        public override void Update(GameTime gameTime)
        {
            // Get current keyboard state.
            List<Keys> keys = Keyboard.GetState().GetPressedKeys().ToList();

            // Check if this is the first time the event is running and that keys were pressed.
            // If yes, instantly fire the event.
            if (keyboardState == null && keys.Count > 0)
            {
                // Store keyboard state.
                keyboardState = keys;

                // Fire event.
                OnEvent(new KeyboardEvent(keys, new List<Keys>()));
            }
            // Else if, keyboard state is null, no event has occurred, return.
            else if (keyboardState == null)
            {
                return;
            }
            else
            {
                // Create lists to hold newly pressed and released keys.
                List<Keys> pressedKeys = new List<Keys>();
                List<Keys> releasedKeys = new List<Keys>();

                // For each key pressed
                foreach (Keys key in keys)
                {
                    // If previous keyboard state does not contain key, add to pressed keys.
                    if (!keyboardState.Contains(key))
                    {
                        pressedKeys.Add(key);
                    }
                    // Else, remove from the previous keyboard state.
                    // This will leave us with keys which have been released, if any.
                    else
                    {
                        keyboardState.Remove(key);
                    }
                }

                // Set released keys list to keyboard state list.
                // We use toList even though it's already a list, 
                // because we don't want to pass the reference to the keyboard state, rather a copy of the list.
                releasedKeys = keyboardState.ToList();

                // Store new keyboard state.
                keyboardState = keys;

                // If pressed keys or released keys > 0, then fire event.
                if (pressedKeys.Count > 0 || releasedKeys.Count > 0)
                {
                    // Fire event.
                    OnEvent(new KeyboardEvent(pressedKeys, releasedKeys));
                }
            }
        }
    }
}
