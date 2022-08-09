using Core;
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
            var data = systems.GetShared<WorldData>();

            foreach (var textObject in textObjects)
            {
                var translatableTextEntity = world.NewEntity();
                ref TranslatableTextComponent textComponent = ref translatablePool.Add(translatableTextEntity);
                textComponent.TranslatableText = textObject;
                Debug.Log(textComponent.TranslatableText.valueName);
                textObject.OnChangeLanguage(data.CoreStorage
                    .textStorage.GetValue(textObject.valueName));
            }
        }
    }
}