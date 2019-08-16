using Hassie.HassiumEngine.System;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hassie.HassiumEngine.Scene
{
    /// <summary>
    /// An interface for a scene manager.
    /// The scene manager allows entities and scenes to be added and removed.
    /// </summary>
    public interface ISceneManager
    {
        /// <summary>
        /// Adds an entity to a scene.
        /// </summary>
        /// <param name="sceneId">The ID of the scene.</param>
        /// <param name="entity">The entity to add.</param>
        void AddEntity(int sceneId, IEntity entity);

        /// <summary>
        /// Adds a scene to the scene manager.
        /// </summary>
        /// <param name="id">The ID of the scene.</param>
        /// <param name="scene">The scene to add.</param>
        void AddScene(int id, IScene scene);

        /// <summary>
        /// Removes an entity from the scene.
        /// </summary>
        /// <param name="id">The ID of the entity.</param>
        void RemoveEntity(int id);

        /// <summary>
        /// Removes a scene from the scene manager.
        /// </summary>
        /// <param name="id">The ID of the scene.</param>
        void RemoveScene(int id);
    }
}
