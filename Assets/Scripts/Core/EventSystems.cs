using System.Collections;
using Animations;
using Leopotam.EcsLite;
using TranslatableString;
using UnityEngine;
using UnityEngine.Rendering;

namespace Core
{
    public class EventSystems
    {
        private EcsSystems _changeLanguageSystems;
        private EcsSystems _finishedSplashScreenSystems;
        private readonly CoreStorage _coreStorage;
        public EventSystems(EcsWorld world, SceneData sceneData, CoreStorage coreStorage)
        {
            _coreStorage = coreStorage;
            
            _changeLanguageSystems = new EcsSystems(world, new WorldData
            { CoreStorage = coreStorage, SceneData = sceneData });
            _changeLanguageSystems.Add(new ChangeLanguageSystem());
            _changeLanguageSystems.Init();
            _coreStorage.eventsStorage.changeLanguage.AddListener(_changeLanguageSystems.Run);

            _finishedSplashScreenSystems = new EcsSystems(world, new WorldData
            { CoreStorage = coreStorage, SceneData = sceneData });
            _finishedSplashScreenSystems.Add(new AnimationInitSystem());
            _finishedSplashScreenSystems.Init();
            _coreStorage.eventsStorage.finishedSplashScreen.AddListener(_finishedSplashScreenSystems.Run);
        }

        public void Destroy()
        {
            if (_changeLanguageSystems != null) 
            {
                _changeLanguageSystems.Destroy();
                _changeLanguageSystems = null;
            }

            if (_finishedSplashScreenSystems != null)
            {
                _finishedSplashScreenSystems.Destroy();
                _finishedSplashScreenSystems = null;
            }
        }
    }
}