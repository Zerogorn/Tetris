using Ui;
using Ui.Canvas;
using Ui.Canvas.Containers;
using Ui.Elements.Hud.GameHud;
using Zenject;

namespace SceneController.Game
{
    public sealed class GameSceneController : IInitializable
    {
        private readonly IUiManager _uiManager;
        private readonly CanvasManager _canvasManager;

        public GameSceneController(IUiManager uiManager, CanvasManager canvasManager)
        {
            _uiManager = uiManager;
            _canvasManager = canvasManager;
        }

        public void Initialize()
        {
            CreateDefaultUi();
        }

        private void CreateDefaultUi()
        {
            _canvasManager.CanvasController.GetContainer<FontContainer>().Hide();

            _uiManager.Show<GameHudView>();
        }
    }
}