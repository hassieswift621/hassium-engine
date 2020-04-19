using Hassie.HassiumEngine.System;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hassie.HassiumEngine.Render
{
    /// <summary>
    /// Render order change event.
    /// </summary>
    public class RenderOrderChangeEvent : EventArgs
    {
        public IEntity Entity { get; }

        public RenderOrderChangeEvent(IEntity entity)
        {
            Entity = entity;
        }
    }
}
