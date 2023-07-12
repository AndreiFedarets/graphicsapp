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

        protected override void DrawSelf(Graphics graphics, Model.Rectangle bounds, double scaleFactor)
        {
            var color = (Color)Shape.Attributes[nameof(Color)];
            var brush = new SolidBrush(color);
            var points = new []
            {
                Shape.P1.ToDrawingPoint(bounds, scaleFactor),
                Shape.P2.ToDrawingPoint(bounds, scaleFactor),
                Shape.P3.ToDrawingPoint(bounds, scaleFactor)
            };
            graphics.FillPolygon(brush, points);
        }
    }
}
