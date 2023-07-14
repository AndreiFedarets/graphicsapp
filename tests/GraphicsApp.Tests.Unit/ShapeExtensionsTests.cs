using GraphicsApp.Model;

namespace GraphicsApp.Tests.Unit
{
    public class ShapeExtensionsTests
    {
        [Fact]
        public void AssignChildren_CreatesNewInstance()
        {
            var triangle = new Triangle(new Point(0, 0), new Point(10, 10), new Point(10, 20));
            var copy = triangle.AssignChildren(new Shape[0]);

            Assert.False(ReferenceEquals(triangle, copy));
        }

        [Fact]
        public void AssignChildren_AssignesChildren()
        {
            var triangle = new Triangle(new Point(0, 0), new Point(10, 10), new Point(10, 20));
            var rectangle = new Rectangle(new Point(0, 0), new Point(10, 10));
            var copy = triangle.AssignChildren(new Shape[] 
            {
                rectangle
            });

            Assert.Single(copy.Children);
            Assert.True(ReferenceEquals(rectangle, copy.Children[0]));
        }
    }
}
