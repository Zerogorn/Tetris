using Ui.Canvas.Controller;
using Ui.Obj;
using Zenject;

namespace Ui.Canvas
{
    public class UiCanvasFactory : IFactory<ICanvasController>
    {
        private readonly DiContainer _container;
        private readonly CanvasObj _canvasObj;

        public UiCanvasFactory(DiContainer container, CanvasObj canvasObj)
        {
            _container = container;
            _canvasObj = canvasObj;
        }

        public ICanvasController Create()
        {
            var canvasController = _container.InstantiatePrefabForComponent<CanvasController>(_canvasObj.CanvasController);
            canvasController.Initialize();

            return canvasController;
        }
    }
}