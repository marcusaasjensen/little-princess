using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class CheckpointManager : MonoBehaviour
{
    [SerializeField] private List<Transform> checkpoints = new();
    [SerializeField] private GameObject player;
    [SerializeField] private UnityEvent onPlayerRespawn;
    private int _currentCheckpointIndex;
    
    public static CheckpointManager Instance { get; private set; }
    
    private void Awake() => Instance ??= this;

    public void RespawnPlayer()
    {
        player.transform.position = checkpoints[_currentCheckpointIndex].position;
        onPlayerRespawn.Invoke();
    }

    public Transform NextCheckpoint() => checkpoints[Mathf.Min(_currentCheckpointIndex + 1, checkpoints.Count - 1)];
    public void UpdateToNextCheckpoint() => _currentCheckpointIndex = Mathf.Min(_currentCheckpointIndex + 1, checkpoints.Count - 1);
}