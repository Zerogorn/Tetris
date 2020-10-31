using Ui.Elements.Base;
using Ui.Elements.Windows.MainWindow.Widgets;
using UnityEngine;
using Zenject;
using UniRx;

namespace Ui.Elements.Windows.MainWindow
{
    public sealed class MainMenuView : ViewBase
    {
        [SerializeField] 
        private RectTransform _buttonContainer = null;

        [Inject] 
        private IFactory<Transform,  ButtonController> _factoryButtonController;

        public override void Initialize()
        {
            
        }

        public void AddButton(ButtonData data)
        {
            var button = _factoryButtonController.Create(_buttonContainer.transform);
            button.transform.SetParent(_buttonContainer);
            button.SetLabel(data.Label.Value);
            button.OnClick += unit =>
                              {
                                  data.Command.Execute(unit);
                              };
            
            data.Label.Subscribe(button.SetLabel).AddTo(this);
        }
    }
}