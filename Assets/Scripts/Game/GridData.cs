using System;
using UnityEngine;

namespace Game
{
    [Serializable]
    public sealed class GridData
    {
        public int Height { get; set; } = 30;
        public int Width { get; set; } = 11;
        public int TopBorder { get; set; } = 20;

        public Transform[,] Grid { get; private set; }

        public GridData()
        {
            Grid = new Transform[Width, Height];
        }
    }
}