using UnityEngine;

public class ThirdPersonCamera : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private Transform orientation;
    [SerializeField] private Transform playerHolder;
    [SerializeField] private Transform player;
    [SerializeField] private float rotationSpeed;

    
    private Vector2 _inputDirection;

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    public void SetInputDirection(Vector2 input) => _inputDirection = input;

    public void ToggleCursorLock()
    {
        Cursor.lockState = Cursor.lockState == CursorLockMode.Locked ? CursorLockMode.None : CursorLockMode.Locked;
        Cursor.visible = !Cursor.visible;
    }

    private void FixedUpdate()
    {
        _inputDirection = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
        var playerPosition = playerHolder.position;
        var camPosition = transform.position;
        var viewDir = playerPosition - new Vector3(camPosition.x, playerPosition.y, camPosition.z);
        orientation.forward = viewDir.normalized;

        var inputDir = orientation.forward * _inputDirection.y + orientation.right * _inputDirection.x;

        player.forward = Vector3.Slerp(player.forward, inputDir.normalized, Time.deltaTime * rotationSpeed);
    }
}
