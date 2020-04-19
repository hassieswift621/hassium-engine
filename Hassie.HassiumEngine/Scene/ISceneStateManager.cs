using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hassie.HassiumEngine.Scene
{
    /// <summary>
    /// An interface for a scene state manager.
    /// The scene state manager allows scene states to be changed.
    /// </summary>
    public interface ISceneStateManager
    {
        /// <summary>
        /// Pauses a scene.
        /// A paused scene is continued to be rendered but is not updated.
        /// </summary>
        /// <param name="id">The ID of the scene.</param>
        void PauseScene(int id);

        /// <summary>
        /// Runs a scene.
        /// </summary>
        /// <param name="id">The ID of the scene.</param>
        /// <param name="initialise">Whether to intialise the scene.</param>
        void RunScene(int id, bool initialise);

        /// <summary>
        /// Stops a scene.
        /// A stopped scene is not rendered nor updated.
        /// </summary>
        /// <param name="id">The ID of the scene.</param>
        void StopScene(int id);
    }
}
