using GraphicsApp.Model;

namespace GraphicsApp
{
    public class AreaBuilder
    {
        private List<IAreaHandler> _handlers;
        private IShapeProvider _provider;

        public AreaBuilder()
        {
            _handlers = new List<IAreaHandler>();
        }

        public AreaBuilder WithHandler(IAreaHandler handler)
        {
            _handlers.Add(handler);
            return this;
        }

        public AreaBuilder WithProvider(IShapeProvider provider)
        {
            _provider = provider;
            return this;
        }

        public async Task<Area> BuildAsync()
        {
            var shapes = (await _provider.GetShapesAsync()).ToArray();

            var area = new Area(shapes);
            foreach (var handler in _handlers)
            {
                area = handler.Handle(area);
            }

            return area;
        }
    }
}
