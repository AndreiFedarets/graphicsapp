using GraphicsApp.Model;

namespace GraphicsApp.Tests.Unit.Model
{
    public class TriangleTests
    {
        [Fact]
        public void P1P2P3_AreAvialableInTheSameOrderTheyPassed()
        {
            // Arrange
            var p1 = new Point(0, 0);
            var p2 = new Point(10, 10);
            var p3 = new Point(20, 0);
            var triangle = new Triangle(p1, p2, p3);

            // Assert
            Assert.Equal(p1, triangle.P1);
            Assert.Equal(p2, triangle.P2);
            Assert.Equal(p2, triangle.P2);
        }

        [Fact]
        public void ContainsPoint_ReturnsTrue_WhenPointIsInside()
        {
            // Arrange
            var p1 = new Point(0, 0);
            var p2 = new Point(10, 10);
            var p3 = new Point(20, 0);
            var triangle = new Triangle(p1, p2, p3);
            var point = new Point(10, 5);

            // Act
            bool result = triangle.ContainsPoint(point);

            Assert.True(result);
        }

        [Fact]
        public void ContainsPoint_ReturnsTrue_WhenPointIsOnTheEdge()
        {
            // Arrange
            var p1 = new Point(0, 0);
            var p2 = new Point(10, 10);
            var p3 = new Point(20, 0);
            var triangle = new Triangle(p1, p2, p3);
            var point = new Point(2, 2);

            // Act
            bool result = triangle.ContainsPoint(point);

            Assert.True(result);
        }

        [Fact]
        public void ContainsPoint_ReturnsTrue_WhenPointIsInTheApex()
        {
            // Arrange
            var p1 = new Point(0, 0);
            var p2 = new Point(10, 10);
            var p3 = new Point(20, 0);
            var triangle = new Triangle(p1, p2, p3);
            var point = new Point(10, 10);

            // Act
            bool result = triangle.ContainsPoint(point);

            Assert.True(result);
        }

        [Fact]
        public void ContainsPoint_ReturnsFalse_WhenPointIsOutside()
        {
            // Arrange
            var p1 = new Point(0, 0);
            var p2 = new Point(10, 10);
            var p3 = new Point(20, 0);
            var triangle = new Triangle(p1, p2, p3);
            var point = new Point(3, 4);

            // Act
            bool result = triangle.ContainsPoint(point);

            // Assert
            Assert.False(result);
        }

        [Fact]
        public void GetArea_ReturnsCorrectResult()
        {
            // Arrange
            var p1 = new Point(0, 0);
            var p2 = new Point(10, 10);
            var p3 = new Point(10, 0);
            var triangle = new Triangle(p1, p2, p3);

            // Act
            double result = triangle.GetArea();

            // Assert
            Assert.Equal(50, result, double.Epsilon);
        }
    }
}
