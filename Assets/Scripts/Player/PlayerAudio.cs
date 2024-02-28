using UnityEngine;

public class PlayerAudio : MonoBehaviour
{
    [SerializeField] private AudioSource jumpAudio;
    [SerializeField] private AudioSource stepsAudio;
    
    public void PlayStepAudio() => stepsAudio.Play();
}
