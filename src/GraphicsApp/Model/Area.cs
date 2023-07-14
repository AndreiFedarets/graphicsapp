namespace GraphicsApp.Model
{
    public class Area : Rectangle
    {
        public Area(Point p1, Point p2)
            : base(p1, p2)
        {
        }

        public Area(IEnumerable<Shape> shapes)
            : base(CalculateBoundRectangle(shapes), shapes, new AttributeCollection())
        {
        }

        public Area(Area area, IEnumerable<Shape> children, AttributeCollection attributes)
            : base(area, children, attributes)
        {
        }

        private static Rectangle CalculateBoundRectangle(IEnumerable<Shape> children)
        {
            Rectangle[] bounds = children.Select(x => x.GetBounds()).ToArray();
            if (bounds.Length == 0)
            {
                return new Rectangle(Point.Zero, Point.Zero);
            }

            int minX = bounds.Min(x => x.BottomLeft.X);
            int minY = bounds.Min(x => x.BottomLeft.Y);
            Point bottomLeft = new Point(minX, minY);

            int maxX = bounds.Max(x => x.TopRight.X);
            int maxY = bounds.Max(x => x.TopRight.Y);
            Point topRight = new Point(maxX, maxY);

            return new Rectangle(bottomLeft, topRight);
        }
    }
}
