using UnityEngine;
using UnityEngine.Events;

public class PlayerInput : MonoBehaviour
{
    [SerializeField] private UnityEvent<Vector2> onPlayerMovement;
    [SerializeField] private UnityEvent onPlayerJump;
    
    [SerializeField] private KeyCode jumpKey = KeyCode.Space;
    
    private void Update()
    {
        var horizontalInput = Input.GetAxisRaw("Horizontal");
        var verticalInput = Input.GetAxisRaw("Vertical");
        var inputDir = new Vector2(horizontalInput, verticalInput);

        onPlayerMovement?.Invoke(inputDir);
        
        if (Input.GetKeyDown(jumpKey))
        {
            onPlayerJump?.Invoke();
        }
    }
}
