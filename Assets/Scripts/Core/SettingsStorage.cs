using UnityEngine;

namespace Core
{
    [CreateAssetMenu(fileName = nameof(SettingsStorage), menuName = "Storages/" + nameof(SettingsStorage))]
    public class SettingsStorage: ScriptableObject
    {
        [HideInInspector] public EventsStorage events;
        
        private SystemLanguage _language;
        public SystemLanguage Language
        {
            get => _language;
            set
            {
                _language = value;
                events.changeLanguage.Invoke();
            }
        }
    }
}