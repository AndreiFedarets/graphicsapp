using GraphicsApp.Model;
using System.ComponentModel;

namespace GraphicsApp
{
    public sealed class ShapeAreaSorter : IAreaHandler
    {
        private readonly ListSortDirection _direction;

        public ShapeAreaSorter(ListSortDirection direction)
        {
            _direction = direction;
        }

        public Shape[] Handle(Shape[] shapes)
        {
            var comparer = new ShapeAreaComparer(_direction);
            Array.Sort(shapes, comparer);

            return shapes;
        }
    }
}
