using GraphicsApp.Model;

namespace GraphicsApp
{
    public sealed class TextFileTriangleProvider : IShapeProvider
    {
        private readonly FileShapeProviderConfig _config;

        public TextFileTriangleProvider(FileShapeProviderConfig config)
        {
            if (config == null)
            {
                throw new ArgumentNullException(nameof(config));
            }
            if (string.IsNullOrEmpty(config.FilePath))
            {
                throw new ArgumentNullException(nameof(config.FilePath));
            }
            if (config.ShapesLimit <= 0)
            {
                throw new ArgumentException("Value cannot be less or equal 0", nameof(config.ShapesLimit));
            }
            _config = config;
        }

        public async Task<IEnumerable<Shape>> GetShapesAsync()
        {
            if (!File.Exists(_config.FilePath))
            {
                throw new FileNotFoundException($"Source file was not found by the path {_config.FilePath}", _config.FilePath);
            }

            using var reader = new StreamReader(_config.FilePath);

            var lineData = await reader.ReadIntLineAsync();
            if (lineData.Length != 1)
            {
                throw new Exception("First line (shapes count) must contain single integer");
            }

            int linesCount = lineData[0];
            if (linesCount <= 0 || linesCount > _config.ShapesLimit)
            {
                throw new Exception($"Lines count must be greater than 0 and less or equal to {_config.ShapesLimit}");
            }

            var shapes = new Shape[linesCount];
            for (int i = 0; i < linesCount; i++)
            {
                var coordinates = await reader.ReadIntLineAsync().ConfigureAwait(false);
                if (coordinates.Length == 0)
                {
                    throw new Exception("Unexpected end of the input data");
                }

                if (coordinates.Length != 6)
                {
                    throw new Exception("Coordinates line must contain 6 numbers");
                }

                var p1 = new Point(coordinates[0], coordinates[1]);
                var p2 = new Point(coordinates[2], coordinates[3]);
                var p3 = new Point(coordinates[4], coordinates[5]);

                shapes[i] = new Triangle(p1, p2, p3)
                {
                    Tag = i.ToString()
                };
            }

            return shapes;
        }
    }
}
