using Ui.Elements.Windows.MainWindow;
using Zenject;

namespace Ui.Elements
{
    public sealed class ElementsCreatorMenu : ElementsCreatorBase
    {
        public ElementsCreatorMenu(IFactory<MainMenuView> factoryMainMenuView)
        {
            Views.Add(typeof(MainMenuView), factoryMainMenuView);
        }
    }
}