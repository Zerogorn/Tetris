using System;
using Ui.Elements.Base;
using UniRx;
using UnityEngine;
using UnityEngine.UI;

namespace Ui.Elements.Hud.GameHud
{
    public sealed class GameHudView : ViewBase
    {
        [SerializeField] 
        private Button _back = null;

        public event Action<Unit> BackClick;

        public override void Initialize()
        {
            
        }

        private void Awake()
        {
            BackClick = unit => {};
        }

        private void Start()
        {
            _back.OnClickAsObservable().Subscribe(unit => BackClick?.Invoke(unit)).AddTo(this);
        }
    }
}