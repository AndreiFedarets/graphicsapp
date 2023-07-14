namespace GraphicsApp.Model
{
    public class Text : Rectangle
    {
        public Text(string value, Point p1, Point p2)
            : base(p1, p2)
        {
            Value = value;
        }

        public Text(Text text, IEnumerable<Shape> children, AttributeCollection attributes)
            : base(text, children, attributes)
        {
            Value = text.Value;
        }

        public string Value { get; }
    }
}
