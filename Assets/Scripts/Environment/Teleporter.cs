using UnityEngine;
using UnityEngine.Events;

public class Teleporter : MonoBehaviour
{
    [SerializeField] private Transform destination;
    [SerializeField] private Transform player;
    [SerializeField] private UnityEvent onPlayerTeleport;
    
    private void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag("Player")) return;
        player.position = destination.position;
        onPlayerTeleport.Invoke();
    }
}
