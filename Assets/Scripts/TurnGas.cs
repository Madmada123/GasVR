using UnityEngine;

public class TurnGas : MonoBehaviour
{
    // === Public Property ===
    [field: SerializeField]
    public bool IsGasOn { get; private set; }

    // === Configuration ===
    [SerializeField] private float activationAngle = 45f;
    [SerializeField] private float maxGasAngle = 120f;

    // === Effects ===
    [SerializeField] private ParticleSystem gasParticles;
    [SerializeField] private AudioSource gasSound;

    // === Internal State ===
    private float startZ;

    private void Start()
    {
        startZ = transform.localEulerAngles.z;

        gasParticles?.Stop(true, ParticleSystemStopBehavior.StopEmittingAndClear);
        gasSound?.Stop();
    }

    private void Update()
    {
        float absAngle = Mathf.Abs(Mathf.DeltaAngle(startZ, transform.localEulerAngles.z));
        bool shouldBeOn = absAngle >= activationAngle && absAngle <= maxGasAngle;

        if (shouldBeOn && !IsGasOn)
        {
            IsGasOn = true;
            gasParticles?.Play();
            gasSound?.Play();
            Debug.Log("[TurnGas] Gas turned ON.");
        }
        else if (!shouldBeOn && IsGasOn)
        {
            IsGasOn = false;
            gasParticles?.Stop(true, ParticleSystemStopBehavior.StopEmittingAndClear);
            gasSound?.Stop();
            Debug.Log("[TurnGas] Gas turned OFF.");
        }
    }
}
