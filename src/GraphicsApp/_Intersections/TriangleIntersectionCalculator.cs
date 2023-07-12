using GraphicsApp.Model;

namespace GraphicsApp
{
    public sealed class TriangleIntersectionCalculator : IShapeIntersectionCalculator
    {
        public bool HaveIntersection(Shape shape1, Shape shape2)
        {
            Triangle t1 = (Triangle)shape1;
            Triangle t2 = (Triangle)shape2;

            return t1.Contains(t2.P1) || t1.Contains(t2.P2) || t1.Contains(t2.P3) ||
                   t2.Contains(t1.P1) || t2.Contains(t1.P2) || t2.Contains(t1.P3);
        }

        public bool Supports(Shape shape1, Shape shape2)
        {
            return shape1 is Triangle && shape2 is Triangle;
        }
    }
}
