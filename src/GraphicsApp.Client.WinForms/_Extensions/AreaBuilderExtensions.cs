namespace GraphicsApp.Client.WinForms
{
    public static class AreaBuilderExtensions
    {
        public static AreaBuilder WithColorGenerator(this AreaBuilder builder, Color baseColor)
        {
            builder.WithHandler(new ShapeColorGenerator(baseColor));
            return builder;
        }
    }
}
