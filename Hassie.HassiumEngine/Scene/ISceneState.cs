using Hassie.HassiumEngine.System;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hassie.HassiumEngine.Scene
{
    /// <summary>
    /// An interface for a scene's state, allowing its state to be changed.
    /// </summary>
    public interface ISceneState
    {
        /// <summary>
        /// The current state of the scene.
        /// </summary>
        SceneState State { get; }

        /// <summary>
        /// Pauses the scene.
        /// A paused scene is continued to be rendered but is not updated.
        /// </summary>
        /// <returns>A list of entities in the scene.</returns>
        IReadOnlyList<IEntity> Pause();

        /// <summary>
        /// Runs the scene.
        /// </summary>
        /// <param name="initialise">Whether to initialise the scene.</param>
        /// <returns>A list of entities in the scene.</returns>
        IReadOnlyList<IEntity> Run(bool initialise);

        /// <summary>
        /// Stops the scene.
        /// A stopped scene is not rendered nor updated.
        /// </summary>
        /// <returns>A list of entities in the scene.</returns>
        IReadOnlyList<IEntity> Stop();
    }
}
