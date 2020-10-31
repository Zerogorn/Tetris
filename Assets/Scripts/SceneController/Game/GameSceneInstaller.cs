using Game;
using Game.Block;
using Progress;
using SceneLoader;
using Ui.Installers;
using Zenject;

namespace SceneController.Game
{
    public sealed class GameSceneInstaller : MonoInstaller<GameSceneInstaller>
    {
        public override void InstallBindings()
        {
            GameElementsInstaller.Install(Container);

            Container.BindInterfacesAndSelfTo<SceneLoaderManager>().AsSingle();
            Container.BindInterfacesAndSelfTo<GameSceneController>().AsSingle();

            Container.BindInterfacesAndSelfTo<BlockSpawner>().FromComponentInNewPrefabResource(nameof(BlockSpawner)).AsSingle();

            Container.BindInterfacesAndSelfTo<ProgressManager>().AsSingle();
        }
    }
}