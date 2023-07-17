namespace GraphicsApp
{
    /// <summary>
    /// Configuration of Shapes file-provider
    /// </summary>
    public class FileShapeProviderConfig
    {
        public const int DefaultShapesLimit = 1000;

        /// <summary>
        /// Full path to source file
        /// </summary>
        public string FilePath { get; set; }

        /// <summary>
        /// Maximum count of shapes that can contain source file
        /// </summary>
        public int ShapesLimit { get; set; } = DefaultShapesLimit;
    }
}
