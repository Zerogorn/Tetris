using Ui.Elements.Hud.GameHud;
using Zenject;

namespace Ui.Elements
{
    public sealed class ElementsCreatorGame : ElementsCreatorBase
    {
        public ElementsCreatorGame(IFactory<GameHudView> factoryGameHudView)
        {
            Views.Add(typeof(GameHudView), factoryGameHudView);
        }
    }
}