using GraphicsApp.Model;

namespace GraphicsApp.Client.WinForms.Visuals
{
    public abstract class ShapeVisual
    {
        protected ShapeVisual(Shape shape)
        {
            Shape = shape;
        }

        public Shape Shape { get; }

        public abstract void Draw(Graphics graphics);
    }
}
