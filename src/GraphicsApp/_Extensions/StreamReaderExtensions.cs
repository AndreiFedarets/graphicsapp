﻿namespace GraphicsApp
{
    internal static class StreamReaderExtensions
    {
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

                throw new Exception($"'{x}' is not valid integer number");
            }).ToArray();
        }
    }
}
