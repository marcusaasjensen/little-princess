using TMPro;
using UnityEngine;

public class RaceUIManager : MonoBehaviour
{
    public TextMeshProUGUI lapText;
    public TextMeshProUGUI wonText;
    public GameObject restartText;
    public GameObject nextSceneText;
    
    public void UpdateLapText(string message) => lapText.text = message;

    public void ShowWonText(string carName)
    {
        wonText.text = carName == "Player" ? "You won.\n\nIt's time to go home..." : $"{carName} Won.\n\nIt's gonna be okay.";
        wonText.gameObject.SetActive(true);
    }
    
    public void ShowRestartText() => restartText.SetActive(true);
    
    public void ShowNextSceneText() => nextSceneText.SetActive(true);
}
