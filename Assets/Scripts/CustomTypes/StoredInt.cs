using Core;

namespace CustomTypes
{
    public class StoredInt: CustomType<int>
    {
        private StoredInt(int value) : base(value) {}

        public void Load()
        {
            throw new System.NotImplementedException();
        }

        public void Save()
        {
            throw new System.NotImplementedException();
        }
    }
}