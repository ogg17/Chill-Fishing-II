using System.Collections;
using Leopotam.EcsLite;
using TranslatableString;
using UnityEngine;
using UnityEngine.Rendering;

namespace Core
{
    public class Core : MonoBehaviour
    {
        [SerializeField] private CoreStorage coreStorage;
        [SerializeField] private SceneData sceneData;

        private EcsWorld _world;
        private EcsSystems _systems;
        private EcsSystems _fixedSystems;
        private EventSystems _eventSystems;
        
        void Start()
        {
            coreStorage.settingsStorage.events = coreStorage.eventsStorage;
            coreStorage.textStorage.settingsStorage = coreStorage.settingsStorage;
            
            _world = new EcsWorld();
            
            _systems = new EcsSystems(_world, new WorldData {
                CoreStorage = coreStorage, SceneData = sceneData } );
            _systems
#if UNITY_EDITOR
                .Add (new Leopotam.EcsLite.UnityEditor.EcsWorldDebugSystem ())
#endif
                .Add(new ChangeLanguageInitSystem())
                .Init();

            _fixedSystems = new EcsSystems(_world, _systems.GetShared<WorldData>());
            
            Initialization();
        }

        private void Initialization()
        {
            _eventSystems = new EventSystems(_world, sceneData, coreStorage.eventsStorage);
            StartCoroutine(EndSplashScreen());

            coreStorage.eventsStorage.finishedSplashScreen.AddListener(sceneData.gameNameAnimation.OnFinishedSplashScreen);
        }

        private void Update()
        {
           // _systems?.Run();
        }

        private void FixedUpdate()
        {
           // _fixedSystems?.Run();
        }

        private IEnumerator EndSplashScreen()
        {
            yield return new WaitUntil(() => SplashScreen.isFinished);
            coreStorage.eventsStorage.finishedSplashScreen.Invoke();
        }
        
        private void OnDestroy()
        {
            if (_systems != null) {
                _systems.Destroy();
                _systems = null;
            }
            
            _eventSystems.Destroy();

            if (_fixedSystems != null)
            {
                _fixedSystems.Destroy();
                _fixedSystems = null;
            }
            
            if (_world != null) {
                _world.Destroy();
                _world = null;
            }
        }
    }
}
