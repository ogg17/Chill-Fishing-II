using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Core
{
    [CreateAssetMenu(fileName = nameof(SceneSettings), menuName = "Storages/" + nameof(SceneSettings))]
    public class SceneSettings: ScriptableObject
    {
        public float startDelay = 1f;
        public float logoAnimEnd = 7f;
        public float gameNameAnimDelay = 1f;
    }
}