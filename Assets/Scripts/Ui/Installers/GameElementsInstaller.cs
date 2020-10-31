using Ui.Canvas;
using Ui.Elements;
using Ui.Elements.Hud.GameHud;
using Zenject;

namespace Ui.Installers
{
    public sealed class GameElementsInstaller : Installer<GameElementsInstaller>
    {
        public override void InstallBindings()
        {
            CanvasInstaller.Install(Container);

            Container.BindInterfacesAndSelfTo<GameHudModel>().AsSingle();
            Container.BindInterfacesAndSelfTo<GameHudModelHandler>().AsSingle();
            Container.BindInterfacesAndSelfTo<GameHudViewFactory>().AsSingle();

            Container.BindInterfacesAndSelfTo<ElementsCreatorGame>().AsSingle();

            Container.BindInterfacesAndSelfTo<UiManager<ElementsCreatorGame>>().AsSingle();
        }
    }
}