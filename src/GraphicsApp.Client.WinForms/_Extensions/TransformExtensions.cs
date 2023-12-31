﻿namespace GraphicsApp.Client.WinForms
{
    internal static class TransformExtensions
    {
        /// <summary>
        /// Convert logical point to drawing point
        /// </summary>
        /// <param name="point">Point to convert</param>
        /// <param name="bounds">Bounds of logical area</param>
        /// <param name="scaleFactor">Visual scale (logical to visual)</param>
        /// <returns>Drawing point in the visual coordinates</returns>
        public static Point ToDrawingPoint(this Model.Point point, Model.Rectangle bounds, double scaleFactor = 1)
        {
            double x = point.X * scaleFactor;
            //translate Y coordinate because coordinates start point (0,0) on a form
            // is top left corner, but not left bottom as in regular geometry
            double y = (bounds.TopRight.Y - point.Y) * scaleFactor;
            return new Point((int)x, (int)y);
        }

        /// <summary>
        /// Convert logical rectangle to drawing rectangle
        /// </summary>
        /// <param name="rectange">Rectangle to convert</param>
        /// <param name="bounds">Bounds of logical area</param>
        /// <param name="scaleFactor">Visual scale (logical to visual)</param>
        /// <returns>Drawing rectange in the visual coordinates</returns>
        public static RectangleF ToDrawingRectangle(this Model.Rectangle rectange, Model.Rectangle bounds, double scaleFactor = 1)
        {
            // Mirror the point BottomLeft to UpperLeft because drawing rectangle uses it
            var point = new Model.Point(rectange.BottomLeft.X, rectange.TopRight.Y).ToDrawingPoint(bounds, scaleFactor);
            
            float width = rectange.Width * (float)scaleFactor;
            float height = rectange.Height * (float)scaleFactor;

            return new RectangleF(point.X, point.Y, width, height);
        }
    }
}
