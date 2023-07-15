using GraphicsApp.Model;
using Moq;

namespace GraphicsApp.Tests.Unit
{
    public class ShapeAreaComparerTests
    {
        private readonly Shape _smallShape;
        private readonly Shape _bigShape;

        public ShapeAreaComparerTests()
        {
            Mock<Shape> shape1 = new Mock<Shape>();
            shape1.Setup(x => x.GetArea()).Returns(10);
            _smallShape = shape1.Object;

            Mock<Shape> shape2 = new Mock<Shape>();
            shape2.Setup(x => x.GetArea()).Returns(11);
            _bigShape = shape2.Object;
        }

        [Fact]
        public void Compare_Ascending_ReturnsNegative_ForSmallAndBigShapes()
        {
            // Arrange
            var comparer = new ShapeAreaComparer(System.ComponentModel.ListSortDirection.Ascending);

            // Act
            var result = comparer.Compare(_smallShape, _bigShape);

            // Assert
            Assert.True(result < 0);
        }

        [Fact]
        public void Compare_Ascending_ReturnsZero_ForSmallAndSmallShapes()
        {
            // Arrange
            var comparer = new ShapeAreaComparer(System.ComponentModel.ListSortDirection.Ascending);

            // Act
            var result = comparer.Compare(_smallShape, _smallShape);

            //Assert
            Assert.True(result == 0);
        }

        [Fact]
        public void Compare_Ascending_ReturnsPositive_ForBigAndSmallShapes()
        {
            // Arrange
            var comparer = new ShapeAreaComparer(System.ComponentModel.ListSortDirection.Ascending);

            // Act
            var result = comparer.Compare(_bigShape, _smallShape);

            //Assert
            Assert.True(result > 0);
        }

        [Fact]
        public void Compare_Descending_ReturnsPositive_ForSmallAndBigShapes()
        {
            // Arrange
            var comparer = new ShapeAreaComparer(System.ComponentModel.ListSortDirection.Descending);

            // Act
            var result = comparer.Compare(_smallShape, _bigShape);

            //Assert
            Assert.True(result > 0);
        }

        [Fact]
        public void Compare_Descending_ReturnsZero_ForSmallAndSmallShapes()
        {
            // Arrange
            var comparer = new ShapeAreaComparer(System.ComponentModel.ListSortDirection.Descending);

            // Act
            var result = comparer.Compare(_smallShape, _smallShape);

            //Assert
            Assert.True(result == 0);
        }

        [Fact]
        public void Compare_Descending_ReturnsNegative_ForBigAndSmallShapes()
        {
            // Arrange
            var comparer = new ShapeAreaComparer(System.ComponentModel.ListSortDirection.Descending);

            // Act
            var result = comparer.Compare(_bigShape, _smallShape);

            //Assert
            Assert.True(result < 0);
        }
    }
}
