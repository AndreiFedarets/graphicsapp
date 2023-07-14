using GraphicsApp.Model;

namespace GraphicsApp.Client.WinForms
{
    public sealed class ShadesCountCalculator : IShadesCountCalculator
    {
        public Area Handle(Area area)
        {
            List<Color> colors = ExtractShadeColors(area);
            Text shadesNumberText = new StatusText(colors.Count.ToString(), area);
            shadesNumberText.Attributes[nameof(Color)] = Color.Black;
            return (Area)area.AssignChildren(area.Children.Append(shadesNumberText));
        }

        public List<Color> ExtractShadeColors(Area area)
        {
            List<Color> colors = new List<Color>();
            ExtractShadeColors(area, 1, colors);
            return colors;
        }

        private void ExtractShadeColors(Shape shape, int level, List<Color> colors)
        {
            if (colors.Count < level)
            {
                Color color = (Color)shape.Attributes[nameof(Color)];
                colors.Add(color);
            }

            foreach (var child in shape.Children)
            {
                ExtractShadeColors(child, level + 1, colors);
            }
        }

    }
}
