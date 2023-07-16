using System.Collections.Immutable;

namespace GraphicsApp.Model
{
    /// <summary>
    /// Base shape class
    /// </summary>
    public abstract class Shape
    {
        /// <summary>
        /// Base constructor
        /// </summary>
        public Shape()
            : this(Enumerable.Empty<Shape>(), new AttributeCollection())
        {
        }

        /// <summary>
        /// Copy constructor
        /// </summary>
        /// <param name="children">Children to assign</param>
        /// <param name="attributes">Attributes to assign</param>
        public Shape(IEnumerable<Shape> children, AttributeCollection attributes)
        {
            Children = ImmutableList.CreateRange(children);
            Attributes = attributes;
        }

        public string Tag { get; set; }

        public AttributeCollection Attributes { get; }

        public ImmutableList<Shape> Children { get; }

        /// <summary>
        /// Check if the point is located inside (or on the edge) of the shape
        /// </summary>
        /// <param name="point">Point to check</param>
        /// <returns>True if the point is located inside (or on the edge) of the shape, otherwise - false</returns>
        public abstract bool ContainsPoint(Point point);

        /// <summary>
        /// Get area of the shape
        /// </summary>
        /// <returns>Area of the shape</returns>
        public abstract double GetArea();

        /// <summary>
        /// Get bounding rectangle of the shape
        /// </summary>
        /// <returns>Bounding rectangle</returns>
        public abstract Rectangle GetBounds();
    }
}
