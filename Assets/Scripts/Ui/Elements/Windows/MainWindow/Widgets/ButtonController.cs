using System;
using TMPro;
using UniRx;
using UnityEngine;
using UnityEngine.UI;

namespace Ui.Elements.Windows.MainWindow.Widgets
{
    public sealed class ButtonController : MonoBehaviour
    {
        [SerializeField] 
        private TextMeshProUGUI _label = null;
        [SerializeField]
        private Button _button = null;

        private readonly CompositeDisposable _compositeDisposable = new CompositeDisposable();

        public event Action<Unit> OnClick;

        private void Awake()
        {
            OnClick = unit => { };
        }

        public void OnEnable()
        {
            _button.OnClickAsObservable().Subscribe(unit => OnClick?.Invoke(unit)).AddTo(_compositeDisposable);
        }

        public void OnDisable()
        {
            _compositeDisposable.Dispose();
        }

        public void SetLabel(string label)
        {
            _label.text = label;
        }
    }
}