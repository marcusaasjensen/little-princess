using Unity.VisualScripting;
using UnityEngine;

public class LapParticleManager : MonoBehaviour
{
    [SerializeField] private ParticleSystem lapParticle;
    
    public static LapParticleManager Instance { get; private set; }

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

    public void PlayLapParticle(Color color)
    {
        var main = lapParticle.main;
        main.startColor = color;
        lapParticle.Play();
    }
}