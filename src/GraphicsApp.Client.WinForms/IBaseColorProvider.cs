namespace GraphicsApp.Client.WinForms
{
    public interface IBaseColorProvider
    {
        Color BaseColor { get; }

        event EventHandler BaseColorChanged;

        void SetBaseColor(Color baseColor);
    }
}
