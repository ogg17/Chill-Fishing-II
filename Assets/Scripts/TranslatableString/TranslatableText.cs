using TMPro;
using UnityEngine;

namespace TranslatableString
{
   public class TranslatableText: MonoBehaviour
    {
        public string valueName = "unnamed";

        private TMP_Text _textUI;

        public void OnChangeLanguage(string value)
        {
            if (!TryGetComponent(typeof(TextMeshPro), out Component textComponent))
                _textUI = GetComponent<TextMeshProUGUI>();
            else _textUI = textComponent as TMP_Text;
            _textUI!.text = value;
        }
    }
}