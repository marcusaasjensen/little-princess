using UnityEngine;


public class HorseMovement : MonoBehaviour
{
   [SerializeField] private Rigidbody rg;
   [SerializeField] private float forwardMoveSpeed = 10f;
   [SerializeField] private float backwardMoveSpeed = -5f;
   [SerializeField] private float steerSpeed = 15f;
   
   private Vector2 _input;
   private float _driftValue;

   public void SetInput(Vector2 input) => _input = input;
   
   private void FixedUpdate() => MoveCar();
   
   public float ForwardMoveSpeed => forwardMoveSpeed;
   public float Speed { get; private set; }

   private void MoveCar()
   {
       var targetSpeed = _input.y > 0 ? forwardMoveSpeed : backwardMoveSpeed;
       
       if (_input.y == 0)
       {
           targetSpeed = 0;
       }

       Speed = Mathf.Lerp(Speed, targetSpeed, Time.fixedDeltaTime);
       
       rg.AddForce(transform.forward * Speed, ForceMode.Acceleration);
       
       var rotation = _input.x * steerSpeed * Time.fixedDeltaTime * Speed / forwardMoveSpeed;
       transform.Rotate(0, rotation, 0, Space.World);
   }
}