using Ui.Elements.Base;
using Ui.Elements.Windows.MainWindow.Widgets;
using UniRx;

namespace Ui.Elements.Windows.MainWindow
{
    public class MainMenuModel : ModelBase
    {
        private readonly ReactiveCollection<ButtonData> _buttonsData;

        public IReactiveCollection<ButtonData> ButtonsData => _buttonsData;

        public MainMenuModel()
        {
            _buttonsData = new ReactiveCollection<ButtonData>();
        }
    }
}