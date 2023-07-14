using GraphicsApp.Model;

namespace GraphicsApp
{
    /// <summary>
    /// Represents Shapes reader
    /// </summary>
    public interface IShapeProvider
    {
        /// <summary>
        /// Read shapes from the source
        /// </summary>
        /// <returns>Collection of shapes</returns>
        Task<IEnumerable<Shape>> GetShapesAsync();
    }
}
