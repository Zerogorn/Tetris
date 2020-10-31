using Ui.Elements.Base;

namespace Ui
{
    public interface IUiManager
    {
        void Show<TView>()
            where TView : ViewBase;

        void Hide<TView>()
            where TView : ViewBase;
    }
}