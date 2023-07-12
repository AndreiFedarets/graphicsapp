using System.ComponentModel;

namespace GraphicsApp
{
    public static class AreaBuilderExtensions
    {
        public static AreaBuilder WithTrianglesFromTextFile(this AreaBuilder builder, FileShapeProviderConfig config)
        {
            builder.WithProvider(new TextFileTriangleProvider(config));
            return builder;
        }

        public static AreaBuilder WithIntersectionValidator(this AreaBuilder builder, IShapeIntersectionCalculator calculator)
        {
            builder.WithHandler(new ShapeIntersectionValidator(calculator));
            return builder;
        }

        public static AreaBuilder WithAreaSorter(this AreaBuilder builder, ListSortDirection direction)
        {
            builder.WithHandler(new ShapeAreaSorter(direction));
            return builder;
        }
    }
}
