using GraphicsApp.Model;
using System.Collections.Immutable;

namespace GraphicsApp
{
    public sealed class CommonShapeIntersectionCalculator : IShapeIntersectionCalculator
    {
        private ImmutableList<IShapeIntersectionCalculator> _calculators;

        public CommonShapeIntersectionCalculator(IEnumerable<IShapeIntersectionCalculator> calculators)
        {
            _calculators = ImmutableList.CreateRange(calculators);
        }

        public bool HaveIntersection(Shape shape1, Shape shape2)
        {
            if (shape1 == null)
            {
                throw new ArgumentNullException(nameof(shape1));
            }
            if (shape2 == null)
            {
                throw new ArgumentNullException(nameof(shape2));
            }

            var calculator = _calculators.Find(validator => validator.Supports(shape1, shape2));
            if (calculator == null)
            {
                throw new Exception($"Combination of shape types {shape1.GetType().Name} and {shape2.GetType().Name} is not supported");
            }

            return calculator.HaveIntersection(shape1, shape2);
        }

        public bool Supports(Shape shape1, Shape shape2)
        {
            return _calculators.Find(validator => validator.Supports(shape1, shape2)) != null;
        }
    }
}
