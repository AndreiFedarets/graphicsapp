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

            var generator = new ShapeColorGenerator(colorProvider.Object);
            var result = generator.Handle(area);

            // are color is base color
            AssertColorsEqual(baseColor, (Color)result.Attributes[nameof(Color)]);

            // level 1 shape color is darker than base color
            AssertColorIsDarkerThanBaseColor(baseColor, (Color)result.Children[0].Attributes[nameof(Color)]);
            AssertColorIsDarkerThanBaseColor(baseColor, (Color)result.Children[1].Attributes[nameof(Color)]);

            // level 1 shapes have the same color
            AssertColorsEqual((Color)result.Children[0].Attributes[nameof(Color)], (Color)result.Children[1].Attributes[nameof(Color)]);

            // level 2 shape color is darker than level 1 shape color
            AssertColorIsDarkerThanBaseColor((Color)result.Children[0].Attributes[nameof(Color)], (Color)result.Children[0].Children[0].Attributes[nameof(Color)]);
        }

        private void AssertColorIsDarkerThanBaseColor(Color baseColor, Color color)
        {
            Assert.True(color.R <= baseColor.R && color.G <= baseColor.G && color.B <= baseColor.B);
            Assert.True(color.R < baseColor.R || color.G < baseColor.G || color.B < baseColor.B);
        }

        private void AssertColorsEqual(Color color1, Color color2)
        {
            Assert.Equal(color1.ToArgb(), color2.ToArgb());
        }
    }
}