using GraphicsApp.Model;

namespace GraphicsApp.Client.WinForms.Visuals
{
    internal static class VisualFactory
    {
        public static ShapeVisual Create(Shape shape)
        {
            if (shape is Triangle triangle)
            {
                return new TriangleVisual(triangle);
            }

            if (shape is Area area)
            {
                return new AreaVisual(area);
            }

            throw new NotSupportedException($"Shape of the type {shape.GetType().FullName} is not supported");
        }
    }
}
