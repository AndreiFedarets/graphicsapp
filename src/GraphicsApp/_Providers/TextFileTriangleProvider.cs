using GraphicsApp.Model;

namespace GraphicsApp
{
    /// <summary>
    /// Provide triangles from text file
    /// </summary>
    public sealed class TextFileTriangleProvider : IShapeProvider
    {
        private readonly FileShapeProviderConfig _config;

        /// <summary>
        /// Create new instance of TextFileTriangleProvider
        /// </summary>
        /// <param name="config"></param>
        /// <exception cref="ArgumentNullException">config is null</exception>
        /// <exception cref="ArgumentException">config.FilePath is null or empty or config.ShapesLimit is less or equal 0</exception>
        public TextFileTriangleProvider(FileShapeProviderConfig config)
        {
            if (config == null)
            {
                throw new ArgumentNullException(nameof(config));
            }
            if (string.IsNullOrEmpty(config.FilePath))
            {
                throw new ArgumentException("Value cannot be null or empty", nameof(config.FilePath));
            }
            if (config.ShapesLimit <= 0)
            {
                throw new ArgumentException("Value cannot be less or equal 0", nameof(config.ShapesLimit));
            }
            _config = config;
        }

        /// <summary>
        /// Read triangles from the specified text file
        /// </summary>
        /// <returns>Collection of triangles</returns>
        /// <exception cref="FileNotFoundException">Source file does not exist</exception>
        /// <exception cref="InvalidSourceException">Source file has invalid format, data or contains more triangles than specified limit</exception>
        public async Task<IEnumerable<Shape>> GetShapesAsync()
        {
            if (!File.Exists(_config.FilePath))
            {
                throw new FileNotFoundException($"Source file was not found by the path {_config.FilePath}", _config.FilePath);
            }

            using var reader = new StreamReader(_config.FilePath);
            int[] lineData;
            try
            {
                lineData = await reader.ReadIntLineAsync().ConfigureAwait(false);
            }
            catch (Exception exception)
            {
                throw new InvalidSourceException("Error reading shapes count line", exception);
            }

            if (lineData.Length != 1)
            {
                throw new InvalidSourceException("First line (shapes count) must contain single integer");
            }

            int linesCount = lineData[0];
            if (linesCount <= 0 || linesCount > _config.ShapesLimit)
            {
                throw new InvalidSourceException($"Lines count must be greater than 0 and less or equal to {_config.ShapesLimit}");
            }

            var shapes = new Shape[linesCount];
            for (int i = 0; i < linesCount; i++)
            {
                int[] coordinates;
                try
                {
                    coordinates = await reader.ReadIntLineAsync().ConfigureAwait(false);
                }
                catch (Exception exception)
                {
                    throw new InvalidSourceException($"Error reading coordinates line {i}", exception);
                }
                
                if (coordinates.Length == 0)
                {
                    throw new InvalidSourceException($"Unexpected end of the input data in coordinates line {i}");
                }

                if (coordinates.Length != 6)
                {
                    throw new InvalidSourceException($"Coordinates line must contain 6 numbers in line {i}");
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
