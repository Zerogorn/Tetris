using Ui.Elements.Base;

namespace Ui.Elements.Windows.MainWindow
{
    public sealed class MainMenuPresenter : PresenterBase<MainMenuView, MainMenuModel>
    {
        public MainMenuPresenter(MainMenuView mainMenuView, MainMenuModel mainMenuModel)
            : base (mainMenuView, mainMenuModel)
        {
            
        }

        public override void Initialize()
        {
            foreach (var buttonsData in Model.ButtonsData)
            {
                View.AddButton(buttonsData);   
            }
        }
    }
}