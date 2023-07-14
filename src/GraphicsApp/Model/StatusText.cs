namespace GraphicsApp.Model
{
    public class StatusText : Text
    {
        public const int CaptionHeight = 20;

        public StatusText(string value, Area area)
            : base(value, new Point(0, area.TopRight.Y - CaptionHeight), area.TopRight)
        {
        }

        public StatusText(StatusText shape, IEnumerable<Shape> children, AttributeCollection attributes)
            : base(shape, children, attributes)
        {
        }
    }
}
