using UnityEngine;
using UnityEngine.SceneManagement;

namespace Project.Bootstrap
{
    public sealed class GameBootstrap : MonoBehaviour
    {
        private static GameBootstrap s_instance;

        [SerializeField] private string gameSceneName = "Game";

        private void Awake()
        {
            if (s_instance != null && s_instance != this)
            {
                Destroy(gameObject);
                return;
            }

            s_instance = this;
            DontDestroyOnLoad(gameObject);
        }

        private void Start()
        {
            LoadGameSceneIfNeeded();
        }

        private void LoadGameSceneIfNeeded()
        {
            var activeScene = SceneManager.GetActiveScene();
            if (activeScene.name == gameSceneName)
            {
                return;
            }

            SceneManager.LoadSceneAsync(gameSceneName, LoadSceneMode.Single);
        }
    }
}
