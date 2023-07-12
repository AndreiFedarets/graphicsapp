namespace GraphicsApp.Client.WinForms
{
    internal static class TransformExtensions
    {
        public static Point ToDrawingPoint(this Model.Point point, Model.Rectangle bounds, double scaleFactor = 1)
        {
            double x = point.X * scaleFactor;
            //translate Y coordinate because coordinates start point (0,0) on a form
            // is top left corner, but not left bottom as in regular geometry
            double y = (bounds.TopRight.Y - point.Y) * scaleFactor;
            return new Point((int)x, (int)y);
        }
    }
}
