using GraphicsApp.Model;

namespace GraphicsApp
{
    public interface IShapeProvider
    {
        Task<IEnumerable<Shape>> GetShapesAsync();
    }
}
