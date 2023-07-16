namespace GraphicsApp.Client.WinForms.Visuals
{
    /// <summary>
    /// Visual representation of rectangle
    /// </summary>
    public class RectangleVisual : ShapeVisual
    {
        public RectangleVisual(Model.Rectangle rectangle)
            : base(rectangle)
        {
        }

        /// <inheritdoc/>
        public new Model.Rectangle Shape
        {
            get { return (Model.Rectangle)base.Shape; }
        }

        /// <inheritdoc/>
        protected override void DrawSelf(Graphics graphics, Model.Rectangle bounds, double scaleFactor)
        {
            var color = (Color)Shape.Attributes[nameof(Color)];
            var brush = new SolidBrush(color);
            var rectangle = Shape.ToDrawingRectangle(bounds, scaleFactor);
            graphics.FillRectangle(brush, rectangle);
        }
    }
}
