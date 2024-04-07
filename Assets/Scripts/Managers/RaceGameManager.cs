using System.Collections; using UnityEngine;
public class RaceGameManager : MonoBehaviour
{
    public HorseController playerControls;
    public AIControls[] aiControls;
    public TricolorLights tricolorLights;
    public FollowPlayer cameraFollow;
    public AudioClip lowBeep;
    public AudioClip highBeep;
    
    void Awake()
    {
        StartGame();
    }
    public void StartGame()
    {
        FreezePlayers(true);
        FreezeCameraFollow(true);
        StartCoroutine(Countdown());
    }
    IEnumerator Countdown()
    {
        yield return new WaitForSeconds(1);
        Debug.Log("3");
        
        tricolorLights.SetProgress(1);
        RaceAudioManager.Instance.PlayLightBeep(lowBeep);
        yield return new WaitForSeconds(1);
        Debug.Log("2");
        RaceAudioManager.Instance.PlayLightBeep(lowBeep);
        tricolorLights.SetProgress(2);
        yield return new WaitForSeconds(1);
        Debug.Log("1");
        RaceAudioManager.Instance.PlayLightBeep(lowBeep);
        tricolorLights.SetProgress(3);
        yield return new WaitForSeconds(1);
        Debug.Log("GO");
        RaceAudioManager.Instance.PlayLightBeep(highBeep);
        tricolorLights.SetProgress(4);
        StartRacing();
        RaceAudioManager.Instance.PlayMusic();
        yield return new WaitForSeconds(2f);
        tricolorLights.SetAllLightsOff();
    }
    public void StartRacing()
    {
        FreezePlayers(false);
        FreezeCameraFollow(false);
    }
    public void FreezePlayers(bool freeze)
    {
        playerControls.FreezeInput(freeze);
        foreach (var ai in aiControls)
        {
            ai.FreezeInput(freeze);
        }
    }
    
    void FreezeCameraFollow(bool freeze)
    {
        cameraFollow.enabled = !freeze;
    }
}