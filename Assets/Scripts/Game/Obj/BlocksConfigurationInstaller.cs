using UnityEngine;
using Zenject;

namespace Game.Obj
{
    [CreateAssetMenu(fileName = nameof(BlocksConfigurationInstaller), menuName = nameof(BlocksConfigurationInstaller))]
    public sealed class BlocksConfigurationInstaller : ScriptableObjectInstaller
    {
        [SerializeField]
        private BlocksConfiguration _blocksConfiguration = null;

        public override void InstallBindings()
        {
            Container.BindInstances(_blocksConfiguration);
        }
    }
}