using SceneLoader;
using UnityEngine;

namespace Game.Block
{
    public sealed class BlockController : MonoBehaviour
    {
        [SerializeField]
        private Vector3 _rotatePosition;

        private float _previousTime;
        private float _fallTime = 0.5f;

        private GridData _gridData;

        public void Initialize(GridData gridData)
        {
            _gridData = gridData;
        }

        void Update()
        {
            Input();
            Move();
        }

        private void Input()
        {
            if (UnityEngine.Input.GetKeyDown(KeyCode.LeftArrow))
            {
                var vector = new Vector3(-1, 0, 0);
                transform.position += vector;

                if (!ValidMove())
                {
                    transform.position -= vector;
                }
            }
            else if (UnityEngine.Input.GetKeyDown(KeyCode.RightArrow))
            {
                var vector = new Vector3(1, 0, 0);
                transform.position += vector;

                if (!ValidMove())
                {
                    transform.position -= vector;
                }
            }
            else if (UnityEngine.Input.GetKeyDown(KeyCode.UpArrow))
            {
                var angel = 90;
                var vector = new Vector3(0, 0, 1);
                transform.RotateAround(transform.TransformPoint(_rotatePosition), vector, angel);

                if (!ValidMove())
                {
                    transform.RotateAround(transform.TransformPoint(_rotatePosition), vector, -angel);
                }
            }
        }

        private void Move()
        {
            if (Time.time - _previousTime > (UnityEngine.Input.GetKey(KeyCode.DownArrow) ? _fallTime / 10 : _fallTime))
            {
                transform.position -= new Vector3(0, 1, 0);

                if (!ValidMove())
                {
                    transform.position += new Vector3(0, 1, 0);
                    enabled = false;
                    AddToGrid();
                    CheckLines();
                    CheckGameOver();

                    FindObjectOfType<BlockSpawner>().Spawn();
                }

                _previousTime = Time.time;
            }
        }

        private void AddToGrid()
        {
            foreach (Transform child in transform)
            {
                int x = Mathf.RoundToInt(child.transform.position.x);
                int y = Mathf.RoundToInt(child.transform.position.y);

                _gridData.Grid[x, y] = child;
            }
        }

        private void CheckLines()
        {
            for (int i = _gridData.Height - 1; i >= 0; i--)
            {
                if (HasLine(i))
                {
                    DeleteLine(i);
                    RowDown(i);
                }
            }
        }

        private bool HasLine(int i)
        {
            for (int j = 0; j < _gridData.Width; j++)
            {
                if (_gridData.Grid[j, i] == null)
                {
                    return false;
                }
            }

            return true;
        }

        private void DeleteLine(int i)
        {
            for (int j = 0; j < _gridData.Width; j++)
            {
                Destroy(_gridData.Grid[j, i].gameObject);
                _gridData.Grid[j, i] = null;
            }
        }

        private void RowDown(int i)
        {
            for (int y = i; y < _gridData.Height; y++)
            {
                for (int j = 0; j < _gridData.Width; j++)
                {
                    if (_gridData.Grid[j, y] != null)
                    {
                        _gridData.Grid[j, y - 1] = _gridData.Grid[j, y];
                        _gridData.Grid[j, y] = null;
                        _gridData.Grid[j, y - 1].transform.position -= new Vector3(0,1,0);
                    }
                }
            }
        }

        private void CheckGameOver()
        {
            for (int i = 0; i < _gridData.Width; i++)
            {
                if (_gridData.Grid[i, _gridData.TopBorder] != null)
                {
                    var loader = new SceneLoaderManager();
                    loader.Load(SceneLoaderConst.MAIN);
                }
            }
        }

        private bool ValidMove()
        {
            foreach (Transform child in transform)
            {
                int x = Mathf.RoundToInt(child.transform.position.x);
                int y = Mathf.RoundToInt(child.transform.position.y);

                if (x <  0 || x >= _gridData.Width || y < 0)
                {
                    return false;
                }

                if (_gridData.Grid[x, y] != null)
                {
                    return false;
                }
            }

            return true;
        }
    }
}
