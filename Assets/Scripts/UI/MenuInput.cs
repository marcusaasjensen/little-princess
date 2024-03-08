using UnityEngine;
using UnityEngine.Events;

public class MenuInput : MonoBehaviour
{
    [SerializeField] private UnityEvent onEscapePressed;
    
    private void Update() => HandleEscapeInput();
    
    private void HandleEscapeInput()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            onEscapePressed.Invoke();
        }
    }
}
