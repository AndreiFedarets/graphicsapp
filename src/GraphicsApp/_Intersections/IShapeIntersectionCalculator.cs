using GraphicsApp.Model;

namespace GraphicsApp
{
    public interface IShapeIntersectionCalculator
    {
        bool Supports(Shape shape1, Shape shape2);

        bool HaveIntersection(Shape shape1, Shape shape2);

        bool IsIncluded(Shape child, Shape parent);
    }
}
