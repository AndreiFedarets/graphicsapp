using GraphicsApp.Model;
using Unity;

namespace GraphicsApp.Client.WinForms.Tests.Integration
{
    public class AreBuilderTests
    {
        [Fact]
        public async Task AreBuilder_BuildCorrectSampleArea()
        {
            // Arrange
            var container = Program.BuildContainer();
            var areaBuilder = container.Resolve<AreaBuilder>();

            // Act
            var area = await areaBuilder.BuildAsync();

            // Assert
            Assert.NotNull(area);
            Assert.Equal(2, area.Children.Count);
            Assert.True(area.Children[0] is Triangle);
            Assert.True(area.Children[1] is StatusText);

            AssertShapesLevel(area, 3, 0);
                AssertShapesLevel(area, 2, 0, 0);
                    AssertShapesLevel(area, 1, 0, 0, 0);
                        AssertShapesLevel(area, 0, 0, 0, 0, 0);
                    AssertShapesLevel(area, 0, 0, 0, 1);
                AssertShapesLevel(area, 1, 0, 1);
                    AssertShapesLevel(area, 1, 0, 0, 0);
                        AssertShapesLevel(area, 0, 0, 0, 0, 0);
                AssertShapesLevel(area, 0, 0, 2);
        }

        private void AssertShapesLevel(Shape shape, int expectedChildrenCount, params int[] path)
        {
            for (int i = 0; i < path.Length; i++)
            {
                shape = shape.Children[path[i]];
            }
            Assert.Equal(expectedChildrenCount, shape.Children.Count);
            foreach (var child in shape.Children)
            {
                Assert.True(child is Triangle);
            }
        }
    }
}