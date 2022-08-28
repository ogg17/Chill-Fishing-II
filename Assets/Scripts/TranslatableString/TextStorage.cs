using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using Core;
using Newtonsoft.Json;
using Unity.VisualScripting;
using UnityEngine;
using Debug = UnityEngine.Debug;

namespace TranslatableString
{
    [CreateAssetMenu(fileName = nameof(TextStorage), menuName = "Storages/" + nameof(TextStorage))]
    public class TextStorage: ScriptableObject
    {
        [SerializeField] private string textFolder;

        [SerializeField] private string englishFile = "En_us";
        [SerializeField] private string russianFile = "Ru_ru";
        private Dictionary<string, string> _english;
        private Dictionary<string, string> _russian;

        [HideInInspector] public SettingsStorage settingsStorage;

        private Dictionary<string, string> Text
        {
            get
            {
                switch(settingsStorage.Language)
                {
                    case SystemLanguage.Russian:
                        if (_russian == null)
                            _russian = GetDictionary(russianFile);
                        return _russian;
                    default:
                        if (_english == null)
                            _english = GetDictionary(englishFile);
                        return _english;
                }
            }
        }

        private Dictionary<string, string> GetDictionary(string file)
        {
            var json = Resources.Load<TextAsset>(Path.Combine(textFolder, file)).text;
            var dictionary = JsonConvert.DeserializeObject<Dictionary<string, string>>(json);
            if (dictionary == null) Debug.Log("Json not load!");
            return dictionary;
        }

        public string GetValue(string valueName)
        {
            if (Text.TryGetValue(valueName, out var value))
                return value;
            if (_english.TryGetValue(valueName, out value))
                return value;
            return "NoN";
        }
    }
}