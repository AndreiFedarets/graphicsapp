namespace GraphicsApp.Model
{
    /// <summary>
    /// Represents rectangle shape
    /// </summary>
    public class Rectangle : Shape
    {
        /// <summary>
        /// Create new instance with two diagonal points
        /// </summary>
        /// <param name="p1">First point</param>
        /// <param name="p2">Second point</param>
        public Rectangle(Point p1, Point p2)
            : base()
        {
            // check that points are correct and were passed
            // in the correct order, if not - correct them
            int minX = Math.Min(p1.X, p2.X);
            int minY = Math.Min(p1.Y, p2.Y);
            BottomLeft = new Point(minX, minY);

            int maxX = Math.Max(p1.X, p2.X);
            int maxY = Math.Max(p1.Y, p2.Y);
            TopRight = new Point(maxX, maxY);
        }

        /// <summary>
        /// Copy constructor
        /// </summary>
        /// <param name="rectangle">Sample rectangle</param>
        /// <param name="children">Children to assign</param>
        /// <param name="attributes">Attributes to assign</param>
        public Rectangle(Rectangle rectangle, IEnumerable<Shape> children, AttributeCollection attributes)
            : base(children, attributes)
        {
            BottomLeft = rectangle.BottomLeft;
            TopRight = rectangle.TopRight;
        }

        public Point BottomLeft { get; }

        public Point TopRight { get; }

        public int Height
        {
            get { return TopRight.Y - BottomLeft.Y; }
        }

        public int Width
        {
            get { return TopRight.X - BottomLeft.X; }
        }

        /// <inheritdoc />
        public override bool ContainsPoint(Point point)
        {
            return point.X >= BottomLeft.X && point.X <= TopRight.X && 
                   point.Y >= BottomLeft.Y && point.Y <= TopRight.Y;
        }

        /// <inheritdoc />
        public override double GetArea()
        {
            return Height * Width;
        }

        /// <inheritdoc />
        public override Rectangle GetBounds()
        {
            return this;
        }
    }
}
