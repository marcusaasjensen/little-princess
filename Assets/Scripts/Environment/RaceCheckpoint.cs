using UnityEngine.Events;
using UnityEngine;

public class RaceCheckpoint : MonoBehaviour
{
    public UnityEvent<HorseIdentity, RaceCheckpoint> onCheckpointEnter;
    private void OnTriggerEnter(Collider c)
    {
        var car = c.gameObject.GetComponent<HorseIdentity>();
        if (car == null) return;
        onCheckpointEnter.Invoke(car, this);
    }
}