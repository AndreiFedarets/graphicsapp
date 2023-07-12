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
            get { return _attributes[key]; }
            set { _attributes[key] = value; }
        }
    }
}
