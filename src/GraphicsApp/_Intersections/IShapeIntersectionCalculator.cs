using GraphicsApp.Model;

namespace GraphicsApp
{
    /// <summary>
    /// Represents intersection calculator for shapes pair
    /// </summary>
    public interface IShapeIntersectionCalculator
    {
        /// <summary>
        /// Check if pair of shapes is supported by the calculator
        /// </summary>
        /// <param name="shape1">First shape</param>
        /// <param name="shape2">Second shape</param>
        /// <returns></returns>
        bool Supports(Shape shape1, Shape shape2);

        /// <summary>
        /// Test if shape1 and shape2 have any intersection
        /// </summary>
        /// <param name="shape1">First shape</param>
        /// <param name="shape2">Second shape</param>
        /// <returns>True if shapes have intersection, otherwise - False</returns>
        bool HaveIntersection(Shape shape1, Shape shape2);

        /// <summary>
        /// Test if child is fully included into a parent (with no intersections)
        /// </summary>
        /// <param name="child">Potential child</param>
        /// <param name="parent">Potential parent</param>
        /// <returns></returns>
        bool IsIncluded(Shape child, Shape parent);
    }
}
