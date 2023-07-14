using GraphicsApp.Model;
using Moq;
using System.Drawing;

namespace GraphicsApp.Client.WinForms.Tests.Unit
{
    public class ShapeColorGeneratorTests
    {
        [Fact]
        public void Handle_GeneratesShadesByLevels()
        {
            Color baseColor = Color.Green;
            Mock<IBaseColorProvider> colorProvider = new Mock<IBaseColorProvider>();
            colorProvider.Setup(x => x.BaseColor).Returns(baseColor);

            var parent1 = new Triangle(new Model.Point(0, 0), new Model.Point(5, 10), new Model.Point(10, 0));
            var child1 = new Triangle(new Model.Point(1, 1), new Model.Point(5, 9), new Model.Point(9, 1));
            parent1 = (Triangle)parent1.AssignChildren(new[] { child1 });
            var parent2 = new Triangle(new Model.Point(0, 20), new Model.Point(5, 30), new Model.Point(10, 20));

            var area = new Area(new Shape[]
            {
                parent1, parent2
            });

            var generator = new ErrorCaptionGenerator(colorProvider.Object);
            var result = generator.Handle(area);

            Assert.Equal(baseColor, result.Attributes[nameof(Color)]);
        }
    }
}