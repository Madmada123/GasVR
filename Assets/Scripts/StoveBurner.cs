using UnityEngine;
using System.Collections;


public class StoveBurner : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private TurnGas gasValve;
    [SerializeField] private ParticleSystem[] flameEffects;
    [SerializeField] private WinUIActivator WinUIActivator;
    [SerializeField] private float delayBeforeWinUI = 2f;

    private bool isIgnited = false;

    private void Start()
    {
        // Ensure all flames are off at the start
        foreach (var effect in flameEffects)
        {
            effect?.Stop(true, ParticleSystemStopBehavior.StopEmittingAndClear);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        // Skip if already ignited
        if (isIgnited || !other.TryGetComponent(out Match match)) return;

        if (match.IsLit && gasValve?.IsGasOn == true)
        {
            Debug.Log("[StoveBurner] Lit match detected and gas is on. Igniting...");
            Ignite();
        }
        else
        {
            Debug.Log("[StoveBurner] Conditions not met: either match is not lit or gas is off.");
        }
    }

    private void Ignite()
    {
        isIgnited = true;

        foreach (var effect in flameEffects)
        {
            if (effect != null && !effect.isPlaying)
            {
                effect.Play();
            }
        }

        Debug.Log("[StoveBurner] Burner successfully ignited.");

        if (WinUIActivator != null)
        {
            StartCoroutine(TriggerWinUIDelayed());
        }
    }

    private IEnumerator TriggerWinUIDelayed()
    {
        yield return new WaitForSeconds(delayBeforeWinUI);
        WinUIActivator.ShowWinUI();
    }

    public bool IsIgnited => isIgnited;
}
