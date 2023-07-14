using GraphicsApp.Model;
using System.Collections;
using System.ComponentModel;

namespace GraphicsApp
{
    /// <summary>
    /// Compares two shapes by their area
    /// </summary>
    public sealed class ShapeAreaComparer : IComparer
    {
        private readonly ListSortDirection _direction;

        /// <summary>
        /// Create new instance of ShapeAreaComparer
        /// </summary>
        /// <param name="direction">Direction of comparing</param>
        public ShapeAreaComparer(ListSortDirection direction = ListSortDirection.Ascending)
        {
            _direction = direction;
        }

        /// <summary>
        /// Compare two shapes
        /// </summary>
        /// <param name="x">First shape</param>
        /// <param name="y">Second shape</param>
        /// <returns>Zero if areas are equal
        /// Less than zero if x area less than y area (for Ascending) and x area greater than y area (for Descending)
        /// Greater than zero if x area greater than y area (for Ascending) and x area less than y area (for Descending)</returns>
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
