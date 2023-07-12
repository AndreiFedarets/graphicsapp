namespace GraphicsApp
{
    public static class AreaBuilderExtensions
    {
        public static AreaBuilder TakeTrianglesFromTextFile(this AreaBuilder builder, FileShapeProviderConfig config)
        {
            builder.WithProvider(new TextFileTriangleProvider(config));
            return builder;
        }

        public static AreaBuilder BuildShapeTree(this AreaBuilder builder, IShapeIntersectionCalculator calculator)
        {
            builder.WithHandler(new ShapeTreeBuilder(calculator));
            return builder;
        }
    }
}
