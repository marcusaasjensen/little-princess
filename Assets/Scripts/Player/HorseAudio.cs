using System.Collections;
using UnityEngine;
using UnityEngine.Serialization;

public class HorseAudio : MonoBehaviour
{ 
    [SerializeField] private HorseMovement horse;
    [SerializeField] private AudioSource gallopSource;
    [SerializeField] private AudioSource horseSource;
    [SerializeField] private AudioClip[] horseSounds;

    private void Start()
    {
        if(horseSounds is { Length: > 0 })
            StartCoroutine(PlayRandomHorseSoundCoroutine());
    }

    private void Update() 
    {
        RaceAudioManager.Instance.ChangeWindVolume(Mathf.Abs(horse.Speed / horse.ForwardMoveSpeed));
    }
    
    public void Mute(bool value)
    {
        if(gallopSource)
            gallopSource.mute = value;
        if(horseSource)
            horseSource.mute = value;
    }

    public void PlayGallop(Vector2 input)
    {
        if (input.y <= 0 || gallopSource.isPlaying) return;
        gallopSource.pitch = Random.Range(0.8f, 1.2f);
        gallopSource.Play();
    }
    
    public void PlayRandomHorseSound()
    {
        var randomClip = horseSounds[Random.Range(0, horseSounds.Length)];
        horseSource.pitch = Random.Range(0.8f, 1.2f);
        horseSource.PlayOneShot(randomClip);
    }

    public IEnumerator PlayRandomHorseSoundCoroutine()
    {
        while (true)
        {
            yield return new WaitForSeconds(Random.Range(4f, 8f));
            PlayRandomHorseSound();
        }
    }
}