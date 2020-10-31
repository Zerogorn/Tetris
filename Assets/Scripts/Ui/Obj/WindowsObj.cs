using System;
using Ui.Elements.Windows.MainWindow;
using Ui.Elements.Windows.MainWindow.Widgets;
using UnityEngine;

namespace Ui.Obj
{
    [Serializable]
    public sealed class WindowsObj
    {
        [SerializeField] 
        private MainMenuView _mainMenuView = null;
        [SerializeField]
        private ButtonController _buttonController = null;

        public MainMenuView MainMenuView => _mainMenuView;
        public ButtonController ButtonController => _buttonController;
    }
}