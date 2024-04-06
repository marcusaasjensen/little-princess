using UnityEngine;
using UnityEngine.Events;

public class Checkpoint : MonoBehaviour
{
    [SerializeField] private UnityEvent onCheckpointReached;
    [SerializeField] private CheckpointManager checkpointManager;
    
    public UnityEvent OnCheckpointReached => onCheckpointReached;
    
    private void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag("Player")) return;
        if (checkpointManager.NextCheckpoint() != transform) return;
        checkpointManager.UpdateToNextCheckpoint();
        onCheckpointReached.Invoke();
    }
}