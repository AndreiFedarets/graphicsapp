namespace GraphicsApp.Client.WinForms.Visuals
{
    /// <summary>
    /// Visual representation of text
    /// </summary>
    public class TextVisual : RectangleVisual
    {
        private static readonly Font DefaultFont = SystemFonts.DefaultFont;

        public TextVisual(Model.Text text)
            : base(text)
        {
        }

        /// <inheritdoc/>
        public new Model.Text Shape
        {
            get { return (Model.Text)base.Shape; }
        }

        /// <inheritdoc/>
        protected override void DrawSelf(Graphics graphics, Model.Rectangle bounds, double scaleFactor)
        {
            var color = (Color)Shape.Attributes[nameof(Color)];
            var brush = new SolidBrush(color);
            var rectangle = Shape.ToDrawingRectangle(bounds, scaleFactor);

            // calculate scale factor for text to fill it's rectangle:
            // 1. measure current size of text
            SizeF valueSize = graphics.MeasureString(Shape.Value, DefaultFont);
            // 2. calculate scale by height
            float heightScaleRatio = Shape.Height / valueSize.Height;
            // 3. calculate scale by width
            float widthScaleRatio = Shape.Width / valueSize.Width;
            // 4. select min from them (to match min dimention)
            float fontScaleRatio = Math.Min(heightScaleRatio, widthScaleRatio);
            // 5. calculate size of font based on scale
            float scaleFontSize = DefaultFont.Size * fontScaleRatio;
            // 6. create new font
            Font font = new Font(DefaultFont.FontFamily, scaleFontSize);

            graphics.DrawString(Shape.Value, font, brush, rectangle);
        }
    }
}
