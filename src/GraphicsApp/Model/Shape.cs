using System.Collections.Immutable;

namespace GraphicsApp.Model
{
    public abstract class Shape
    {
        public Shape()
            : this(Enumerable.Empty<Shape>(), new AttributeCollection())
        {
        }

        public Shape(IEnumerable<Shape> children, AttributeCollection attributes)
        {
            Children = ImmutableList.CreateRange(children);
            Attributes = attributes;
        }

        public string Tag { get; set; }

        public AttributeCollection Attributes { get; }

        public ImmutableList<Shape> Children { get; }

        public abstract bool ContainsPoint(Point point);

        public abstract double GetArea();

        public abstract Rectangle GetBounds();
    }
}
