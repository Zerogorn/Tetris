using Ui.Elements.Base;
using UniRx;

namespace Ui.Elements.Hud.GameHud
{
    public sealed class GameHudModel : ModelBase
    {
        private readonly ReactiveCommand<Unit> _reactiveCommand;

        public IReactiveCommand<Unit> Command => _reactiveCommand;

        public GameHudModel()
        {
            _reactiveCommand = new ReactiveCommand();
        }
    }
}