using GraphicsApp.Model;

namespace GraphicsApp
{
    /// <summary>
    /// Represents intersection calculator for Triangle-Triangle pair
    /// </summary>
    public sealed class TriangleIntersectionCalculator : IShapeIntersectionCalculator
    {
        /// <inheritdoc/>
        public bool HaveIntersection(Shape shape1, Shape shape2)
        {
            Triangle t1 = (Triangle)shape1;
            Point[] points1 = new [] { t1.P1, t1.P2, t1.P3 };
            Triangle t2 = (Triangle)shape2;
            Point[] points2 = new[] { t2.P1, t2.P2, t2.P3 };

            return points1.Any(t2.ContainsPoint) && points1.Any(p => !t2.ContainsPoint(p)) ||
                   points2.Any(t1.ContainsPoint) && points2.Any(p => !t1.ContainsPoint(p));
        }

        /// <inheritdoc/>
        public bool IsIncluded(Shape child, Shape parent)
        {
            Triangle childTriangle = (Triangle)child;
            Triangle parentTriangle = (Triangle)parent;

            return parentTriangle.ContainsPoint(childTriangle.P1) &&
                   parentTriangle.ContainsPoint(childTriangle.P2) &&
                   parentTriangle.ContainsPoint(childTriangle.P3);
        }

        /// <inheritdoc/>
        public bool Supports(Shape shape1, Shape shape2)
        {
            return shape1 is Triangle && shape2 is Triangle;
        }
    }
}
