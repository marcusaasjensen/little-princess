using UnityEngine;

public class HorseCollision : MonoBehaviour 
{
    [SerializeField] private Rigidbody rg;
    [SerializeField] private float bumpForce = 5f;
    
    private void OnCollisionEnter(Collision collision)
    {
        if (!collision.gameObject.CompareTag("Wall") && !collision.gameObject.CompareTag("Horse")) return;
        
        if (collision.gameObject.CompareTag("Wall"))
        {
            rg.AddForce(transform.forward * bumpForce, ForceMode.Impulse);
        }
    }
}