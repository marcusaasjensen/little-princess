using UnityEngine;

public class MenuManager : MonoBehaviour
{
    public void ToggleMenu(GameObject menu) => menu.SetActive(!menu.activeSelf);
}
