namespace GraphicsApp.Client.WinForms
{
    internal static class PointExtensions
    {
        public static Point ToDrawingPoint(this Model.Point point, RectangleF rectangle, double transformFactor = 3)
        {
            double x = point.X * transformFactor;
            //translate Y coordinate because coordinates start point (0,0) on a form
            // is top left corner, but not left bottom as in regular geometry
            double y = rectangle.Bottom - point.Y * transformFactor;
            return new Point((int)x, (int)y);
        }
    }
}
