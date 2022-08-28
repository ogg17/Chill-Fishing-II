using UnityEngine;
using UnityEngine.Events;

namespace Core
{
    [CreateAssetMenu(fileName = nameof(EventsStorage), menuName = "Storages/" + nameof(EventsStorage))]
    public class EventsStorage: ScriptableObject
    {
        public UnityEvent changeLanguage = new UnityEvent();
        public UnityEvent finishedSplashScreen = new UnityEvent();
    }
}