using GraphicsApp.Model;

namespace GraphicsApp.Tests.Unit
{
    public class ShapeExtensionsTests
    {
        [Fact]
        public void AssignChildren_CreatesNewInstance()
        {
            // Arrange
            var root = new Triangle(new Point(0, 0), new Point(10, 10), new Point(10, 20));

            // Act
            var copy = root.AssignChildren(new Shape[0]);

            // Assert
            Assert.False(ReferenceEquals(root, copy));
        }

        [Fact]
        public void AssignChildren_AssignesChildren_ToTriangle()
        {
            // Arrange
            var root = new Triangle(new Point(0, 0), new Point(10, 10), new Point(10, 20));
            var rectangle = new Rectangle(new Point(0, 0), new Point(10, 10));

            // Act
            var copy = root.AssignChildren(new Shape[] 
            {
                rectangle
            });

            // Assert
            Assert.Single(copy.Children);
            Assert.True(ReferenceEquals(rectangle, copy.Children[0]));
        }

        [Fact]
        public void AssignChildren_AssignesChildren_ToArea()
        {
            // Arrange
            var root = new Area(new Point(0, 0), new Point(10, 10));
            var rectangle = new Rectangle(new Point(0, 0), new Point(10, 10));

            // Act
            var copy = root.AssignChildren(new Shape[]
            {
                rectangle
            });

            // Assert
            Assert.Single(copy.Children);
            Assert.True(ReferenceEquals(rectangle, copy.Children[0]));
        }

        [Fact]
        public void AssignChildren_AssignesChildren_ToRectange()
        {
            // Arrange
            var root = new Rectangle(new Point(0, 0), new Point(10, 10));
            var rectangle = new Rectangle(new Point(0, 0), new Point(10, 10));

            // Act
            var copy = root.AssignChildren(new Shape[]
            {
                rectangle
            });

            // Assert
            Assert.Single(copy.Children);
            Assert.True(ReferenceEquals(rectangle, copy.Children[0]));
        }
    }
}
