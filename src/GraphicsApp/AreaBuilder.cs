using GraphicsApp.Model;

namespace GraphicsApp
{
    public class AreaBuilder
    {
        private List<IShapeHandler> _handlers;
        private IShapeProvider _provider;

        public AreaBuilder()
        {
            _handlers = new List<IShapeHandler>();
        }

        public AreaBuilder WithHandler(IShapeHandler handler)
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

            foreach (var handler in _handlers)
            {
                shapes = handler.Handle(shapes);
            }

            return new Area(shapes);
        }
    }
}
