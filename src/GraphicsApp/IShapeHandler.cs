using GraphicsApp.Model;

namespace GraphicsApp
{
    public interface IShapeHandler
    {
        Shape[] Handle(Shape[] shapes);
    }
}
