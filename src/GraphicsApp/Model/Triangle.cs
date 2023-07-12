namespace GraphicsApp.Model
{
    public class Triangle : Shape
    {
        public Triangle(Point p1, Point p2, Point p3, IEnumerable<Shape> children = null)
            : base(children)
        {
            P1 = p1;
            P2 = p2;
            P3 = p3;
        }

        public Point P1 { get; }

        public Point P2 { get; }

        public Point P3 { get; }

        public override bool ContainsPoint(Point point)
        {
            Triangle t1 = new Triangle(point, P1, P2);
            Triangle t2 = new Triangle(point, P2, P3);
            Triangle t3 = new Triangle(point, P3, P1);

            double sampleArea = GetArea();
            double splitArea = t1.GetArea() + t2.GetArea() + t3.GetArea();

            return Math.Abs(sampleArea - splitArea) <= double.Epsilon;
        }

        public override double GetArea()
        {
            return Math.Abs(P1.X * (P2.Y - P3.Y) + P2.X * (P3.Y - P1.Y) + P3.X * (P1.Y - P2.Y)) / 2;
        }

        public override Rectangle GetBounds()
        {
            int minX = Math.Min(P1.X, Math.Min(P2.X, P3.X));
            int minY = Math.Min(P1.Y, Math.Min(P2.Y, P3.Y));
            Point bottomLeft = new Point(minX, minY);

            int maxX = Math.Max(P1.X, Math.Max(P2.X, P3.X));
            int maxY = Math.Max(P1.Y, Math.Max(P2.Y, P3.Y));
            Point topRight = new Point(maxX, maxY);

            return new Rectangle(bottomLeft, topRight);
        }

        public override Shape AssignChildren(IEnumerable<Shape> children)
        {
            return new Triangle(P1, P2, P3, children)
            {
                Tag = Tag
            };
        }
    }
}
