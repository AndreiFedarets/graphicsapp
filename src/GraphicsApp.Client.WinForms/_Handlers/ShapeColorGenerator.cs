using GraphicsApp.Model;

namespace GraphicsApp.Client.WinForms
{
    public sealed class ShapeColorGenerator : IAreaHandler
    {
        private readonly Color _baseColor;

        public ShapeColorGenerator(Color baseColor)
        {
            _baseColor = baseColor;
        }

        public Area Handle(Area area)
        {
            int maxDepth = GetMaxDepth(area, 1);
            AssignColor(area, _baseColor, 0, maxDepth);
            return area;
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
            float red = baseColor.R;
            float green = baseColor.G;
            float blue = baseColor.B;
            float correctionFactor = 1 - (float)(index) / stepsCount;
            red *= correctionFactor;
            green *= correctionFactor;
            blue *= correctionFactor;

            //red = (255 - red) * correctionFactor + red;
            //green = (255 - green) * correctionFactor + green;
            //blue = (255 - blue) * correctionFactor + blue;

            return Color.FromArgb(baseColor.A, (int)red, (int)green, (int)blue);
        }
    }
}
