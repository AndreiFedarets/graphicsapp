using GraphicsApp.Model;
using System.Collections.Immutable;

namespace GraphicsApp.Client.WinForms.Visuals
{
    /// <summary>
    /// Visual representation of logical shape
    /// </summary>
    public abstract class ShapeVisual
    {
        private ImmutableList<ShapeVisual> _children;

        protected ShapeVisual(Shape shape)
        {
            Shape = shape;
            _children = shape.Children.Select(x => VisualFactory.Create(x)).ToImmutableList();
        }
        
        /// <summary>
        /// Logica shape
        /// </summary>
        public Shape Shape { get; }

        /// <summary>
        /// Draw shape and it's children
        /// </summary>
        /// <param name="graphics">Graphics instance</param>
        /// <param name="bounds">Bounds of logical area</param>
        /// <param name="scaleFactor">Visual scale (logical to visual)</param>
        public void Draw(Graphics graphics, Model.Rectangle bounds, double scaleFactor = 1)
        {
            DrawSelf(graphics, bounds, scaleFactor);
            foreach (var child in _children)
            {
                child.Draw(graphics, bounds, scaleFactor);
            }
        }

        /// <summary>
        /// Draw shape only
        /// </summary>
        /// <param name="graphics">Graphics instance</param>
        /// <param name="bounds">Bounds of logical area</param>
        /// <param name="scaleFactor">Visual scale (logical to visual)</param>
        protected abstract void DrawSelf(Graphics graphics, Model.Rectangle bounds, double scaleFactor);
    }
}
