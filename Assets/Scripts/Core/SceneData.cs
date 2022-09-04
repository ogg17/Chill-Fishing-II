using Animations;
using UnityEngine;
using UnityEngine.Serialization;

namespace Core
{
    public class SceneData: MonoBehaviour
    {
        public GameObject sceneContext;
        [FormerlySerializedAs("gameNameAnimation")] public GameNameAnimationScript gameNameAnimationScript;
    }
}