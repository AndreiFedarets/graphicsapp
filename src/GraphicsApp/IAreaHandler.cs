using GraphicsApp.Model;

namespace GraphicsApp
{
    /// <summary>
    /// Represents Area handler
    /// </summary>
    public interface IAreaHandler
    {
        /// <summary>
        /// Perform required actions on Area
        /// </summary>
        /// <param name="area">Input Area</param>
        /// <returns>Result Area</returns>
        Area Handle(Area area);
    }
}
