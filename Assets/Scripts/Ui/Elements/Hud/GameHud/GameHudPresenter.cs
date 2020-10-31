using Ui.Elements.Base;

namespace Ui.Elements.Hud.GameHud
{
    public sealed class GameHudPresenter : PresenterBase<GameHudView, GameHudModel>
    {
        public GameHudPresenter(GameHudView view, GameHudModel model)
            : base(view, model)
        {
        }

        public override void Initialize()
        {
            Subscribe();
        }

        private void Subscribe()
        {
            View.BackClick += unit =>
                              {
                                  Model.Command.Execute(unit);
                              };
        }
    }
}