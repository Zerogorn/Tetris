using System.IO;
using System.Linq;
using System.Xml.Serialization;
using Game;
using Game.Block;
using Game.Obj;
using SceneLoader;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Progress
{
    public sealed class XmlProgressStrategy : IProgressStrategy
    {
        private const string PATH = "/Xml/progress.xml";

        private readonly GameKernel _gameKernel;
        private readonly BlocksConfiguration _blocksConfiguration;

        public XmlProgressStrategy(GameKernel gameKernel, BlocksConfiguration blocksConfiguration)
        {
            _gameKernel = gameKernel;
            _blocksConfiguration = blocksConfiguration;
        }

        public void Save()
        {
            var progressObj = GetProgressObj();
            SaveToXml(progressObj);
        }

        public void Load()
        {
            if (File.Exists(Application.dataPath + PATH))
            {
                var xml = new XmlSerializer(typeof(ProgressManager.ProgressObj));
                var stream = new FileStream(Application.dataPath + PATH, FileMode.Open);
                var kernel = (ProgressManager.ProgressObj)xml.Deserialize(stream);
                stream.Close();

                SetBlockData(kernel);
                SetGrid(kernel);
            }
        }

        private ProgressManager.ProgressObj GetProgressObj()
        {
            var progressObj = new ProgressManager.ProgressObj();

            foreach (var block in _gameKernel.Blocks)
            {
                progressObj.Blocks.Add(block.Type);
            }

            foreach (var grid in _gameKernel.GridData.Grid)
            {
                progressObj.Grid.Add(grid == null ? 0 : 1);
            }

            progressObj.Height = _gameKernel.GridData.Height;
            progressObj.Width = _gameKernel.GridData.Width;
            progressObj.TopBorder = _gameKernel.GridData.TopBorder;

            return progressObj;
        }

        private void SaveToXml(ProgressManager.ProgressObj progressObj)
        {
            var xml = new XmlSerializer(typeof(ProgressManager.ProgressObj));
            var stream = new FileStream(Application.dataPath + PATH, FileMode.Create);
            xml.Serialize(stream, progressObj);
            stream.Close();
        }

        private void SetBlockData(ProgressManager.ProgressObj kernel)
        {
            _gameKernel.Blocks.Clear();
            foreach (var type in kernel.Blocks)
            {
                var block = _blocksConfiguration.BlocksData.Single(x => x.Type == type);
                _gameKernel.Blocks.Add(block);
            }
        }

        private void SetGrid(ProgressManager.ProgressObj kernel)
        {
            if (SceneManager.GetActiveScene().name != SceneLoaderConst.GAME)
            {
                return;
            }

            var height = -1;
            var width = 0;
            for (var i = 0; i < kernel.Grid.Count; i++)
            {
                if (i != 0 && i % kernel.Height == 0)
                {
                    height = -1;
                    width++;
                }

                height++;

                if (kernel.Grid[i] == 0)
                {
                    _gameKernel.GridData.Grid[width, height] = null;
                }
                else
                {
                    var block = _blocksConfiguration.BlocksData.First(x => x.Type == Blocks.None);
                    var blockController = Object.Instantiate(block.BlockController);
                    blockController.transform.position = new Vector3(width, height, 0);
                    blockController.enabled = false;
                    _gameKernel.GridData.Grid[width, height] = blockController.transform;
                }
            }

            _gameKernel.GridData.Height = kernel.Height;
            _gameKernel.GridData.Width = kernel.Width;
            _gameKernel.GridData.TopBorder = kernel.TopBorder;
        }
    }
}