using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;

public class IdeasMuseumUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI ideasCounterText;
    [SerializeField] private UnityEvent onIdeasVisited;
    private int ideasCounter;
    
    public void IncrementIdeasCounter()
    {
        ideasCounter++;
        if (ideasCounter == 4)
        {
            onIdeasVisited.Invoke();
        }
        UpdateText();
    }
    
    private void UpdateText()
    {
        Debug.Log($"Ideas: {ideasCounter}");
        ideasCounterText.text = $"Ideas {ideasCounter} / 4";
    }
}
