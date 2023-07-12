namespace GraphicsApp
{
    public class ShapeIntersectionCalculatorBuilder
    {
        private List<IShapeIntersectionCalculator> _calculators;

        public ShapeIntersectionCalculatorBuilder()
        {
            _calculators = new List<IShapeIntersectionCalculator>();
        }

        public ShapeIntersectionCalculatorBuilder Add<T>() where T : IShapeIntersectionCalculator, new ()
        {
            T instance = (T)Activator.CreateInstance(typeof(T));
            return Add(instance);
        }

        public ShapeIntersectionCalculatorBuilder Add<T>(T instance) where T : IShapeIntersectionCalculator
        {
            _calculators.Add(instance);
            return this;
        }

        public IShapeIntersectionCalculator Build()
        {
            return new CommonShapeIntersectionCalculator(_calculators);
        }
    }
}
