namespace GraphicsApp.Model
{
    public class Rectangle : Shape
    {
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

        public override bool ContainsPoint(Point point)
        {
            return point.X >= BottomLeft.X && point.X <= TopRight.X && 
                   point.Y >= BottomLeft.Y && point.Y <= TopRight.Y;
        }

        public override double GetArea()
        {
            int height = TopRight.Y - BottomLeft.Y;
            int width = TopRight.X - BottomLeft.X;
            return height * width;
        }

        public override Rectangle GetBounds()
        {
            return this;
        }
    }
}
