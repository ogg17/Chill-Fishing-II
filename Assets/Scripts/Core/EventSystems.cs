using Leopotam.EcsLite;
using TranslatableString;

namespace Core
{
    public class EventSystems
    {
        private EcsSystems _changeLanguageSystems;
        public EventSystems(EcsWorld world, SceneData sceneData, EventsStorage eventsStorage)
        {
            _changeLanguageSystems = new EcsSystems(world, sceneData);
            _changeLanguageSystems.Add(new ChangeLanguageSystem());
           // _changeLanguageSystems.Init();
            eventsStorage.changeLanguage.AddListener(_changeLanguageSystems.Run);
        }

        public void Destroy()
        {
            if (_changeLanguageSystems != null) {
                _changeLanguageSystems.Destroy();
                _changeLanguageSystems = null;
            }
        }
    }
}