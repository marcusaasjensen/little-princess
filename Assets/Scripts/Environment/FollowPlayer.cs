using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    [SerializeField] private Transform player;
    [SerializeField] private float rotationSpeed = 5f;
    [SerializeField] private float faceRotationSpeed = 5f;
    [SerializeField] private float cameraFollowSpeed = 5f;
    [SerializeField] private float cameraDefaultYPosition;
    private Transform _transform;
    private float _inputX;
    private Camera _camera;
    private float _defaultFieldOfView;
    
    private void Awake()
    {
        _camera = Camera.main;
        _transform = transform;
    }
    
    private void Start() => _defaultFieldOfView = _camera.fieldOfView;

    private void FixedUpdate()
    {
        print(_defaultFieldOfView);
        _inputX = Input.GetAxis("Horizontal");

        var position = player.transform.position;
        
        _transform.position = Vector3.Lerp(_transform.position, new Vector3(position.x, cameraDefaultYPosition, position.z), Time.deltaTime * cameraFollowSpeed);

        var targetRotation = Quaternion.Euler(_inputX * faceRotationSpeed, player.eulerAngles.y, _inputX * faceRotationSpeed);
        transform.localRotation = Quaternion.Lerp(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
    }
    
    public void ChangeCameraFieldOfView(Vector2 input)
    {
        _camera.fieldOfView = Mathf.MoveTowards(_camera.fieldOfView, _defaultFieldOfView + input.y * 15, Time.deltaTime * 10);
    }
}