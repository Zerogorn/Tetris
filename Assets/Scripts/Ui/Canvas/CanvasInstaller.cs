using Ui.Canvas.Controller;
using Zenject;

namespace Ui.Canvas
{
    public sealed class CanvasInstaller : Installer<CanvasInstaller>
    {
        public override void InstallBindings()
        {
            Container.BindInterfacesAndSelfTo<UiCanvasFactory>().AsSingle();
            Container.BindInterfacesAndSelfTo<CanvasManager>().AsSingle();
        }
    }
}