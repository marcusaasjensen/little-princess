using UnityEngine;
using UnityEngine.Events;

public class HorseController : MonoBehaviour
{
    public UnityEvent<Vector2> onInput;
    
    private float _inputX;
    private float _inputY;
    private Vector2 _input;

    private void Update()
    {
        _inputX = Input.GetAxis("Horizontal");
        _inputY = Input.GetAxis("Vertical");
        
        _input = new Vector2(_inputX, _inputY).normalized;
        onInput.Invoke(_input);
    }
}