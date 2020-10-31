using Ui.Canvas;
using Ui.Elements;
using Ui.Elements.Windows.MainWindow;
using Ui.Elements.Windows.MainWindow.Widgets;
using Zenject;

namespace Ui.Installers
{
    public sealed class MenuElementsInstaller : Installer<MenuElementsInstaller>
    {
        public override void InstallBindings()
        {
            CanvasInstaller.Install(Container);

            Container.BindInterfacesAndSelfTo<ButtonControllerFactory>().WhenInjectedInto<MainMenuView>();
            Container.BindInterfacesAndSelfTo<MainMenuModel>().AsSingle();
            Container.BindInterfacesAndSelfTo<MainMenuModelHandler>().AsSingle();
            Container.BindInterfacesAndSelfTo<MainMenuViewFactory>().AsSingle();

            Container.BindInterfacesAndSelfTo<ElementsCreatorMenu>().AsSingle();
            
            Container.BindInterfacesAndSelfTo<UiManager<ElementsCreatorMenu>>().AsSingle();
        }
    }
}