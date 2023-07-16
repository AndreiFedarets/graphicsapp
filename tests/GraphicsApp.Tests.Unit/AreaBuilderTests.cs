using GraphicsApp.Model;
using Microsoft.Extensions.Logging;
using Moq;

namespace GraphicsApp.Tests.Unit
{
    public class AreaBuilderTests
    {
        [Fact]
        public void HasChanges_IsFalse_ForNewBuilder()
        {
            // Arrange
            var areaBuilder = new AreaBuilder(new Mock<ILogger<AreaBuilder>>().Object);

            // Act & Assert
            Assert.False(areaBuilder.HasChanges);
        }

        [Fact]
        public async Task BuildAsync_DoesNotThrowException_WhenProviderIsNotSet()
        {
            // Arrange
            var areaBuilder = new AreaBuilder(new Mock<ILogger<AreaBuilder>>().Object);

            // Act & Assert
            await areaBuilder.BuildAsync();
        }

        [Fact]
        public async Task BuildAsync_CallsHandlersInOrderTheyAreAdded_OnSuccess()
        {
            // Arrange
            Triangle triangle = new Triangle(new Point(0, 0), new Point(5, 10), new Point(10, 0));

            Mock<IShapeProvider> provider = new Mock<IShapeProvider>();
            provider.Setup(x => x.GetShapesAsync()).Returns(Task.FromResult((IEnumerable<Shape>)new[] { triangle }));

            List<IAreaHandler> calledHandlers = new List<IAreaHandler>();
            Area area = null;

            Mock<IAreaHandler> handler1 = new Mock<IAreaHandler>();
            handler1.Setup(x => x.Handle(It.IsAny<Area>())).Callback<Area>(a =>
            {
                area = a;
                calledHandlers.Add(handler1.Object);
            }).Returns(() => area);

            Mock<IAreaHandler> handler2 = new Mock<IAreaHandler>();
            handler2.Setup(x => x.Handle(It.IsAny<Area>())).Callback<Area>(a =>
            {
                area = a;
                calledHandlers.Add(handler2.Object);
            }).Returns(() => area);

            var areaBuilder = new AreaBuilder(new Mock<ILogger<AreaBuilder>>().Object)
                .WithProvider(provider.Object)
                .WithHandler(handler1.Object)
                .WithHandler(handler2.Object);

            // Act
            var result = await areaBuilder.BuildAsync();

            // Assert
            Assert.NotNull(result);
            Assert.True(ReferenceEquals(area, result));
            Assert.False(areaBuilder.HasChanges);
            Assert.True(calledHandlers.IndexOf(handler1.Object) == 0);
            Assert.True(calledHandlers.IndexOf(handler2.Object) == 1);
        }

        [Fact]
        public async Task BuildAsync_CallsFailuresInOrderTheyAreAdded_OnError()
        {
            // Arrange
            Triangle triangle = new Triangle(new Point(0, 0), new Point(5, 10), new Point(10, 0));

            Mock<IShapeProvider> provider = new Mock<IShapeProvider>();
            provider.Setup(x => x.GetShapesAsync()).Returns(Task.FromResult((IEnumerable<Shape>)new[] { triangle }));

            Mock<IAreaHandler> handler = new Mock<IAreaHandler>();
            handler.Setup(x => x.Handle(It.IsAny<Area>())).Throws(new Exception());

            List<IAreaHandler> calledFailures = new List<IAreaHandler>();
            Area area = null;

            Mock<IAreaHandler> failure1 = new Mock<IAreaHandler>();
            failure1.Setup(x => x.Handle(It.IsAny<Area>())).Callback<Area>(a =>
            {
                area = a;
                calledFailures.Add(failure1.Object);
            }).Returns(() => area);

            Mock<IAreaHandler> failure2 = new Mock<IAreaHandler>();
            failure2.Setup(x => x.Handle(It.IsAny<Area>())).Callback<Area>(a =>
            {
                area = a;
                calledFailures.Add(failure2.Object);
            }).Returns(() => area);

            var areaBuilder = new AreaBuilder(new Mock<ILogger<AreaBuilder>>().Object)
                .WithProvider(provider.Object)
                .WithHandler(handler.Object)
                .WithFailure(failure1.Object)
                .WithFailure(failure2.Object);

            // Act
            var result = await areaBuilder.BuildAsync();

            // Assert
            Assert.NotNull(result);
            Assert.True(ReferenceEquals(area, result));
            Assert.False(areaBuilder.HasChanges);
            Assert.True(calledFailures.IndexOf(failure1.Object) == 0);
            Assert.True(calledFailures.IndexOf(failure2.Object) == 1);
        }

        [Fact]
        public async Task BuildAsync_ReturnsTheSameArea_WhenNoChanges()
        {
            // Arrange
            Triangle triangle = new Triangle(new Point(0, 0), new Point(5, 10), new Point(10, 0));

            Mock<IShapeProvider> provider = new Mock<IShapeProvider>();
            provider.Setup(x => x.GetShapesAsync()).Returns(Task.FromResult((IEnumerable<Shape>)new[] { triangle }));

            var areaBuilder = new AreaBuilder(new Mock<ILogger<AreaBuilder>>().Object)
                .WithProvider(provider.Object);

            // Act
            var result1 = await areaBuilder.BuildAsync();
            var result2 = await areaBuilder.BuildAsync();

            // Assert
            Assert.NotNull(result1);
            Assert.NotNull(result2);
            Assert.True(ReferenceEquals(result1, result2));
        }


        [Fact]
        public async Task HasChanges_BecameTrue_WhenResettingProvider()
        {
            // Arrange
            Triangle triangle = new Triangle(new Point(0, 0), new Point(5, 10), new Point(10, 0));

            Mock<IShapeProvider> provider = new Mock<IShapeProvider>();
            provider.Setup(x => x.GetShapesAsync()).Returns(Task.FromResult((IEnumerable<Shape>)new[] { triangle }));

            var areaBuilder = new AreaBuilder(new Mock<ILogger<AreaBuilder>>().Object)
                .WithProvider(provider.Object);

            // Act & Assert
            var result = await areaBuilder.BuildAsync();
            Assert.False(areaBuilder.HasChanges);

            areaBuilder.WithProvider(provider.Object);
            Assert.True(areaBuilder.HasChanges);
        }

        [Fact]
        public async Task HasChanges_BecameTrue_WhenAddingHandler()
        {
            // Arrange
            Triangle triangle = new Triangle(new Point(0, 0), new Point(5, 10), new Point(10, 0));

            Mock<IShapeProvider> provider = new Mock<IShapeProvider>();
            provider.Setup(x => x.GetShapesAsync()).Returns(Task.FromResult((IEnumerable<Shape>)new[] { triangle }));

            Mock<IAreaHandler> handler = new Mock<IAreaHandler>();

            var areaBuilder = new AreaBuilder(new Mock<ILogger<AreaBuilder>>().Object)
                .WithProvider(provider.Object);

            // Act & Assert
            var result = await areaBuilder.BuildAsync();
            Assert.False(areaBuilder.HasChanges);

            areaBuilder.WithHandler(handler.Object);
            Assert.True(areaBuilder.HasChanges);
        }

    }
}
