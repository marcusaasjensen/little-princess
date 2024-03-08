using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class StartMenu : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI newGameButtonText;
    [SerializeField] private Button continueButton;

    private void Start()
    { 
        UnlockCursor(); 
        ManageButtons();
    }

    private void ManageButtons()
    {
        var hasSavedScene = SaveManager.Instance.LoadData().CurrentScene != string.Empty;
        if (continueButton)
        {
            continueButton.gameObject.SetActive(hasSavedScene);
        }

        if (newGameButtonText)
        {
            newGameButtonText.text = hasSavedScene ? "Restart" : "Start";
        }
    }

    private static void UnlockCursor()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }
}
