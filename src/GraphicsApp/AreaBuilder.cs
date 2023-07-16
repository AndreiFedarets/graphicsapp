using GraphicsApp.Model;

namespace GraphicsApp
{
    /// <summary>
    /// Represents builder of Area
    /// </summary>
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

        /// <summary>
        /// Shows if the builder has changes in the flow and Area needs to be built
        /// </summary>
        public bool HasChanges { get; set; }

        /// <summary>
        /// Append Area handler to the chain
        /// </summary>
        /// <param name="handler">Handler to add</param>
        /// <returns>This instance</returns>
        public AreaBuilder WithHandler(IAreaHandler handler)
        {
            HasChanges = true;
            _handlers.Add(handler);
            return this;
        }

        /// <summary>
        /// Appends failure handler to the flow (handler will be called in case success flow is failed)
        /// </summary>
        /// <param name="handler">Handler to add</param>
        /// <returns>This instance</returns>
        public AreaBuilder WithFailure(IAreaHandler handler)
        {
            HasChanges = true;
            _failures.Add(handler);
            return this;
        }

        /// <summary>
        /// Set provider of shapes for Area
        /// </summary>
        /// <param name="provider">Provider to set</param>
        /// <returns>This instance</returns>
        public AreaBuilder WithProvider(IShapeProvider provider)
        {
            HasChanges = true;
            _provider = provider;
            return this;
        }

        /// <summary>
        /// Build Area
        /// </summary>
        /// <returns>Result area</returns>
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
