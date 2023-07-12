using GraphicsApp.Model;
using System.Collections;
using System.Collections.Immutable;

namespace GraphicsApp.Model
{
    public class Area : IReadOnlyList<Shape>
    {
        private readonly ImmutableList<Shape> _shapes;

        public Area(IEnumerable<Shape> shapes)
        {
            _shapes = ImmutableList.CreateRange(shapes);
        }

        public Shape this[int index] => _shapes[index];

        public int Count => _shapes.Count;

        public IEnumerator<Shape> GetEnumerator()
        {
            return _shapes.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
