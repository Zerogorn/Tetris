using Ui.Canvas;
using Ui.Canvas.Containers;
using Ui.Obj;
using Zenject;

namespace Ui.Elements.Windows.MainWindow
{
    public sealed class MainMenuViewFactory : IFactory<MainMenuView>
    {
        private readonly DiContainer _diContainer;
        private readonly WindowsObj _windowsObj;
        private readonly CanvasManager _canvasManager;
        private readonly MainMenuModel _mainMenuModel;
        
        public MainMenuViewFactory(DiContainer container, 
                                   WindowsObj windowsObj, 
                                   CanvasManager canvasManager,
                                   MainMenuModel mainMenuModel)
        {                                                                         
            _diContainer = container;
            _windowsObj = windowsObj;
            _canvasManager = canvasManager;
            _mainMenuModel = mainMenuModel;
        }

        public MainMenuView Create()
        {
            var parent = _canvasManager.CanvasController.GetContainer<WindowContainer>().transform;
            var mainMenuView = _diContainer.InstantiatePrefabForComponent<MainMenuView>(_windowsObj.MainMenuView, parent);
            var presenter = new MainMenuPresenter(mainMenuView, _mainMenuModel);
            presenter.Initialize();

            return mainMenuView;
        }
    }
}