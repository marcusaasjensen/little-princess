using UnityEngine;
using UnityEngine.Events;

public class Void : MonoBehaviour
{
    [SerializeField] UnityEvent onPlayerVoid;
    private void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag("Player")) return;
        onPlayerVoid.Invoke();
    }
}