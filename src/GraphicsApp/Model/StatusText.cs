namespace GraphicsApp.Model
{
    /// <summary>
    /// Represents area status text shape
    /// </summary>
    public class StatusText : Text
    {
        public const int CaptionHeight = 20;

        /// <summary>
        /// Create new instance with text value and parent Area
        /// </summary>
        /// <param name="value">Text value</param>
        /// <param name="area">Parent area</param>
        public StatusText(string value, Area area)
            : base(value, new Point(0, area.TopRight.Y - CaptionHeight), area.TopRight)
        {
        }

        /// <summary>
        /// Copy constructor
        /// </summary>
        /// <param name="shape">Sample status text</param>
        /// <param name="children">Children to assign</param>
        /// <param name="attributes">Attributes to assign</param>
        public StatusText(StatusText shape, IEnumerable<Shape> children, AttributeCollection attributes)
            : base(shape, children, attributes)
        {
        }
    }
}
