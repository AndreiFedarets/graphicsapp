using GraphicsApp.Model;
using Moq;
using System.Drawing;

namespace GraphicsApp.Client.WinForms.Tests.Unit
{
    public class ShadesCountCalculatorTests
    {
        [Fact]
        public void Handle_CalculatesShadeCount_AndAddsStatusText()
        {
            var child1 = new Triangle(new Model.Point(1, 1), new Model.Point(5, 9), new Model.Point(9, 1));
            child1.Attributes[nameof(Color)] = Color.DarkGreen;

            var parent1 = new Triangle(new Model.Point(0, 0), new Model.Point(5, 10), new Model.Point(10, 0));
            parent1 = (Triangle)parent1.AssignChildren(new[] { child1 });
            parent1.Attributes[nameof(Color)] = Color.Green;

            var parent2 = new Triangle(new Model.Point(0, 20), new Model.Point(5, 30), new Model.Point(10, 20));
            parent2.Attributes[nameof(Color)] = Color.Green;

            var area = new Area(new Shape[]
            {
                parent1, parent2
            });
            area.Attributes[nameof(Color)] = Color.LightGreen;

            var generator = new ShadesCountCalculator();
            var result = generator.Handle(area);

            var lastShape = result.Children.Last();
            Assert.True(lastShape is StatusText);

            Assert.Equal(3.ToString(), ((StatusText)lastShape).Value);
        }

        [Fact]
        public void Handle_SkipsTheSameShades()
        {
            var child1 = new Triangle(new Model.Point(1, 1), new Model.Point(5, 9), new Model.Point(9, 1));
            child1.Attributes[nameof(Color)] = Color.DarkGreen;

            var parent1 = new Triangle(new Model.Point(0, 0), new Model.Point(5, 10), new Model.Point(10, 0));
            parent1 = (Triangle)parent1.AssignChildren(new[] { child1 });
            parent1.Attributes[nameof(Color)] = Color.DarkGreen;

            var parent2 = new Triangle(new Model.Point(0, 20), new Model.Point(5, 30), new Model.Point(10, 20));
            parent2.Attributes[nameof(Color)] = Color.DarkGreen;

            var area = new Area(new Shape[]
            {
                parent1, parent2
            });
            area.Attributes[nameof(Color)] = Color.DarkGreen;

            var generator = new ShadesCountCalculator();
            var result = generator.Handle(area);

            var lastShape = result.Children.Last();
            Assert.True(lastShape is StatusText);

            Assert.Equal(1.ToString(), ((StatusText)lastShape).Value);
        }
    }
}