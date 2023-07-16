using GraphicsApp.Model;

namespace GraphicsApp
{
    public static class ShapeExtensions
    {
        /// <summary>
        /// Create new shape with assigned children
        /// </summary>
        /// <param name="shape">Target shape</param>
        /// <param name="children">Children to assign</param>
        /// <returns>Copy of shape with assigned children</returns>
        public static Shape AssignChildren(this Shape shape, IEnumerable<Shape> children)
        {
            // create instance using copy ctor
            var copy = (Shape)Activator.CreateInstance(shape.GetType(), shape, children, shape.Attributes);
            copy.Tag = shape.Tag;
            return copy;
        }
    }
}
