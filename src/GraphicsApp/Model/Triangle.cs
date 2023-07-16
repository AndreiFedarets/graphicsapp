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
            // create 3 triangles each of them has one checking point and 2 other points from the current triangle
            Triangle t1 = new Triangle(point, P1, P2);
            Triangle t2 = new Triangle(point, P2, P3);
            Triangle t3 = new Triangle(point, P3, P1);

            // calculate area of the current triangle
            double sampleArea = GetArea();
            // calculate area of splitted triangles
            double splitArea = t1.GetArea() + t2.GetArea() + t3.GetArea();

            // if area of split-triangles is the same as area if the current triangle, then the point is located inside
            return Math.Abs(splitArea - sampleArea) <= double.Epsilon;
        }

        /// <inheritdoc />
        public override double GetArea()
        {
            return (double)Math.Abs(P1.X * (P2.Y - P3.Y) + P2.X * (P3.Y - P1.Y) + P3.X * (P1.Y - P2.Y)) / 2;
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
    }
}
