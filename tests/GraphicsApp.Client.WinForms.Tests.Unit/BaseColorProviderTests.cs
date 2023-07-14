using System.Drawing;

namespace GraphicsApp.Client.WinForms.Tests.Unit
{
    public class BaseColorProviderTests
    {
        [Fact]
        public void BaseColor_ReturnsInitialColor_ByDefault()
        {
            // arrange
            var colorProvider = new BaseColorProvider(Color.Green);

            // assert
            Assert.Equal(Color.Green, colorProvider.BaseColor);
        }

        [Fact]
        public void BaseColor_ReturnsNewColor_AfterChange()
        {
            // arrange
            var colorProvider = new BaseColorProvider(Color.Green);

            // act
            colorProvider.SetBaseColor(Color.Red);

            // assert
            Assert.Equal(Color.Red, colorProvider.BaseColor);
        }

        [Fact]
        public void SetBaseColor_Raises_BaseColorChangedEvent()
        {
            // arrange
            var colorProvider = new BaseColorProvider(Color.Green);
            Color colorAtEvent = Color.Green;
            colorProvider.BaseColorChanged += (sender, args) =>
            {
                colorAtEvent = colorProvider.BaseColor;
            };

            // act
            colorProvider.SetBaseColor(Color.Red);

            // assert
            Assert.Equal(Color.Red, colorAtEvent);
        }
    }
}
