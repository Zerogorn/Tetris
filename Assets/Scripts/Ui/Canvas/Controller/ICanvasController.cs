using Ui.Canvas.Containers.Base;

namespace Ui.Canvas.Controller
{
    public interface ICanvasController
    {
        TContainer GetContainer<TContainer>()
            where TContainer : IContainer;
    }
}