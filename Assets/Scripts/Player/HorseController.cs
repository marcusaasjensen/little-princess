using UnityEngine;
using UnityEngine.Events;

public class HorseController : MonoBehaviour
{
    public UnityEvent<Vector2> onInput;
    
    private float _inputX;
    private float _inputY;
    private Vector2 _input;
    
    private bool _isFrozen;

    private void Update()
    {
        _inputX = _isFrozen ? 0 : Input.GetAxis("Horizontal");
        _inputY = _isFrozen ? 0 : Input.GetAxis("Vertical");
        
        _input = new Vector2(_inputX, _inputY).normalized;
        onInput.Invoke(_input);
    }
    
    public void FreezeInput(bool value) => _isFrozen = value;
}