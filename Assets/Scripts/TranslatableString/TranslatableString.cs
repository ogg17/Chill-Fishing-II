using CustomTypes;

namespace TranslatableString
{
    public class TranslatableString: CustomType<string>
    {
        private string _name;
        
        public void OnChangeLanguage(string value)
        {
            Value = value;
        }
    }
}