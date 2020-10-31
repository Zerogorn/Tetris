using System.Collections.Generic;
using Game.Block;
using Game.Obj;
using UnityEngine;
using Object = UnityEngine.Object;
using Random = UnityEngine.Random;

namespace Game
{
    public sealed class GameKernel
    {
        public List<BlockData> Blocks { get; }
        public GridData GridData { get; }

        public GameKernel()
        {
            Blocks = new List<BlockData>();
            GridData = new GridData();
        }

        public bool HasBlock()
        {
            return Blocks.Count > 0;
        }

        public BlockController GetRandomBlock(Transform parent)
        {
            var blockController  = Object.Instantiate(Blocks[Random.Range(0, Blocks.Count)].BlockController, parent.position, Quaternion.identity);
            blockController.Initialize(GridData);
            
            return blockController;
        }

        public bool HasBlock(BlockData blockController)
        {
            return Blocks.Contains(blockController);
        }

        public void AddBlockToPoll(BlockData blockController)
        {
            Blocks.Add(blockController);
        }

        public void RemoveBlockFromPoll(BlockData blockController)
        {
            Blocks.Remove(blockController);
        }
    }
}