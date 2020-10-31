using UnityEngine.SceneManagement;

namespace SceneLoader
{
    public sealed class SceneLoaderManager
    {
        public void Load(string sceneName)
        {
            if (SceneManager.GetActiveScene().name == sceneName)
            {
                return;
            }

            SceneManager.LoadScene(sceneName);
        }
    }
}