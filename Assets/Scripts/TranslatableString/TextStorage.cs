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
                        {
                            var json = Resources.Load<TextAsset>(Path.Combine(textFolder, russianFile)).text;
                            Debug.Log(json);
                            var dictionary = JsonConvert.DeserializeObject<Dictionary<string, string>>(json);
                            if (dictionary == null) Debug.Log("Json not load");
                            _russian = dictionary;
                        }
                        return _russian;
                    default:
                        return _english ??= JsonUtility.FromJson<Dictionary<string, string>>(
                            Resources.Load<TextAsset>($"{textFolder}/{englishFile}").text);
                }
            }
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