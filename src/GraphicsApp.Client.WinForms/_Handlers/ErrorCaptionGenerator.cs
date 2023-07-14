using GraphicsApp.Model;

namespace GraphicsApp.Client.WinForms
{
    public class ErrorCaptionGenerator : IAreaHandler
    {
        private readonly IBaseColorProvider _colorProvider;

        public ErrorCaptionGenerator(IBaseColorProvider colorProvider)
        {
            _colorProvider = colorProvider;
        }

        public Area Handle(Area area)
        {
            area = new Area(new Model.Point(0, 0), new Model.Point(200, 200));
            area.Attributes[nameof(Color)] = _colorProvider.BaseColor;

            var captionText = new StatusText("ERROR", area);
            captionText.Attributes[nameof(Color)] = Color.Red;

            return (Area)area.AssignChildren(new[]
            {
                captionText
            });
        }
    }
}
