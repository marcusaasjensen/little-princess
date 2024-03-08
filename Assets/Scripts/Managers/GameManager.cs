using UnityEngine;

public class GameManager : MonoBehaviour
{
    public void ToggleGamePause() => Time.timeScale = Time.timeScale == 0 ? 1 : 0;
}
