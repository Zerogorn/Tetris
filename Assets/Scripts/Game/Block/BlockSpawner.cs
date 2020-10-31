using UnityEngine;
using Zenject;

namespace Game.Block
{
    public sealed class BlockSpawner : MonoBehaviour, IInitializable
    {
        [Inject]
        private GameKernel gameKernel = null;

        public void Spawn()
        {
            if (gameKernel.HasBlock())
            {
                gameKernel.GetRandomBlock(transform);
            }
        }

        public void Initialize()
        {
            Spawn();
        }
    }
}