using GraphicsApp.Model;
using System.Drawing;

namespace GraphicsApp.Tests.Unit
{
    public class TextFileTriangleProviderTests
    {
        [Fact]
        public void Ctor_ThrowsArgumentNullException_WhenConfigIsNull()
        {
            Assert.Throws<ArgumentNullException>(() => new TextFileTriangleProvider(null));
        }

        [Fact]
        public void Ctor_ThrowsArgumentException_WhenConfigFilePathIsNull()
        {
            Assert.Throws<ArgumentException>(() => new TextFileTriangleProvider(new FileShapeProviderConfig()
            {
                FilePath = null,
                ShapesLimit = 1000
            }));
        }

        [Fact]
        public void Ctor_ThrowsArgumentException_WhenConfigFilePathIsEmpty()
        {
            Assert.Throws<ArgumentException>(() => new TextFileTriangleProvider(new FileShapeProviderConfig()
            {
                FilePath = "",
                ShapesLimit = 1000
            }));
        }

        [Fact]
        public void Ctor_ThrowsArgumentException_WhenConfigShapesLimitIsZero()
        {
            Assert.Throws<ArgumentException>(() => new TextFileTriangleProvider(new FileShapeProviderConfig()
            {
                FilePath = "data.txt",
                ShapesLimit = 0
            }));
        }

        [Fact]
        public void Ctor_ThrowsArgumentException_WhenConfigShapesLimitIsNegative()
        {
            Assert.Throws<ArgumentException>(() => new TextFileTriangleProvider(new FileShapeProviderConfig()
            {
                FilePath = "data.txt",
                ShapesLimit = -1
            }));
        }

        [Fact]
        public void GetShapesAsync_ThrowsFileNotFoundException_WhenFileDoesNotExists()
        {
            var provider = new TextFileTriangleProvider(new FileShapeProviderConfig()
            {
                FilePath = "Resources/TextFileTriangleProviderTests/data_NN.txt",
                ShapesLimit = 10
            });
            Assert.ThrowsAsync<FileNotFoundException>(provider.GetShapesAsync);
        }

        [Fact]
        public void GetShapesAsync_ThrowsFileNotFoundException_WhenFileContainsMoreShapesThanLimit()
        {
            var provider = new TextFileTriangleProvider(new FileShapeProviderConfig()
            {
                FilePath = "Resources/TextFileTriangleProviderTests/data_01.txt",
                ShapesLimit = 1
            });
            Assert.ThrowsAsync<InvalidSourceException>(provider.GetShapesAsync);
        }

        [Fact]
        public void GetShapesAsync_ThrowsFileNotFoundException_WhenFileContainsLessShapesThanExpected()
        {
            var provider = new TextFileTriangleProvider(new FileShapeProviderConfig()
            {
                FilePath = "Resources/TextFileTriangleProviderTests/data_02.txt",
                ShapesLimit = 10
            });
            Assert.ThrowsAsync<InvalidSourceException>(provider.GetShapesAsync);
        }

        [Fact]
        public void GetShapesAsync_ThrowsFileNotFoundException_WhenFileContainsInvalidFirsLine()
        {
            var provider = new TextFileTriangleProvider(new FileShapeProviderConfig()
            {
                FilePath = "Resources/TextFileTriangleProviderTests/data_03.txt",
                ShapesLimit = 10
            });
            Assert.ThrowsAsync<InvalidSourceException>(provider.GetShapesAsync);
        }

        [Fact]
        public void GetShapesAsync_ThrowsFileNotFoundException_WhenFileHasMissingFirsLine()
        {
            var provider = new TextFileTriangleProvider(new FileShapeProviderConfig()
            {
                FilePath = "Resources/TextFileTriangleProviderTests/data_04.txt",
                ShapesLimit = 10
            });
            Assert.ThrowsAsync<InvalidSourceException>(provider.GetShapesAsync);
        }

        [Fact]
        public void GetShapesAsync_ThrowsFileNotFoundException_WhenFileContainsInvalidCoordinatesLine()
        {
            var provider = new TextFileTriangleProvider(new FileShapeProviderConfig()
            {
                FilePath = "Resources/TextFileTriangleProviderTests/data_05.txt",
                ShapesLimit = 10
            });
            Assert.ThrowsAsync<InvalidSourceException>(provider.GetShapesAsync);
        }

        [Fact]
        public async Task GetShapesAsync_ReturnsExpectedShapes_WhenFileIsCorrect()
        {
            var provider = new TextFileTriangleProvider(new FileShapeProviderConfig()
            {
                FilePath = "Resources/TextFileTriangleProviderTests/data_01.txt",
                ShapesLimit = 10
            });
            var shapes = await provider.GetShapesAsync();
            Assert.Equal(2, shapes.Count());

            var shape1 = shapes.First();
            var shape2 = shapes.Last();
            Assert.True(shape1 is Triangle);
            Assert.True(shape2 is Triangle);

            var triangle1 = (Triangle)shape1;
            Assert.Equal(new Model.Point(0, 0), triangle1.P1);
            Assert.Equal(new Model.Point(10, 10), triangle1.P2);
            Assert.Equal(new Model.Point(20, 20), triangle1.P3);


            var triangle2 = (Triangle)shape2;
            Assert.Equal(new Model.Point(1, 1), triangle2.P1);
            Assert.Equal(new Model.Point(11, 11), triangle2.P2);
            Assert.Equal(new Model.Point(22, 22), triangle2.P3);

        }
    }
}
