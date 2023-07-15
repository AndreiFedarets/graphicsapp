using GraphicsApp.Model;

namespace GraphicsApp.Tests.Unit.Model
{
    public class RectangleTests
    {
        [Fact]
        public void BottomLeft_IsDetectedCorrectly_WhenPassedAsFirst()
        {
            // Arrange
            var p1 = new Point(0, 0);
            var p2 = new Point(10, 10);
            var rectangle = new Rectangle(p1, p2);

            // Assert
            Assert.Equal(p1, rectangle.BottomLeft);
        }

        [Fact]
        public void BottomLeft_IsDetectedCorrectly_WhenPassedAsSecond()
        {
            // Arrange
            var p1 = new Point(0, 0);
            var p2 = new Point(10, 10);
            var rectangle = new Rectangle(p2, p1);

            // Assert
            Assert.Equal(p1, rectangle.BottomLeft);
        }

        [Fact]
        public void BottomLeft_IsRecalculatedCorrectly_WhenPassedAsTopLeft()
        {
            // Arrange
            var p1 = new Point(0, 10);
            var p2 = new Point(10, 0);
            var rectangle = new Rectangle(p2, p1);

            // Assert
            Assert.Equal(new Point(0, 0), rectangle.BottomLeft);
        }

        [Fact]
        public void TopRight_IsDetectedCorrectly_WhenPassedAsSecond()
        {
            // Arrange
            var p1 = new Point(0, 0);
            var p2 = new Point(10, 10);
            var rectangle = new Rectangle(p1, p2);

            // Assert
            Assert.Equal(p2, rectangle.TopRight);
        }

        [Fact]
        public void TopRight_IsDetectedCorrectly_WhenPassedAsFirst()
        {
            // Arrange
            var p1 = new Point(0, 0);
            var p2 = new Point(10, 10);
            var rectangle = new Rectangle(p2, p1);

            // Assert
            Assert.Equal(p2, rectangle.TopRight);
        }

        [Fact]
        public void TopRight_IsRecalculatedCorrectly_WhenPassedAsBottomRight()
        {
            // Arrange
            var p1 = new Point(0, 10);
            var p2 = new Point(10, 0);
            var rectangle = new Rectangle(p2, p1);

            // Assert
            Assert.Equal(new Point(10, 10), rectangle.TopRight);
        }

        [Fact]
        public void ContainsPoint_ReturnsTrue_WhenPointIsInside()
        {
            // Arrange
            var p1 = new Point(0, 0);
            var p2 = new Point(10, 10);
            var rectangle = new Rectangle(p1, p2);
            var point = new Point(5, 5);

            // Act
            bool result = rectangle.ContainsPoint(point);

            Assert.True(result);
        }

        [Fact]
        public void ContainsPoint_ReturnsTrue_WhenPointIsOnTheEdge()
        {
            // Arrange
            var p1 = new Point(0, 0);
            var p2 = new Point(10, 10);
            var rectangle = new Rectangle(p1, p2);
            var point = new Point(5, 10);

            // Act
            bool result = rectangle.ContainsPoint(point);

            Assert.True(result);
        }

        [Fact]
        public void ContainsPoint_ReturnsTrue_WhenPointIsInTheApex()
        {
            // Arrange
            var p1 = new Point(0, 0);
            var p2 = new Point(10, 10);
            var rectangle = new Rectangle(p1, p2);
            var point = new Point(10, 10);

            // Act
            bool result = rectangle.ContainsPoint(point);

            Assert.True(result);
        }

        [Fact]
        public void ContainsPoint_ReturnsFalse_WhenPointIsOutside()
        {
            // Arrange
            var p1 = new Point(0, 0);
            var p2 = new Point(10, 10);
            var rectangle = new Rectangle(p1, p2);
            var point = new Point(5, 11);

            // Act
            bool result = rectangle.ContainsPoint(point);

            // Assert
            Assert.False(result);
        }

        [Fact]
        public void GetArea_ReturnsCorrectResult()
        {
            // Arrange
            var p1 = new Point(0, 0);
            var p2 = new Point(10, 10);
            var rectangle = new Rectangle(p1, p2);

            // Act
            double result = rectangle.GetArea();

            // Assert
            Assert.Equal(100, result, double.Epsilon);
        }
    }
}
