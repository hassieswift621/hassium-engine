using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hassie.HassiumEngine.Render
{
    /// <summary>
    /// An interface for a renderable which the order can change
    /// throughout the duration of the game.
    /// </summary>
    public interface IRenderOrderChangeable
    {
        /// <summary>
        /// Render order changed event.
        /// </summary>
        event EventHandler<RenderOrderChangeEvent> RenderOrderChanged;
    }
}