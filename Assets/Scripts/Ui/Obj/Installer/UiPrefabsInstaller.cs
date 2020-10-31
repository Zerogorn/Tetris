using UnityEngine;
using Zenject;

namespace Ui.Obj
{
    [CreateAssetMenu(fileName = nameof(UiPrefabsInstaller), menuName = nameof(ScriptableObjectInstaller))]
    public sealed class UiPrefabsInstaller : ScriptableObjectInstaller
    {
        [SerializeField] 
        private CanvasObj _canvasObj = null;

        [SerializeField] 
        private WindowsObj _windowsObj = null;

        [SerializeField] 
        private HudObj _hudObj = null;

        public override void InstallBindings()
        {
            Container.BindInstance(_canvasObj);
            Container.BindInstance(_windowsObj);
            Container.BindInstance(_hudObj);
        }
    }
}