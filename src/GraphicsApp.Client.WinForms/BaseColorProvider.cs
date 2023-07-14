namespace GraphicsApp.Client.WinForms
{
    public class BaseColorProvider : IBaseColorProvider
    {
        public BaseColorProvider(Color initialColor)
        {
            BaseColor = initialColor;
        }

        public Color BaseColor { get; private set; }

        public event EventHandler BaseColorChanged;

        public void SetBaseColor(Color baseColor)
        {
            BaseColor = baseColor;
            BaseColorChanged?.Invoke(this, EventArgs.Empty);
        }
    }
}
