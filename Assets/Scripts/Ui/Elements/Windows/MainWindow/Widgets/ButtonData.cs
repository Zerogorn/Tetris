using UniRx;

namespace Ui.Elements.Windows.MainWindow.Widgets
{
    public sealed class ButtonData
    {
        private readonly ReactiveCommand<Unit> _reactiveCommand;
        private readonly ReactiveProperty<string> _label;

        public IReactiveCommand<Unit> Command => _reactiveCommand;
        public IReactiveProperty<string> Label => _label;

        public ButtonData(ReactiveCommand reactiveCommand, string label)
        {
            _reactiveCommand = reactiveCommand;
            _label = new ReactiveProperty<string>(label);
        }
    }
}