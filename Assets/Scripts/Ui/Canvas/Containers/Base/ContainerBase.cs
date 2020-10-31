using UnityEngine;

namespace Ui.Canvas.Containers.Base
{
    public abstract class ContainerBase : MonoBehaviour , IContainer
    {
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