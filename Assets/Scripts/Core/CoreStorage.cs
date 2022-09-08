using TranslatableString;
using UnityEngine;

namespace Core
{
    [CreateAssetMenu(fileName = nameof(CoreStorage), menuName = "Storages/" + nameof(CoreStorage))]
    public class CoreStorage: ScriptableObject
    {
        public TextStorage textStorage;
        public SettingsStorage settingsStorage;
        public EventsStorage eventsStorage;
        public SceneSettings sceneSettings;
    }
}