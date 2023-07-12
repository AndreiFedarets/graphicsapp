using GraphicsApp.Model;

namespace GraphicsApp
{
    public sealed class ShapeIntersectionValidator : IAreaHandler
    {
        private readonly IShapeIntersectionCalculator _intersectionCalculator;

        public ShapeIntersectionValidator(IShapeIntersectionCalculator intersectionCalculator)
        {
            _intersectionCalculator = intersectionCalculator;
        }

        public Shape[] Handle(Shape[] shapes)
        {
            for (int i = 0; i < shapes.Length; i++)
            {
                var shape1 = shapes[i];
                for (int j = i + 1; j < shapes.Length; j++)
                {
                    var shape2 = shapes[j];
                    if (_intersectionCalculator.HaveIntersection(shape1, shape2))
                    {
                        throw new Exception($"Shapes under numbers #{i} and #{j} have itersection");
                    }
                }
            }

            return shapes;
        }
    }
}
