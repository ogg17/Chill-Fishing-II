using TMPro;
using UnityEngine;

namespace TranslatableString
{
    [RequireComponent(typeof(TextMeshProUGUI))]
    public class TranslatableText: MonoBehaviour
    {
        public string valueName = "unnamed";

        private TextMeshProUGUI _text;

        public void OnChangeLanguage(string value)
        {
            if (_text == null) _text = GetComponent<TextMeshProUGUI>();
            _text.text = value;
        }
    }
}