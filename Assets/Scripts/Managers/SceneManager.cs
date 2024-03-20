using UnityEngine;

public class SceneManager : MonoBehaviour
{
    public static SceneManager Instance { get; private set; }
    [SerializeField] private bool autoSaveOnSceneChange = false;

    private void Awake()
    {
        #region Singleton
        Instance ??= this;
        #endregion
    }

    private void Start()
    {
        if (autoSaveOnSceneChange)
        {
            SaveManager.Instance.SaveGame(GetCurrentScene());
        }
    }
    
    public void LoadScene(string sceneName) => UnityEngine.SceneManagement.SceneManager.LoadScene(sceneName);
    public void LoadScene(int sceneIndex) => UnityEngine.SceneManagement.SceneManager.LoadScene(sceneIndex);

    public void LoadScene()
    {
        var saveData = SaveManager.Instance.LoadData();
        UnityEngine.SceneManagement.SceneManager.LoadScene(saveData.CurrentScene);
    }

    public void LoadNextScene() => UnityEngine.SceneManagement.SceneManager.LoadScene(UnityEngine.SceneManagement.SceneManager.GetActiveScene().buildIndex + 1);

    public void QuitGame(bool saveGame)
    {
        if (saveGame)
        {
            var sceneName = GetCurrentScene();
            SaveManager.Instance.SaveGame(sceneName);
        }

        Debug.Log("Quitting game...");
        Application.Quit();
    }

    public string GetCurrentScene() => UnityEngine.SceneManagement.SceneManager.GetActiveScene().name;
}