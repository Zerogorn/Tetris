using System;
using System.Collections.Generic;
using Game;
using Game.Block;
using Game.Obj;
using UniRx;
using Zenject;

namespace Progress
{
    public sealed class ProgressManager : IInitializable
    {
        private readonly IProgressStrategy _progressStrategy;

        public ProgressManager(GameKernel gameKernel, BlocksConfiguration blocksConfiguration)
        {
            _progressStrategy  = new XmlProgressStrategy(gameKernel, blocksConfiguration);
        }

        public void Initialize()
        {
            Observable.OnceApplicationQuit().Subscribe(_ => { Save(); });

            _progressStrategy.Load();
        }

        public void Load()
        {
            _progressStrategy.Load();
        }

        public void Save()
        {
            _progressStrategy.Save();
        }

        [Serializable]
        public class ProgressObj
        {
            public List<Blocks> Blocks = new List<Blocks>();
            public List<int> Grid = new List<int>();

            public int Height = 0;
            public int Width = 0;
            public int TopBorder = 0;
        }
    }
}
