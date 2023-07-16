namespace GraphicsApp.Model
{
    /// <summary>
    /// Represents collection of attributes
    /// </summary>
    public class AttributeCollection
    {
        private readonly Dictionary<string, object> _attributes;

        public AttributeCollection()
        {
            _attributes = new Dictionary<string, object>();
        }

        /// <summary>
        /// Get or set attribute value by key
        /// </summary>
        /// <param name="key">Attribute key</param>
        /// <returns>Attribute value or null if the attribute is missing</returns>
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
