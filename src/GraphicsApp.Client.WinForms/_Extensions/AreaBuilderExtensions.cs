namespace GraphicsApp.Client.WinForms
{
    public static class AreaBuilderExtensions
    {
        public static AreaBuilder AssignColorsByLevels(this AreaBuilder builder, IBaseColorProvider colorProvider)
        {
            builder.WithHandler(new ShapeColorGenerator(colorProvider));
            return builder;
        }

        public static AreaBuilder AppendShadeCountStatus(this AreaBuilder builder)
        {
            builder.WithHandler(new ShadesCountCalculator());
            return builder;
        }

        public static AreaBuilder WithErrorOnFailure(this AreaBuilder builder, IBaseColorProvider colorProvider)
        {
            builder.WithFailure(new ErrorCaptionGenerator(colorProvider));
            return builder;
        }
    }
}
