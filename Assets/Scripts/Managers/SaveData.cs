using System;
using UnityEditor;
using UnityEngine;

[CreateAssetMenu(fileName = "NewSaveData", menuName = "ScriptableObjects/Save Data")]
[Serializable]
public class SaveData : ScriptableObject
{
    [SerializeField] private string currentScene;
    private Vector3 _playerPosition;
    
    public string CurrentScene
    {
        get => currentScene;
        set
        {
            EditorUtility.SetDirty(this);
            currentScene = value;
            AssetDatabase.SaveAssets();
        }
    }
    
    public Vector3 PlayerPosition
    {
        get => _playerPosition;
        set
        {
            EditorUtility.SetDirty(this);
            _playerPosition = value;
            AssetDatabase.SaveAssets();
        }
    }
}
