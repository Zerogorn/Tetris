using System;
using Ui.Elements.Hud.GameHud;
using UnityEngine;

namespace Ui.Obj
{
    [Serializable]
    public class HudObj
    {
        [SerializeField] 
        private GameHudView _gameHudView = null;

        public GameHudView GameHudView => _gameHudView;
    }
}