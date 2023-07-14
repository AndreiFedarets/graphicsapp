using GraphicsApp.Model;

namespace GraphicsApp.Client.WinForms
{
    public sealed class ShadesCountCalculator : IAreaHandler
    {
        public Area Handle(Area area)
        {
            HashSet<Color> colors = ExtractShadeColors(area);
            Text shadesNumberText = new StatusText(colors.Count.ToString(), area);
            shadesNumberText.Attributes[nameof(Color)] = Color.Black;
            return (Area)area.AssignChildren(area.Children.Append(shadesNumberText));
        }

        public HashSet<Color> ExtractShadeColors(Area area)
        {
            HashSet<Color> colors = new HashSet<Color>();
            ExtractShadeColors(area, 1, colors);
            return colors;
        }

        private void ExtractShadeColors(Shape shape, int level, HashSet<Color> colors)
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
