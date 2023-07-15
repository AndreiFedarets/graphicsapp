using GraphicsApp.Model;
using Moq;
using System.Drawing;

namespace GraphicsApp.Client.WinForms.Tests.Unit
{
    public class ErrorCaptionGeneratorTests
    {
        [Fact]
        public void Handle_AddsSingleErrorStatusText()
        {
            // Arrange
            Mock<IBaseColorProvider> colorProvider = new Mock<IBaseColorProvider>();
            colorProvider.Setup(x => x.BaseColor).Returns(Color.Green);
            var area = new Area(Enumerable.Empty<Shape>());

            var generator = new ErrorCaptionGenerator(colorProvider.Object);

            // Act
            var result = generator.Handle(area);

            // Assert
            Assert.Single(result.Children);
            Assert.True(result.Children[0] is StatusText);
            Assert.Equal("ERROR", ((StatusText)result.Children[0]).Value);
        }
    }
}