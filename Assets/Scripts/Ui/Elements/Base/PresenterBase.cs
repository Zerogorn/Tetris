using Zenject;

namespace Ui.Elements.Base
{
    public abstract class PresenterBase<TView, TModel> 
        where TModel : ModelBase
        where TView : ViewBase
    {
        protected TView View;
        protected TModel Model;

        protected PresenterBase(TView view, TModel model)
        {
            View = view;
            Model = model;
        }

        public abstract void Initialize();
    }
}