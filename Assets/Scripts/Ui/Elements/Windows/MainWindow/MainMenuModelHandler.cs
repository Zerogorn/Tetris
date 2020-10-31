using System.Linq;
using Game;
using Game.Block;
using Game.Obj;
using Progress;
using SceneLoader;
using Ui.Elements.Windows.MainWindow.Widgets;
using UniRx;
using Zenject;

namespace Ui.Elements.Windows.MainWindow
{
    public sealed class MainMenuModelHandler : IInitializable
    {
        private readonly MainMenuModel _mainMenuModel;
        private readonly SceneLoaderManager _sceneLoaderManager;

        private readonly GameKernel _gameKernel;
        private readonly BlocksConfiguration _blocksConfigurationInstaller;
        private readonly ProgressManager _progressManager;

        public MainMenuModelHandler(MainMenuModel mainMenuModel, 
                                    SceneLoaderManager sceneLoaderManager,
                                    GameKernel gameKernel, 
                                    BlocksConfiguration blocksConfigurationInstaller,
                                    ProgressManager progressManager)
        {
            _mainMenuModel = mainMenuModel;
            _sceneLoaderManager = sceneLoaderManager;
            _gameKernel = gameKernel;
            _blocksConfigurationInstaller = blocksConfigurationInstaller;
            _progressManager = progressManager;
        }

        public void Initialize()
        {
            AddButtonStartGame();
            AddBlockButtons();
        }

        private void AddButtonStartGame()
        {
            var command = new ReactiveCommand();
            command.Subscribe(unit => _sceneLoaderManager.Load(SceneLoaderConst.GAME));
            _mainMenuModel.ButtonsData.Add(new ButtonData(command, "StartGame"));
        }

        private void AddBlockButtons()
        {
            var blocks = _blocksConfigurationInstaller.BlocksData.Where(x => x.Type != Blocks.None).ToList();

            for (int i = 0; i < blocks.Count(); i++)
            {
                var blockData = blocks[i];
                var command = new ReactiveCommand();
                var buttonData = new ButtonData(command, GetButtonName(blockData));

                command.Subscribe(unit =>
                                  {
                                      CallCommand(blockData);
                                      buttonData.Label.Value = GetButtonName(blockData);
                                  });
                _mainMenuModel.ButtonsData.Add(buttonData);
            }
        }

        private void CallCommand(BlockData blockData)
        {
            if (_gameKernel.HasBlock(blockData))
            {
                _gameKernel.RemoveBlockFromPoll(blockData);
            }
            else
            {
                _gameKernel.AddBlockToPoll(blockData);
            }

            _progressManager.Save();
        }

        private string GetButtonName(BlockData blockConfiguration)
        {
            return _gameKernel.HasBlock(blockConfiguration)
                ? $"{blockConfiguration.Type} +"
                : $"{blockConfiguration.Type} -";
        }
    }


}