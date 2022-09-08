using Animations;
using UnityEngine;
using UnityEngine.Serialization;

namespace Core
{
    public class SceneData: MonoBehaviour
    {
        public SceneContext sceneContext;
        [FormerlySerializedAs("gameNameAnimation")] public GameNameAnimationScript gameNameAnimationScript;
    }
}