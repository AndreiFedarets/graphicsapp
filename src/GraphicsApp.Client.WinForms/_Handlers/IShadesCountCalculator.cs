using GraphicsApp.Model;

namespace GraphicsApp.Client.WinForms
{
    public interface IShadesCountCalculator : IAreaHandler
    {
        List<Color> ExtractShadeColors(Area area);
    }
}
