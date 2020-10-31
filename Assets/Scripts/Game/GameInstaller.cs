using Game.Obj;
using Progress;
using Zenject;

namespace Game
{
    public sealed class GameInstaller : MonoInstaller<GameInstaller>
    {
        [Inject]
        private BlocksConfiguration _blocksConfiguration;

        public override void InstallBindings()
        {
            Container.BindInterfacesAndSelfTo<GameKernel>().FromInstance(Load()).AsSingle();
        }

        private GameKernel Load()
        {
            var kernel = new GameKernel();
            var progressManager = new ProgressManager(kernel, _blocksConfiguration);
            progressManager.Load();
            
            return kernel;
        }
    }
}