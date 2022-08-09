using System;
using Leopotam.EcsLite;
using UnityEngine;

namespace Core
{
    public class Core : MonoBehaviour
    {
        [SerializeField] private CoreStorage coreStorage;
        [SerializeField] private SceneData sceneData;

        private EcsWorld _world;
        private EcsSystems _systems;
        private EcsSystems _fixedSystems;
        
        void Start()
        {
            _world = new EcsWorld();
            _systems = new EcsSystems(_world, new WorldData {
                CoreStorage = coreStorage, SceneData = sceneData } );
            _fixedSystems = new EcsSystems(_world, _systems.GetShared<WorldData>());
            
            _systems
#if UNITY_EDITOR
                .Add (new Leopotam.EcsLite.UnityEditor.EcsWorldDebugSystem ())
#endif
                .Init();
        }

        private void Update()
        {
            _systems?.Run();
        }

        private void FixedUpdate()
        {
            _fixedSystems?.Run();
        }

        private void OnDestroy()
        {
            if (_systems != null) {
                _systems.Destroy();
                _systems = null;
            }

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
