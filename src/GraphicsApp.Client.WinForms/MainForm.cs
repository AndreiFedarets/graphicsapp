using GraphicsApp.Client.WinForms.Visuals;

namespace GraphicsApp.Client.WinForms
{
    public partial class MainForm : Form
    {
        private readonly AreaBuilder _areaBuilder;
        private readonly AreaVisual _container;

        public MainForm(AreaBuilder areaBuilder)
        {
            _areaBuilder = areaBuilder;
            var area = Task.Run(async () => await _areaBuilder.BuildAsync()).Result;
            _container = new AreaVisual(area);
            InitializeComponent();
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            using var graphics = CreateGraphics();
            _container.Draw(graphics);
        }

        protected override void OnResizeEnd(EventArgs e)
        {
            base.OnResizeEnd(e);
            using var graphics = CreateGraphics();
            _container.Draw(graphics);
        }
    }
}