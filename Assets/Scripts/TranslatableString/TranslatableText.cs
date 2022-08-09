using TMPro;
using UnityEngine;

namespace TranslatableString
{
    [RequireComponent(typeof(TextMeshPro))]
    public class TranslatableText: MonoBehaviour
    {
        public string name = "unnamed";

        private TextMeshPro _text;

        public void OnChangeLanguage(string value)
        {
            if (_text == null) _text = GetComponent<TextMeshPro>();
            _text.text = value;
        }
    }
}