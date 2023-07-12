using GraphicsApp.Model;
using System.Collections.Immutable;

namespace GraphicsApp.Client.WinForms.Visuals
{
    public class AreaVisual
    {
        private readonly Control _control;
        private readonly ImmutableList<ShapeVisual> _containers;

        public AreaVisual(Control control, Area area)
        {
            _control = control;
            _containers = area.Select(x => CreateContainer(x)).ToImmutableList();
        }

        public void Draw()
        {
            using var graphics = _control.CreateGraphics();
            graphics.Clear(Color.LightGray);
            _containers.ForEach(x => x.Draw(graphics));
        }

        private ShapeVisual CreateContainer(Shape shape)
        {
            if (shape is Triangle triangle)
            {
                return new TriangleVisual(triangle);
            }

            throw new NotSupportedException($"Shape of the type {shape.GetType().FullName} is not supported");
        }

    }
}
