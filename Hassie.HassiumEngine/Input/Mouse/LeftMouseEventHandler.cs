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
    /// Left mouse button event handler.
    /// </summary>
    public class LeftMouseEventHandler : AbstractEventHandler<LeftMouseEvent>
    {
        private LeftMouseEvent state; // The current state.

        public override void Subscribe(EventHandler<LeftMouseEvent> eventHandler)
        {
            // Call base subscribe.
            base.Subscribe(eventHandler);

            // Instantly fire event for the new subscriber if one has occurred.
            if (state != null) eventHandler(this, state);
        }

        public override void Unsubscribe(EventHandler<LeftMouseEvent> eventHandler)
        {
            // Call base unsubscribe.
            base.Unsubscribe(eventHandler);

            // If listeners are none, reset state.
            if (!HasListeners) state = null;
        }

        public override void Update(GameTime gameTime)
        {
            // Only update if there are listeners.
            if (!HasListeners) return;

            // Get mouse state.
            MouseState mouseState = Mouse.GetState();

            // Check if this is the first time the event is running and that the button has been clicked.
            // If yes, instantly fire the event.
            if (state == null && mouseState.LeftButton == ButtonState.Pressed)
            {
                // Store state.
                state = new LeftMouseEvent(mouseState.Position.ToVector2(), ButtonState.Pressed);

                // Fire event.
                OnEvent(state);
            }
            // Else if state is null, no event has occurred, return.
            else if (state == null) return;
            else
            {
                // Check if button has been pressed and that the previous state is released.
                if (state.State == ButtonState.Released && mouseState.LeftButton == ButtonState.Pressed)
                {
                    // Store state.
                    state = new LeftMouseEvent(mouseState.Position.ToVector2(), ButtonState.Pressed);

                    // Fire event.
                    OnEvent(state);
                }
                // Else, check if button has been released and the previous state is pressed.
                else if (state.State == ButtonState.Pressed && mouseState.LeftButton == ButtonState.Released)
                {
                    // Store state.
                    state = new LeftMouseEvent(null, ButtonState.Released);

                    // Fire event.
                    OnEvent(state);
                }
            }
        }
    }
}
