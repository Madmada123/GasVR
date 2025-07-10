using UnityEngine;

public class Match : MonoBehaviour
{
    [SerializeField] private ParticleSystem fireEffect;
    [SerializeField] private AudioSource igniteSound;

    private bool isLit = false;

    private void Start()
    {
        // Optional: Only needed if PlayOnAwake is not disabled in Inspector
        fireEffect?.Stop(true, ParticleSystemStopBehavior.StopEmittingAndClear);
        igniteSound?.Stop();
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log($"[Match] Triggered by: '{other.name}'");

        if (isLit)
        {
            Debug.Log("[Match] Already lit. Skipping.");
            return;
        }

        if (other.TryGetComponent(out Matchbox matchbox))
        {
            Debug.Log("[Match] Matchbox detected. Igniting match.");
            Ignite();
        }
        else
        {
            Debug.Log("[Match] No matchbox component found. Ignored.");
        }
    }

    private void Ignite()
    {
        isLit = true;
        fireEffect?.Play();
        igniteSound?.Play();
    }

    public bool IsLit => isLit;
}
