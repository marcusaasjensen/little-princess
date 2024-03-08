using UnityEngine;

[CreateAssetMenu(fileName = "NewSaveData", menuName = "ScriptableObjects/Save Data")]
public class SaveData : ScriptableObject
{
    [SerializeField] private string currentScene;
    
    public string CurrentScene
    {
        get => currentScene;
        set => currentScene = value;
    }
}
