using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hassie.HassiumEngine.Entity
{
    /// <summary>
    /// An interface for an entity terminator.
    /// An entity terminator is responsible for terminating entities.
    /// </summary>
    public interface IEntityTerminator
    {
        /// <summary>
        /// Terminates an entity.
        /// </summary>
        /// <param name="id">The ID of the entity.</param>
        void Terminate(int id);
    }
}
