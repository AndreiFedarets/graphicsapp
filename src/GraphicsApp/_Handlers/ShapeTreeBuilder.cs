using GraphicsApp.Model;

namespace GraphicsApp
{
    public sealed class ShapeTreeBuilder : IAreaHandler
    {
        private readonly IShapeIntersectionCalculator _intersectionCalculator;

        public ShapeTreeBuilder(IShapeIntersectionCalculator intersectionCalculator)
        {
            _intersectionCalculator = intersectionCalculator;
        }

        public Area Handle(Area area)
        {
            Shape[] shapes = area.Children.ToArray();
            Array.Sort(shapes, new ShapeAreaComparer(System.ComponentModel.ListSortDirection.Descending));
            IEnumerable<Shape> children = BuildChildren(0, area, shapes);
            area = (Area)area.AssignChildren(children);

            return area;
        }

        private IEnumerable<Shape> BuildChildren(int startIndex, Shape root, Shape[] shapes)
        {
            var children = new List<Shape>();
            for (int i = startIndex; i < shapes.Length; i++)
            {
                Shape shape = shapes[i];
                if (shape == null)
                {
                    continue;
                }

                if (!(root is Area) && _intersectionCalculator.HaveIntersection(shape, root))
                {
                    throw new Exception($"Shapes with tags #{root.Tag} and #{shape.Tag} have itersection");
                }

                if (root is Area || _intersectionCalculator.IsIncluded(shape, root))
                {
                    // exclude shape from building
                    shapes[i] = null;
                    var shapeChildren = BuildChildren(i + 1, shape, shapes);
                    shape = shape.AssignChildren(shapeChildren);
                    children.Add(shape);
                }
            }
            return children;
        }
    }
}
