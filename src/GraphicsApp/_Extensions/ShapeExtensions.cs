using GraphicsApp.Model;

namespace GraphicsApp
{
    public static class ShapeExtensions
    {
        public static Shape AssignChildren(this Shape shape, IEnumerable<Shape> children)
        {
            var copy = (Shape)Activator.CreateInstance(shape.GetType(), shape, children, shape.Attributes);
            copy.Tag = shape.Tag;
            return copy;
        }
    }
}
