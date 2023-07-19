using UnityEngine;
using UnityEngine.SceneManagement;

namespace RadiantTools.LevelManager
{
    public class LevelManager : MonoBehaviour
    {
        public static void OpenLevel(int levelNumber)
        {
            SceneManager.LoadScene(levelNumber);
        }

        public static void OpenNextLevel()
        {
            if (SceneManager.GetSceneByBuildIndex(SceneManager.GetActiveScene().buildIndex + 1).IsValid())
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
            }
        }
        public static int GetNextLevel()
        {
            int currentLevel = SceneManager.GetActiveScene().buildIndex;
            return currentLevel + 1;
        }
        public static void ReplayLevel()
        {
            SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().buildIndex);
        }

        public static void OpenMenu()
        {
            SceneManager.LoadSceneAsync(0);
        }
    }
}
