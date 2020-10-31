using Ui.Canvas.Controller;
using Zenject;

namespace Ui.Canvas
{
    public sealed class CanvasManager : IInitializable
    {
        private readonly IFactory<ICanvasController> _canvasFactory;

        public ICanvasController CanvasController { get; private set; }

        public CanvasManager(IFactory<ICanvasController> canvasFactory)
        {
            _canvasFactory = canvasFactory;
        }

        public void Initialize()
        {
            CanvasController = _canvasFactory.Create();
        }
    }
}