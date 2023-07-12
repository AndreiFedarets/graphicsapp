namespace GraphicsApp.Model
{
    public class Area : Rectangle
    {
        public Area(IEnumerable<Shape> shapes)
            : base(CalculateBottomLeftPoint(shapes), CalculateTopRightPoint(shapes), shapes)
        {
        }

        public override Shape AssignChildren(IEnumerable<Shape> children)
        {
            return new Area(children);
        }

        private static Point CalculateBottomLeftPoint(IEnumerable<Shape> children)
        {
            Rectangle[] bounds = children.Select(x => x.GetBounds()).ToArray();
            int minX = bounds.Min(x => x.BottomLeft.X);
            int minY = bounds.Min(x => x.BottomLeft.Y);
            return new Point(minX, minY);
        }

        private static Point CalculateTopRightPoint(IEnumerable<Shape> children)
        {
            Rectangle[] bounds = children.Select(x => x.GetBounds()).ToArray();
            int maxX = bounds.Max(x => x.TopRight.X);
            int maxY = bounds.Max(x => x.TopRight.Y);
            return new Point(maxX, maxY);
        }
    }
}
