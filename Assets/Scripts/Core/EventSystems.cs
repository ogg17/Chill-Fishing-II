using System.Collections;
using Leopotam.EcsLite;
using TranslatableString;
using UnityEngine;
using UnityEngine.Rendering;

namespace Core
{
    public class EventSystems
    {
        private EcsSystems _changeLanguageSystems;
        private readonly EventsStorage _eventsStorage;
        public EventSystems(EcsWorld world, SceneData sceneData, EventsStorage eventsStorage)
        {
            _eventsStorage = eventsStorage;
            
            _changeLanguageSystems = new EcsSystems(world, sceneData);
            _changeLanguageSystems.Add(new ChangeLanguageSystem());
           // _changeLanguageSystems.Init();
           _eventsStorage.changeLanguage.AddListener(_changeLanguageSystems.Run);
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