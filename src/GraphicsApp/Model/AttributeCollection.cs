namespace GraphicsApp.Model
{
    public class AttributeCollection
    {
        private readonly Dictionary<string, object> _attributes;

        public AttributeCollection()
        {
            _attributes = new Dictionary<string, object>();
        }

        public object this[string key]
        {
            get
            {
                _attributes.TryGetValue(key, out object value);
                return value;
            }
            set { _attributes[key] = value; }
        }
    }
}
