using GraphicsApp.Model;
using System.Collections;
using System.ComponentModel;

namespace GraphicsApp
{
    internal sealed class ShapeAreaComparer : IComparer
    {
        private readonly ListSortDirection _direction;

        public ShapeAreaComparer(ListSortDirection direction = ListSortDirection.Ascending)
        {
            _direction = direction;
        }

        public int Compare(object x, object y)
        {
            double area1 = ((Shape)x).GetArea();
            double area2 = ((Shape)y).GetArea();

            return _direction == ListSortDirection.Ascending ?
                   area1.CompareTo(area2) :
                   area2.CompareTo(area1);
        }
    }
}
