using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hassie.HassiumEngine.Update
{
    /// <summary>
    /// IUpdatable interface.
    /// The interface allows an engine component to update.
    /// </summary>
    public interface IUpdatable
    {
        /// <summary>
        /// Update method.
        /// </summary>
        /// <param name="gameTime">Snapshot of elapsed time values.</param>
        void Update(GameTime gameTime);
    }
}
