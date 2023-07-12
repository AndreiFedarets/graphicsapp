namespace GraphicsApp.Model
{
    public abstract class Shape
    {
        public AttributeCollection Attributes { get; } = new AttributeCollection();

        public abstract bool Contains(Point point);

        public abstract double GetArea();
    }
}
