namespace GraphicsApp.Client.WinForms.Visuals
{
    public class TextVisual : RectangleVisual
    {
        private static readonly Font DefaultFont = SystemFonts.DefaultFont;

        public TextVisual(Model.Text text)
            : base(text)
        {
        }

        public new Model.Text Shape
        {
            get { return (Model.Text)base.Shape; }
        }

        protected override void DrawSelf(Graphics graphics, Model.Rectangle bounds, double scaleFactor)
        {
            var color = (Color)Shape.Attributes[nameof(Color)];
            var brush = new SolidBrush(color);
            var rectangle = Shape.ToDrawingRectangle(bounds, scaleFactor);

            SizeF valueSize = graphics.MeasureString(Shape.Value, DefaultFont);
            float heightScaleRatio = Shape.Height / valueSize.Height;
            float widthScaleRatio = Shape.Width / valueSize.Width;

            float fontScaleRatio = Math.Min(heightScaleRatio, widthScaleRatio);

            float scaleFontSize = DefaultFont.Size * fontScaleRatio;
            Font font = new Font(DefaultFont.FontFamily, scaleFontSize);

            graphics.DrawString(Shape.Value, font, brush, rectangle);
        }
    }
}
