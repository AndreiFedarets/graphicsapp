namespace GraphicsApp.Model
{
    /// <summary>
    /// Represents text shape
    /// </summary>
    public class Text : Rectangle
    {
        public Text(string value, Point p1, Point p2)
            : base(p1, p2)
        {
            Value = value;
        }

        /// <summary>
        /// Copy constructor
        /// </summary>
        /// <param name="text">Sample text</param>
        /// <param name="children">Children to assign</param>
        /// <param name="attributes">Attributes to assign</param>
        public Text(Text text, IEnumerable<Shape> children, AttributeCollection attributes)
            : base(text, children, attributes)
        {
            Value = text.Value;
        }

        public string Value { get; }
    }
}
