using GraphicsApp.Model;

namespace GraphicsApp
{
    public class AreaBuilder
    {
        private readonly SemaphoreSlim _buildSemaphore;
        private List<IAreaHandler> _handlers;
        private List<IAreaHandler> _failures;
        private IShapeProvider _provider;
        private Area _currentArea;

        public AreaBuilder()
        {
            _buildSemaphore = new SemaphoreSlim(1);
            _handlers = new List<IAreaHandler>();
            _failures = new List<IAreaHandler>();
        }

        public bool HasChanges { get; set; }

        public AreaBuilder WithHandler(IAreaHandler handler)
        {
            HasChanges = true;
            _handlers.Add(handler);
            return this;
        }

        public AreaBuilder WithFailure(IAreaHandler handler)
        {
            HasChanges = true;
            _failures.Add(handler);
            return this;
        }

        public AreaBuilder WithProvider(IShapeProvider provider)
        {
            HasChanges = true;
            _provider = provider;
            return this;
        }

        public T GetHandler<T>()
        {
            return (T)_handlers.FirstOrDefault(x => typeof(T).IsAssignableFrom(x.GetType()));
        }

        public async Task<Area> BuildAsync()
        {
            try
            {
                await _buildSemaphore.WaitAsync().ConfigureAwait(false);

                if (_provider == null)
                {
                    throw new InvalidOperationException("Provider is not set");
                }

                if (!HasChanges && _currentArea != null)
                {
                    return _currentArea;
                }

                var shapes = (await _provider.GetShapesAsync().ConfigureAwait(false)).ToArray();

                var area = new Area(shapes);
                foreach (var handler in _handlers)
                {
                    area = handler.Handle(area);
                }

                _currentArea = area;
                HasChanges = false;

            }
            catch (Exception)
            {
                var area = new Area(Enumerable.Empty<Shape>());
                foreach (var failure in _failures)
                {
                    area = failure.Handle(area);
                }
                _currentArea = area;
                HasChanges = false;
            }
            finally
            {
                _buildSemaphore.Release();
            }

            return _currentArea;
        }
    }
}
