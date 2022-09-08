using System;
using System.Collections;
using System.Collections.Generic;
using Core;
using DG.Tweening;
using Leopotam.EcsLite;
using UnityEngine;

namespace Animations
{
    public class AnimationInitSystem: IEcsRunSystem
    {
        private List<IAnimatable> animations;
        public void Run(IEcsSystems systems)
        {
            var world = systems.GetWorld();
            var data = systems.GetShared<WorldData>();

            var mainAnimSequence = DOTween.Sequence().SetDelay(0);

            animations = new List<IAnimatable>
            {
                UnityEngine.Object.FindObjectOfType<PlatformAnimationScript>(),
                UnityEngine.Object.FindObjectOfType<GameNameAnimationScript>(),
                UnityEngine.Object.FindObjectOfType<ShaderTransition>(),
                UnityEngine.Object.FindObjectOfType<LogoAnimation>(),
            };

            //data.SceneData.sceneContext.StartCoroutine(AnimationOrder(data));
            Debug.Log(data);
            data.SceneData.sceneContext.StartCoroutine(AnimationOrder(data));
        }

        private IEnumerator AnimationOrder(WorldData data)
        {
            var sceneSettings = data.CoreStorage.sceneSettings;
            yield return new WaitForSeconds(sceneSettings.startDelay);
            animations[3].StartAnim();
            animations[2].StartAnim();
            yield return new WaitForSeconds(sceneSettings.logoAnimEnd);
            animations[0].StartAnim();
            yield return new WaitForSeconds(sceneSettings.gameNameAnimDelay);
            animations[1].StartAnim();
        }
    }
}