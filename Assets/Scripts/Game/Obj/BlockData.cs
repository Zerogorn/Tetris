
using System;
using Game.Block;
using UnityEngine;

namespace Game.Obj
{
    [Serializable]
    public sealed class BlockData
    {
        [SerializeField]
        private Blocks _type = Blocks.None;
        [SerializeField]
        private BlockController _blockController = null;

        public Blocks Type => _type;
        public BlockController BlockController => _blockController;
    }
}