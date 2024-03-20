using UnityEngine;
using UnityEngine.Events;

public class MenuInput : MonoBehaviour
{
    [SerializeField] private UnityEvent onEscapePressed;
    [SerializeField] private UnityEvent onMenuExit;
    
    private bool _isMenuOpen;
    
    private void Update() => HandleEscapeInput();
    
    private void HandleEscapeInput()
    {
        if (!Input.GetKeyDown(KeyCode.Escape)) return;
        onEscapePressed.Invoke();
        _isMenuOpen = !_isMenuOpen;
        if (!_isMenuOpen)
        {
            onMenuExit.Invoke();
        }
    }
}
