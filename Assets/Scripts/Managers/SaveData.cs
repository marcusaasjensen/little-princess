using System;
using System.Collections.Generic;
using DialogueSystem.Data;
using UnityEditor;
using UnityEngine;

[CreateAssetMenu(fileName = "NewSaveData", menuName = "ScriptableObjects/Save Data")]
[Serializable]
public class SaveData : ScriptableObject
{
    [SerializeField] private string currentScene;
    [SerializeField] private List<DialogueContainer> dialogueContainers;
    private Vector3 _playerPosition;
    
    public string CurrentScene
    {
        get => currentScene;
        set
        {
#if UNITY_EDITOR 
            EditorUtility.SetDirty(this);
#endif
            currentScene = value;
#if UNITY_EDITOR 
            AssetDatabase.SaveAssets();
#endif
        }
    }
    
    public Vector3 PlayerPosition
    {
        get => _playerPosition;
        set
        {
#if UNITY_EDITOR 
            EditorUtility.SetDirty(this);
#endif
            _playerPosition = value;
#if UNITY_EDITOR 
            AssetDatabase.SaveAssets();
#endif
        }
    }
    
    public void ResetAllDialogues()
    {
        foreach (var dialogueContainer in dialogueContainers)
        {
            dialogueContainer.ResetDialogue();
        }
    }
}
