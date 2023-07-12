using System.Collections.Immutable;

namespace GraphicsApp.Model
{
    public abstract class Shape
    {
        public Shape(IEnumerable<Shape> children = null)
        {
            Children = ImmutableList.CreateRange(children ?? Enumerable.Empty<Shape>());
        }

        public string Tag { get; set; }

        public AttributeCollection Attributes { get; } = new AttributeCollection();

        public ImmutableList<Shape> Children { get; }

        public abstract bool ContainsPoint(Point point);

        public abstract double GetArea();

        public abstract Rectangle GetBounds();

        public abstract Shape AssignChildren(IEnumerable<Shape> children);
    }
}
