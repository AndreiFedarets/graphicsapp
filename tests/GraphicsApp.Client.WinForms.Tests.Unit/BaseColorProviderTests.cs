using System.Drawing;

namespace GraphicsApp.Client.WinForms.Tests.Unit
{
    public class BaseColorProviderTests
    {
        [Fact]
        public void BaseColor_ReturnsInitialColor_ByDefault()
        {
            // Arrange & Act
            var colorProvider = new BaseColorProvider(Color.Green);

            // Assert
            Assert.Equal(Color.Green, colorProvider.BaseColor);
        }

        [Fact]
        public void BaseColor_ReturnsNewColor_AfterChange()
        {
            // Arrange
            var colorProvider = new BaseColorProvider(Color.Green);

            // Act
            colorProvider.SetBaseColor(Color.Red);

            // Assert
            Assert.Equal(Color.Red, colorProvider.BaseColor);
        }

        [Fact]
        public void SetBaseColor_Raises_BaseColorChangedEvent()
        {
            // Arrange
            var colorProvider = new BaseColorProvider(Color.Green);
            Color colorAtEvent = Color.Green;
            colorProvider.BaseColorChanged += (sender, args) =>
            {
                colorAtEvent = colorProvider.BaseColor;
            };

            // Act
            colorProvider.SetBaseColor(Color.Red);

            // Assert
            Assert.Equal(Color.Red, colorAtEvent);
        }
    }
}
