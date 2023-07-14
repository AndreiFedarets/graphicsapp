using GraphicsApp.Model;
using Moq;

namespace GraphicsApp.Tests.Unit
{
    public class ShapeTreeBuilderTests
    {
        private readonly Triangle _parentShape2;
        private readonly Triangle _parentShape1;
        private readonly Triangle _childShape1;
        private readonly Triangle _parent1IntersectingShape;
        private readonly IShapeIntersectionCalculator _calculator;

        public ShapeTreeBuilderTests() 
        {
            _parentShape1 = new Triangle(new Point(0, 0), new Point(5, 10), new Point(10, 0));
            _childShape1 = new Triangle(new Point(1, 1), new Point(5, 9), new Point(9, 1));
            _parentShape2 = new Triangle(new Point(0, 20), new Point(5, 30), new Point(10, 20));
            _parent1IntersectingShape = new Triangle(new Point(0, 1), new Point(5, 11), new Point(10, 1));

            _calculator = new TriangleIntersectionCalculator();
        }

        [Fact]
        public void Handle_BuildsTree_ForParentAndChild()
        {
            var builder = new ShapeTreeBuilder(_calculator);
            var input = new Area(new[] { _parentShape1, _childShape1 });
            var result = builder.Handle(input);

            Assert.True(result.Children.Count == 1);
            Assert.Equal(_parentShape1.P1, ((Triangle)result.Children[0]).P1);
            Assert.Equal(_parentShape1.P2, ((Triangle)result.Children[0]).P2);
            Assert.Equal(_parentShape1.P3, ((Triangle)result.Children[0]).P3);

            Assert.True(result.Children[0].Children.Count == 1);
            Assert.Equal(_childShape1.P1, ((Triangle)result.Children[0].Children[0]).P1);
            Assert.Equal(_childShape1.P2, ((Triangle)result.Children[0].Children[0]).P2);
            Assert.Equal(_childShape1.P3, ((Triangle)result.Children[0].Children[0]).P3);
        }

        [Fact]
        public void Handle_BuildsTree_ForTwoParents()
        {
            var builder = new ShapeTreeBuilder(_calculator);
            var input = new Area(new[] { _parentShape1, _parentShape2 });
            var result = builder.Handle(input);

            Assert.True(result.Children.Count == 2);
            Assert.Equal(_parentShape1.P1, ((Triangle)result.Children[0]).P1);
            Assert.Equal(_parentShape1.P2, ((Triangle)result.Children[0]).P2);
            Assert.Equal(_parentShape1.P3, ((Triangle)result.Children[0]).P3);

            Assert.Equal(_parentShape2.P1, ((Triangle)result.Children[1]).P1);
            Assert.Equal(_parentShape2.P2, ((Triangle)result.Children[1]).P2);
            Assert.Equal(_parentShape2.P3, ((Triangle)result.Children[1]).P3);
        }

        [Fact]
        public void Handle_ThrowsException_ForIntersectingTriangles()
        {
            var builder = new ShapeTreeBuilder(_calculator);
            var input = new Area(new[] { _parentShape1, _parent1IntersectingShape });

            Assert.Throws<Exception>(() => builder.Handle(input));
        }
    }
}
