namespace GraphicsApp.Client.WinForms.Visuals
{
    public class RectangleVisual : ShapeVisual
    {
        public RectangleVisual(Model.Rectangle rectangle)
            : base(rectangle)
        {
        }

        public new Model.Rectangle Shape
        {
            get { return (Model.Rectangle)base.Shape; }
        }

        protected override void DrawSelf(Graphics graphics, Model.Rectangle bounds, double scaleFactor)
        {
            var color = (Color)Shape.Attributes[nameof(Color)];
            var brush = new SolidBrush(color);
            var points = new[]
            {
                Shape.BottomLeft.ToDrawingPoint(bounds, scaleFactor),
                new Model.Point(Shape.BottomLeft.X, Shape.TopRight.Y).ToDrawingPoint(bounds, scaleFactor),
                Shape.TopRight.ToDrawingPoint(bounds, scaleFactor),
                new Model.Point(Shape.TopRight.X, Shape.BottomLeft.Y).ToDrawingPoint(bounds, scaleFactor),
            };
            graphics.FillPolygon(brush, points);
        }
    }
}
