namespace GraphicsApp.Client.WinForms.Visuals
{
    /// <summary>
    /// Visual representation of area
    /// </summary>
    public class AreaVisual : RectangleVisual
    {
        public AreaVisual(Model.Area area)
            : base(area)
        {
        }

        /// <inheritdoc/>
        public new Model.Area Shape
        {
            get { return (Model.Area)base.Shape; }
        }

        /// <inheritdoc/>
        public void Draw(Graphics graphics)
        {
            graphics.Clear(SystemColors.Control);
            var bounds = Shape.GetBounds();
            var visualBounds = graphics.VisibleClipBounds;
            var scaleFactor = CalculateScaleFactor(bounds, visualBounds);
            Draw(graphics, bounds, scaleFactor);
        }

        /// <summary>
        /// Calculate logical to visual scale factor
        /// </summary>
        /// <param name="bounds"></param>
        /// <param name="visualBounds"></param>
        /// <returns></returns>
        private double CalculateScaleFactor(Model.Rectangle bounds, RectangleF visualBounds)
        {
            double heightScaleFactor = visualBounds.Height / bounds.Height;
            double widthScaleFactor = visualBounds.Width / bounds.Width;
            return Math.Min(heightScaleFactor, widthScaleFactor);
        }
    }
}
