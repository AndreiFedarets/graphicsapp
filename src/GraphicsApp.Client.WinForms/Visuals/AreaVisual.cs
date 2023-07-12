namespace GraphicsApp.Client.WinForms.Visuals
{
    public class AreaVisual : RectangleVilsual
    {
        public AreaVisual(Model.Area area)
            : base(area)
        {
        }

        public void Draw(Graphics graphics)
        {
            graphics.Clear(SystemColors.Control);
            var bounds = Shape.GetBounds();
            var visualBounds = graphics.VisibleClipBounds;
            var scaleFactor = CalculateScaleFactor(bounds, visualBounds);
            Draw(graphics, bounds, scaleFactor);
        }

        private double CalculateScaleFactor(Model.Rectangle bounds, RectangleF visualBounds)
        {
            double heightScaleFactor = visualBounds.Height / bounds.Height;
            double widthScaleFactor = visualBounds.Width / bounds.Width;
            return Math.Min(heightScaleFactor, widthScaleFactor);
        }
    }
}
