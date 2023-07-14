using GraphicsApp.Model;

namespace GraphicsApp.Client.WinForms
{
    public sealed class ShapeColorGenerator : IAreaHandler
    {
        private readonly IBaseColorProvider _colorProvider;

        public ShapeColorGenerator(IBaseColorProvider colorProvider)
        {
            _colorProvider = colorProvider;
        }

        public Area Handle(Area area)
        {
            int maxDepth = GetMaxDepth(area, 1);
            var color = _colorProvider.BaseColor;
            AssignColor(area, color, 0, maxDepth);
            return area;
        }

        private void AssignColor(Shape shape, Color baseColor, int level, int maxDepth)
        {
            Color color = GenerateColor(baseColor, level, maxDepth);
            shape.Attributes[nameof(Color)] = color;
            for (int i = 0; i < shape.Children.Count; i++)
            {
                AssignColor(shape.Children[i], baseColor, level + 1, maxDepth);
            }
        }

        private Color GenerateColor(Color baseColor, int index, int stepsCount)
        {
            float factor = 1 - (float)index / stepsCount;

            float red = baseColor.R * factor;
            float green = baseColor.G * factor;
            float blue = baseColor.B * factor;

            return Color.FromArgb(baseColor.A, (int)red, (int)green, (int)blue);
        }

        private int GetMaxDepth(Shape shape, int currentDepth)
        {
            int maxDepth = currentDepth;
            foreach (var child in shape.Children)
            {
                int childDepth = GetMaxDepth(child, currentDepth + 1);
                maxDepth = Math.Max(maxDepth, childDepth);
            }

            return maxDepth;
        }
    }
}
