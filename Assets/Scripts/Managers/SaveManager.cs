using UnityEngine;

public class SaveManager : MonoBehaviour 
{
    [SerializeField] private SaveData saveData;

    public static SaveManager Instance { get; private set; }

    private void Awake()
    {
        #region Singleton
        Instance ??= this;
        #endregion
    }
    
    public void SaveGame(string sceneName) => saveData.CurrentScene = sceneName;
    public void SaveGame(SceneManager sceneManager) => saveData.CurrentScene = sceneManager.GetCurrentScene();
    public SaveData LoadData() => saveData;

    public void DeleteSave()
    {
        saveData.PlayerPosition = Vector3.zero;
        saveData.ResetAllDialogues();
        saveData.CurrentScene = string.Empty;
    }
}