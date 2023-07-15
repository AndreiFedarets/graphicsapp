using GraphicsApp.Model;

namespace GraphicsApp.Tests.Unit
{
    public class TriangleIntersectionCalculatorTests
    {
        #region Supports

        [Fact]
        public void Supports_ReturnsTrue_ForTriangleAndTriangle()
        {
            // Arrange
            var calculator = new TriangleIntersectionCalculator();
            var shape1 = new Triangle(Point.Zero, Point.Zero, Point.Zero);
            var shape2 = new Triangle(Point.Zero, Point.Zero, Point.Zero);

            // Act
            bool result = calculator.Supports(shape1, shape2);

            // Assert
            Assert.True(result);
        }

        [Fact]
        public void Supports_ReturnsFalse_ForTriangleAndNull()
        {
            // Arrange
            var calculator = new TriangleIntersectionCalculator();
            var shape = new Triangle(Point.Zero, Point.Zero, Point.Zero);

            // Act
            bool result = calculator.Supports(shape, null);

            // Assert
            Assert.False(result);
        }

        [Fact]
        public void Supports_ReturnsFalse_ForNullAndTriangle()
        {
            // Arrange
            var calculator = new TriangleIntersectionCalculator();
            var shape = new Triangle(Point.Zero, Point.Zero, Point.Zero);

            // Act
            bool result = calculator.Supports(null, shape);

            // Assert
            Assert.False(result);
        }

        [Fact]
        public void Supports_ReturnsTrue_ForTriangleAndRectangle()
        {
            // Arrange
            var calculator = new TriangleIntersectionCalculator();
            var shape1 = new Triangle(Point.Zero, Point.Zero, Point.Zero);
            var shape2 = new Rectangle(Point.Zero, Point.Zero);

            // Act
            bool result = calculator.Supports(shape1, shape2);

            // Assert
            Assert.False(result);
        }

        #endregion

        #region HaveIntersection

        [Fact]
        public void HaveIntersection_ReturnsTrue_ForIntersectingTriangles()
        {
            // Arrange
            var calculator = new TriangleIntersectionCalculator();
            var shape1 = new Triangle(new Point(0, 0), new Point(5, 10), new Point(10, 0));
            var shape2 = new Triangle(new Point(0, 1), new Point(5, 11), new Point(10, 1));

            // Act
            bool result = calculator.HaveIntersection(shape1, shape2);

            // Assert
            Assert.True(result);
        }

        [Fact]
        public void HaveIntersection_ReturnsFalse_ForNonIntersectingTriangles()
        {
            // Arrange
            var calculator = new TriangleIntersectionCalculator();
            var shape1 = new Triangle(new Point(0, 0), new Point(5, 10), new Point(10, 0));
            var shape2 = new Triangle(new Point(0, 20), new Point(5, 20), new Point(10, 20));

            // Act
            bool result = calculator.HaveIntersection(shape1, shape2);

            // Assert
            Assert.False(result);
        }

        [Fact]
        public void HaveIntersection_ReturnsFalse_ForTouchingTriangles()
        {
            // Arrange
            var calculator = new TriangleIntersectionCalculator();
            var shape1 = new Triangle(new Point(0, 0), new Point(5, 10), new Point(10, 0));
            var shape2 = new Triangle(new Point(0, 10), new Point(5, 20), new Point(10, 10));

            // Act
            bool result = calculator.HaveIntersection(shape1, shape2);

            // Assert
            Assert.True(result);
        }

        #endregion

        #region IsIncluded

        [Fact]
        public void IsIncluded_ReturnsTrue_ForChildAndParent()
        {
            // Arrange
            var calculator = new TriangleIntersectionCalculator();
            var parent = new Triangle(new Point(0, 0), new Point(5, 10), new Point(10, 0));
            var child = new Triangle(new Point(1, 1), new Point(5, 9), new Point(9, 1));

            // Act
            bool result = calculator.IsIncluded(child, parent);

            // Assert
            Assert.True(result);
        }

        [Fact]
        public void IsIncluded_ReturnsFalse_ForReverseChildAndParent()
        {
            // Arrange
            var calculator = new TriangleIntersectionCalculator();
            var parent = new Triangle(new Point(0, 0), new Point(5, 10), new Point(10, 0));
            var child = new Triangle(new Point(1, 1), new Point(5, 9), new Point(9, 1));

            // Act
            bool result = calculator.IsIncluded(parent, child);

            // Assert
            Assert.False(result);
        }

        [Fact]
        public void IsIncluded_ReturnsFalse_ForIntersectingTriangles()
        {
            // Arrange
            var calculator = new TriangleIntersectionCalculator();
            var parent = new Triangle(new Point(0, 0), new Point(5, 10), new Point(10, 0));
            var child = new Triangle(new Point(1, 1), new Point(5, 10), new Point(9, 1));

            // Act
            bool result = calculator.IsIncluded(parent, child);

            // Assert
            Assert.False(result);
        }

        [Fact]
        public void IsIncluded_ReturnsFalse_ForFarTriangles()
        {
            // Arrange
            var calculator = new TriangleIntersectionCalculator();
            var parent = new Triangle(new Point(0, 0), new Point(5, 10), new Point(10, 0));
            var child = new Triangle(new Point(0, 20), new Point(5, 30), new Point(10, 20));

            // Act
            bool result = calculator.IsIncluded(parent, child);

            // Assert
            Assert.False(result);
        }

        #endregion
    }
}
