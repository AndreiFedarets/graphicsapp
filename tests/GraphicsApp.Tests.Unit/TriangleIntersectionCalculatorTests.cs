using GraphicsApp.Model;

namespace GraphicsApp.Tests.Unit
{
    public class TriangleIntersectionCalculatorTests
    {
        #region Supports

        [Fact]
        public void Supports_ReturnsTrue_ForTriangleAndTriangle()
        {
            var calculator = new TriangleIntersectionCalculator();
            var shape1 = new Triangle(Point.Zero, Point.Zero, Point.Zero);
            var shape2 = new Triangle(Point.Zero, Point.Zero, Point.Zero);
            Assert.True(calculator.Supports(shape1, shape2));
        }

        [Fact]
        public void Supports_ReturnsFalse_ForTriangleAndNull()
        {
            var calculator = new TriangleIntersectionCalculator();
            var shape = new Triangle(Point.Zero, Point.Zero, Point.Zero);
            Assert.False(calculator.Supports(shape, null));
        }

        [Fact]
        public void Supports_ReturnsFalse_ForNullAndTriangle()
        {
            var calculator = new TriangleIntersectionCalculator();
            var shape = new Triangle(Point.Zero, Point.Zero, Point.Zero);
            Assert.False(calculator.Supports(null, shape));
        }

        [Fact]
        public void Supports_ReturnsTrue_ForTriangleAndRectangle()
        {
            var calculator = new TriangleIntersectionCalculator();
            var shape1 = new Triangle(Point.Zero, Point.Zero, Point.Zero);
            var shape2 = new Rectangle(Point.Zero, Point.Zero);
            Assert.False(calculator.Supports(shape1, shape2));
        }

        #endregion

        #region HaveIntersection

        [Fact]
        public void HaveIntersection_ReturnsTrue_ForIntersectingTriangles()
        {
            var calculator = new TriangleIntersectionCalculator();
            var shape1 = new Triangle(new Point(0, 0), new Point(5, 10), new Point(10, 0));
            var shape2 = new Triangle(new Point(0, 1), new Point(5, 11), new Point(10, 1));
            Assert.True(calculator.HaveIntersection(shape1, shape2));
        }

        [Fact]
        public void HaveIntersection_ReturnsFalse_ForNonIntersectingTriangles()
        {
            var calculator = new TriangleIntersectionCalculator();
            var shape1 = new Triangle(new Point(0, 0), new Point(5, 10), new Point(10, 0));
            var shape2 = new Triangle(new Point(0, 20), new Point(5, 20), new Point(10, 20));
            Assert.False(calculator.HaveIntersection(shape1, shape2));
        }

        [Fact]
        public void HaveIntersection_ReturnsFalse_ForTouchingTriangles()
        {
            var calculator = new TriangleIntersectionCalculator();
            var shape1 = new Triangle(new Point(0, 0), new Point(5, 10), new Point(10, 0));
            var shape2 = new Triangle(new Point(0, 10), new Point(5, 20), new Point(10, 10));
            Assert.True(calculator.HaveIntersection(shape1, shape2));
        }

        #endregion

        #region IsIncluded

        [Fact]
        public void IsIncluded_ReturnsTrue_ForChildAndParent()
        {
            var calculator = new TriangleIntersectionCalculator();
            var parent = new Triangle(new Point(0, 0), new Point(5, 10), new Point(10, 0));
            var child = new Triangle(new Point(1, 1), new Point(5, 9), new Point(9, 1));
            Assert.True(calculator.IsIncluded(child, parent));
        }

        [Fact]
        public void IsIncluded_ReturnsFalse_ForReverseChildAndParent()
        {
            var calculator = new TriangleIntersectionCalculator();
            var parent = new Triangle(new Point(0, 0), new Point(5, 10), new Point(10, 0));
            var child = new Triangle(new Point(1, 1), new Point(5, 9), new Point(9, 1));
            Assert.False(calculator.IsIncluded(parent, child));
        }

        [Fact]
        public void IsIncluded_ReturnsFalse_ForIntersectingTriangles()
        {
            var calculator = new TriangleIntersectionCalculator();
            var parent = new Triangle(new Point(0, 0), new Point(5, 10), new Point(10, 0));
            var child = new Triangle(new Point(1, 1), new Point(5, 10), new Point(9, 1));
            Assert.False(calculator.IsIncluded(parent, child));
        }

        [Fact]
        public void IsIncluded_ReturnsFalse_ForFarTriangles()
        {
            var calculator = new TriangleIntersectionCalculator();
            var parent = new Triangle(new Point(0, 0), new Point(5, 10), new Point(10, 0));
            var child = new Triangle(new Point(0, 20), new Point(5, 30), new Point(10, 20));
            Assert.False(calculator.IsIncluded(parent, child));
        }

        #endregion
    }
}
