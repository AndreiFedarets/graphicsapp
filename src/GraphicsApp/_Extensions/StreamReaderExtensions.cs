namespace GraphicsApp
{
    internal static class StreamReaderExtensions
    {
        /// <summary>
        /// Read line and parse it into array of integers
        /// </summary>
        /// <param name="reader">Source StreamReader</param>
        /// <returns>Array of integers</returns>
        /// <exception cref="FormatException">Source line has invalid format or contains non-integer items</exception>
        public static async Task<int[]> ReadIntLineAsync(this StreamReader reader)
        {
            var line = await reader.ReadLineAsync().ConfigureAwait(false);
            if (string.IsNullOrEmpty(line))
            {
                return Array.Empty<int>();
            }

            var parts = line.Split(' ', StringSplitOptions.RemoveEmptyEntries);
            return parts.Select(x =>
            {
                if (int.TryParse(x, out var value))
                {
                    return value;
                }

                throw new FormatException($"'{x}' is not valid integer number");
            }).ToArray();
        }
    }
}
