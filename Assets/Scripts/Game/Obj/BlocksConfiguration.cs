using System;
using System.Collections.Generic;
using UnityEngine;

namespace Game.Obj
{
    [Serializable]
    public sealed class BlocksConfiguration
    {
        [SerializeField]
        private List<BlockData> _blocksData = null;

        public IList<BlockData> BlocksData => _blocksData;
    }
}