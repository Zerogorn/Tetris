using Ui;
using Ui.Elements.Windows.MainWindow;
using Zenject;

namespace SceneController.Main
{
    public sealed class MainSceneController : IInitializable
    {
        private readonly IUiManager _uiManager;

        public MainSceneController(IUiManager uiManager)
        {
            _uiManager = uiManager;
        }

        public void Initialize()
        {
            CreateDefaultUi();
        }

        private void CreateDefaultUi()
        {
            _uiManager.Show<MainMenuView>();
        }
    }
}