using Ui.Obj;
using UnityEngine;
using Zenject;

namespace Ui.Elements.Windows.MainWindow.Widgets
{
    public sealed class ButtonControllerFactory : IFactory<Transform, ButtonController>
    {
        private readonly DiContainer _diContainer;
        private readonly WindowsObj _windowsObj;

        public ButtonControllerFactory(DiContainer diContainer, WindowsObj windowsObj)
        {
            _diContainer = diContainer;
            _windowsObj = windowsObj;
        }

        public ButtonController Create(Transform transform)
        {
            return _diContainer.InstantiatePrefabForComponent<ButtonController>(_windowsObj.ButtonController, transform);
        }
    }
}