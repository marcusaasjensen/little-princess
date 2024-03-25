using UnityEngine;
using UnityEngine.Events;

public class Checkpoint : MonoBehaviour
{
    [SerializeField] private UnityEvent onCheckpointReached;
    
    private void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag("Player")) return;
        if (CheckpointManager.Instance.NextCheckpoint() != transform) return;
        CheckpointManager.Instance.UpdateToNextCheckpoint();
        onCheckpointReached.Invoke();
    }
}