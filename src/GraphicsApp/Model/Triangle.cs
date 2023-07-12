namespace GraphicsApp.Model
{
    public class Triangle : Shape
    {
        public Triangle(Point p1, Point p2, Point p3)
        {
            P1 = p1;
            P2 = p2;
            P3 = p3;
        }

        public Point P1 { get; }

        public Point P2 { get; }

        public Point P3 { get; }

        public override bool Contains(Point point)
        {
            //// Let's 'draw' 2 infinite-length lines from our point -
            //// to the left and to the right. If at least one of these
            //// lines have 0 intersections with the triangle edges
            //// then the point is located outside the triangle

            //var trianglePoints = new Point[] { P1, P2, P3 };

            //// check the 'left' line intesection
            //if (trianglePoints.Any(p => p.X <= point.X))
            //{

            //}


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
    }
}
