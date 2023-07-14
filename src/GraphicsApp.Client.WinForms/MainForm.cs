using GraphicsApp.Client.WinForms.Visuals;

namespace GraphicsApp.Client.WinForms
{
    public partial class MainForm : Form
    {
        private readonly IBaseColorProvider _colorProvider;
        private readonly AreaBuilder _areaBuilder;
        private AreaVisual _areaVisual;

        public MainForm(AreaBuilder areaBuilder, IBaseColorProvider colorProvider)
        {
            InitializeComponent();
            _areaBuilder = areaBuilder;
            _colorProvider = colorProvider;
            Initialize();
        }

        private void Initialize()
        {
            var area = Task.Run(async () => await _areaBuilder.BuildAsync()).Result;
            _areaVisual = new AreaVisual(area);
            SelectBaseColorButton.BackColor = _colorProvider.BaseColor;
            DrawAreaVisual();
        }

        private void DrawAreaVisual()
        {
            using var graphics = DrawPanel.CreateGraphics();
            _areaVisual.Draw(graphics);
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            DrawAreaVisual();
        }

        protected override void OnResizeEnd(EventArgs e)
        {
            base.OnResizeEnd(e);
            DrawAreaVisual();
        }

        private void SelectBaseColorButtonClick(object sender, EventArgs e)
        {
            DialogResult result = colorDialog1.ShowDialog();
            if (result == DialogResult.OK)
            {
                _colorProvider.SetBaseColor(colorDialog1.Color);
                Initialize();
            }
        }

        private void SelectFileButtonClick(object sender, EventArgs e)
        {
            openFileDialog1.InitialDirectory = AppDomain.CurrentDomain.BaseDirectory;
            DialogResult result = openFileDialog1.ShowDialog();
            if (result == DialogResult.OK)
            {
                _areaBuilder.TakeTrianglesFromTextFile(new FileShapeProviderConfig()
                {
                    FilePath = openFileDialog1.FileName
                });
                Initialize();
            }
        }
    }
}