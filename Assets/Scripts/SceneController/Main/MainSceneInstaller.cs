using Progress;
using SceneLoader;
using Ui;
using Ui.Elements;
using Ui.Installers;
using Zenject;

namespace SceneController.Main
{
    public sealed class MainSceneInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            MenuElementsInstaller.Install(Container);

            Container.BindInterfacesAndSelfTo<SceneLoaderManager>().AsSingle();
            Container.BindInterfacesAndSelfTo<MainSceneController>().AsSingle();

            Container.BindInterfacesAndSelfTo<ProgressManager>().AsSingle();
        }
    }
}