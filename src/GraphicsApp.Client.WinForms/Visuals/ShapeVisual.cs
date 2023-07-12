using GraphicsApp.Model;
using System.Collections.Immutable;

namespace GraphicsApp.Client.WinForms.Visuals
{
    public abstract class ShapeVisual
    {
        private ImmutableList<ShapeVisual> _children;

        protected ShapeVisual(Shape shape)
        {
            Shape = shape;
            _children = shape.Children.Select(x => VisualFactory.Create(x)).ToImmutableList();
        }
        
        public Shape Shape { get; }

        public void Draw(Graphics graphics, Model.Rectangle bounds, double scaleFactor = 1)
        {
            DrawSelf(graphics, bounds, scaleFactor);
            foreach (var child in _children)
            {
                child.Draw(graphics, bounds, scaleFactor);
            }
        }

        protected abstract void DrawSelf(Graphics graphics, Model.Rectangle bounds, double scaleFactor);
    }
}
