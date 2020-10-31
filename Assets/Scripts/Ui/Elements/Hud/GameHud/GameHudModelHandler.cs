using Progress;
using SceneLoader;
using Zenject;
using UniRx;

namespace Ui.Elements.Hud.GameHud
{
    public sealed class GameHudModelHandler : IInitializable
    {
        private readonly GameHudModel _gameHudModel;
        private readonly SceneLoaderManager _sceneLoaderManager;
        private readonly ProgressManager _progressManager;

        public GameHudModelHandler(GameHudModel gameHudModel, 
                                   SceneLoaderManager sceneLoaderManager,
                                   ProgressManager progressManager)
        {
            _gameHudModel = gameHudModel;
            _sceneLoaderManager = sceneLoaderManager;
            _progressManager = progressManager;
        }

        public void Initialize()
        {
            _gameHudModel.Command.Subscribe(unit =>
                                            {
                                                _sceneLoaderManager.Load(SceneLoaderConst.MAIN);
                                                _progressManager.Save();
                                            });
        }
    }
}