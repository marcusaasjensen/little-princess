using UnityEngine;

public class Void : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag("Player")) return;
        CheckpointManager.Instance.RespawnPlayer();
    }
}