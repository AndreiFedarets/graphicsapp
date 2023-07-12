using GraphicsApp.Model;

namespace GraphicsApp.Client.WinForms.Visuals
{
    public class TriangleVisual : ShapeVisual
    {
        public TriangleVisual(Triangle triangle)
            : base(triangle)
        {
        }

        public new Triangle Shape
        {
            get { return (Triangle)base.Shape; }
        }

        public override void Draw(Graphics graphics)
        {
            var color = (Color)Shape.Attributes[nameof(Color)];
            var brush = new SolidBrush(color);
            var bounds = graphics.VisibleClipBounds;
            var points = new []
            {
                Shape.P1.ToDrawingPoint(bounds),
                Shape.P2.ToDrawingPoint(bounds),
                Shape.P3.ToDrawingPoint(bounds)
            };
            graphics.FillPolygon(brush, points);
        }
    }
}
