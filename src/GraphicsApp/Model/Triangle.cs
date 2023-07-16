namespace GraphicsApp.Model
{
    /// <summary>
    /// Represents triangle shape
    /// </summary>
    public class Triangle : Shape
    {
        /// <summary>
        /// Create new instance with two 3 points
        /// </summary>
        /// <param name="p1">First point</param>
        /// <param name="p2">Second point</param>
        /// <param name="p3">Third point</param>
        public Triangle(Point p1, Point p2, Point p3)
            : base()
        {
            P1 = p1;
            P2 = p2;
            P3 = p3;
        }

        /// <summary>
        /// Copy constructor
        /// </summary>
        /// <param name="triangle">Sample triangle</param>
        /// <param name="children">Children to assign</param>
        /// <param name="attributes">Attributes to assign</param>
        public Triangle(Triangle triangle, IEnumerable<Shape> children, AttributeCollection attributes)
            : base(children, attributes)
        {
            P1 = triangle.P1;
            P2 = triangle.P2;
            P3 = triangle.P3;
        }

        public Point P1 { get; }

        public Point P2 { get; }

        public Point P3 { get; }

        /// <inheritdoc />
        public override bool ContainsPoint(Point point)
        {
            // idea: create 3 triangles each of them has one checking point and 2 other points from the current triangle

            // calculate area of the current triangle
            double sampleArea = GetArea();
            // calculate area of 'split' triangles
            double splitArea = GetArea(point, P1, P2) + GetArea(point, P2, P3) + GetArea(point, P3, P1);

            // if area of split-triangles is the same as the area of the current triangle, then the point is located inside
            return Math.Abs(splitArea - sampleArea) <= double.Epsilon;
        }

        /// <inheritdoc />
        public override double GetArea()
        {
            return GetArea(P1, P2, P3);
        }

        /// <inheritdoc />
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

        private static double GetArea(Point p1, Point p2, Point p3)
        {
            return (double)Math.Abs(p1.X * (p2.Y - p3.Y) + p2.X * (p3.Y - p1.Y) + p3.X * (p1.Y - p2.Y)) / 2;
        }
    }
}
