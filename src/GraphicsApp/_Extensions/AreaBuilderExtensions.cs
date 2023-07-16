namespace GraphicsApp
{
    public static class AreaBuilderExtensions
    {
        /// <summary>
        /// Sets text file shape provider
        /// </summary>
        /// <param name="builder">Target Area builder</param>
        /// <param name="config">Configuration for provider</param>
        /// <returns>Area builder</returns>
        public static AreaBuilder TakeTrianglesFromTextFile(this AreaBuilder builder, FileShapeProviderConfig config)
        {
            builder.WithProvider(new TextFileTriangleProvider(config));
            return builder;
        }

        /// <summary>
        /// Append shapes tree builder to the chain of area builder handlers
        /// </summary>
        /// <param name="builder">Target Area builder</param>
        /// <param name="calculator">Intersection calculator service</param>
        /// <returns>Area builder</returns>
        public static AreaBuilder BuildShapeTree(this AreaBuilder builder, IShapeIntersectionCalculator calculator)
        {
            builder.WithHandler(new ShapeTreeBuilder(calculator));
            return builder;
        }
    }
}
