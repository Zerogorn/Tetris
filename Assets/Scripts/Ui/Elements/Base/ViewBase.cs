using UnityEngine;
using Zenject;

namespace Ui.Elements.Base
{
    public abstract class ViewBase : MonoBehaviour , IInitializable
    {
        public abstract void Initialize();

        public void Show()
        {
            gameObject.SetActive(true);
        }

        public void Hide()
        {
            gameObject.SetActive(false);
        }
    }
}