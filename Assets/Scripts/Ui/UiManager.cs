using System;
using System.Collections.Generic;
using Ui.Elements;
using Ui.Elements.Base;

namespace Ui
{
    public sealed class UiManager<TCreator> : IUiManager
    where TCreator : ElementsCreatorBase
    {
        private readonly Dictionary<Type, ViewBase> _view;

        private readonly TCreator _elementsCreatorBase;
        
        private UiManager()
        {
            _view = new Dictionary<Type, ViewBase>();
        }

        public UiManager(TCreator elementsCreatorBase)
            : this()
        {
            _elementsCreatorBase = elementsCreatorBase;
        }

        public void Show<TView>()
            where TView : ViewBase
        {
            var type = typeof(TView);
            
            if (!_view.TryGetValue(type, out var view))
            {
                view = _elementsCreatorBase.Create<TView>();
                _view.Add(type, view);
            }
            
            view.Show();
        }

        public void Hide<TView>()
            where TView : ViewBase
        {
            var type = typeof(TView);

            _view[type].Hide();
        }
    }
}