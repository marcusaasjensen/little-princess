using UnityEngine;

public class RaceAudioManager : MonoBehaviour
{
    [SerializeField] private AudioSource checkpoint;
    [SerializeField] private AudioSource wind;
    [SerializeField] private AudioSource music;
    [SerializeField] private AudioSource lightsSource;
    [SerializeField] private Vector2 minMaxWindVolume;
    
    public static RaceAudioManager Instance { get; private set; }

    private void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }
    
    public void ChangeWindVolume(float volume)
    {
        wind.volume = Mathf.Lerp(minMaxWindVolume.x, minMaxWindVolume.y, volume);
        ChangeMusicVolume(.6f - wind.volume * .5f);
    }
    
    private void ChangeMusicVolume(float volume)
    {
        music.volume = volume;
    }
    
    public void PlayCheckpoint() => checkpoint.Play();

    public void PlayLightBeep(AudioClip lightClip)
    {
        lightsSource.PlayOneShot(lightClip);
    }

    public void PlayMusic()
    {
        music.Play();
    }
}
