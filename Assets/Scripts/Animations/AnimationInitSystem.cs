using System;
using System.Collections.Generic;
using Core;
using DG.Tweening;
using Leopotam.EcsLite;
using Object = UnityEngine.Object;

namespace Animations
{
    public class AnimationInitSystem: IEcsInitSystem
    {
        public void Init(IEcsSystems systems)
        {
            var world = systems.GetWorld();
            var data = systems.GetShared<WorldData>();

            var mainAnimSequence = DOTween.Sequence().SetDelay(0);

            List<IAnimatable> animations = new List<IAnimatable>
            {
                Object.FindObjectOfType<PlatformAnimationScript>(),
                Object.FindObjectOfType<GameNameAnimationScript>(),
            };

            foreach (var animatable in animations)
            {
                mainAnimSequence.Insert(1, animatable.StartAnim());
            }

            
        }
    }
}