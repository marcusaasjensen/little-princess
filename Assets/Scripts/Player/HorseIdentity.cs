using UnityEngine;

public class HorseIdentity : MonoBehaviour
{
    [field: SerializeField] public string PlayerName { get; set; }
    [field: SerializeField] public Color CarColor { get; set; }
    public int LastPlayerCheckpoint { get; set; }  = -1;
    public int CurrentPlayerLap { get; set; }
}
