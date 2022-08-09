using Leopotam.EcsLite;
using UnityEngine;

namespace TranslatableString
{
    public class ChangeLanguageInitSystem: IEcsInitSystem
    {
        public void Init(IEcsSystems systems)
        {
            var textObjects = Object.FindObjectsOfType<TranslatableText>();

            var world = systems.GetWorld();
            var translatablePool = world.GetPool<TranslatableTextComponent>();

            foreach (var textObject in textObjects)
            {
                var translatableTextEntity = world.NewEntity();
                ref TranslatableTextComponent textComponent = ref translatablePool.Add(translatableTextEntity);
                textComponent.TranslatableText = textObject;
            }
        }
    }
}