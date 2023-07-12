using GraphicsApp.Model;

namespace GraphicsApp.Client.WinForms
{
    public sealed class ShapeColorGenerator : IShapeHandler
    {
        private readonly Color _baseColor;

        public ShapeColorGenerator(Color baseColor)
        {
            _baseColor = baseColor;
        }

        public Shape[] Handle(Shape[] shapes)
        {
            Random r = new Random();
            for (int i = 0; i < shapes.Length; i++)
            {
                Shape shape = shapes[i];
                //Color color = Color.FromArgb(255 - i * 5, _baseColor.R, _baseColor.G, _baseColor.R);
                Color color = Color.FromArgb(255, r.Next(255), r.Next(255), r.Next(255));
                shape.Attributes[nameof(Color)] = color;
            }

            return shapes;
        }
    }
}
