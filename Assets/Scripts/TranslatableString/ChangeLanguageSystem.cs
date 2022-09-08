using Core;
using Leopotam.EcsLite;

namespace TranslatableString
{
    public class ChangeLanguageSystem: IEcsRunSystem
    {
        public void Run(IEcsSystems systems)
        {
            var world = systems.GetWorld();
            var data = systems.GetShared<WorldData>();

            EcsFilter filter = world.Filter<TranslatableTextComponent>().End();
            var translatablePool = world.GetPool<TranslatableTextComponent>();

            foreach (var entity in filter)
            {
                ref TranslatableTextComponent textComponent = ref translatablePool.Get(entity);
                textComponent.TranslatableText.OnChangeLanguage(data.CoreStorage
                    .textStorage.GetValue(textComponent.TranslatableText.valueName));
            }
        }
    }
}