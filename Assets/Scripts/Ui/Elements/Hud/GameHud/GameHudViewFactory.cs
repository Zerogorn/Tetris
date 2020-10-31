using Ui.Canvas;
using Ui.Canvas.Containers;
using Ui.Obj;
using Zenject;

namespace Ui.Elements.Hud.GameHud
{
    public sealed class GameHudViewFactory : IFactory<GameHudView>
    {
        private readonly DiContainer _diContainer;
        private readonly HudObj _hudObj;
        private readonly CanvasManager _canvasManager;
        private readonly GameHudModel _gameHudModel;

        public GameHudViewFactory(DiContainer diContainer, 
                                  HudObj hudObj,
                                  CanvasManager canvasManager,
                                  GameHudModel gameHudModel)
        {
            _diContainer = diContainer;
            _hudObj = hudObj;
            _canvasManager = canvasManager;
            _gameHudModel = gameHudModel;
        }

        public GameHudView Create()
        {
            var parent = _canvasManager.CanvasController.GetContainer<HudContainer>().transform;
            var gameHudView = _diContainer.InstantiatePrefabForComponent<GameHudView>(_hudObj.GameHudView, parent);
            var presenter = new GameHudPresenter(gameHudView, _gameHudModel);
            presenter.Initialize();

            return gameHudView;
        }
    }
}