using UnityEngine;

public class TurnGas : MonoBehaviour
{
    [Header("��������� ����")]
    public bool isGasOn = false;
    [SerializeField] private float activationAngle = 45f; // ����, � �������� ���������� ������ ����
    [SerializeField] private float maxGasAngle = 120f;    // �������� ������ ����

    [Header("�������")]
    [SerializeField] private ParticleSystem gasParticles;
    [SerializeField] private AudioSource gasSound;

    private float startZ;
    private ParticleSystem.EmissionModule emission;

    void Start() // ��������� ��� ������� ��������� ��� � ������ �����, � ���� ���� ���-���(� ��� ��� ������ �� 2 ����  54 ����� 34 ������) ����� ��� ��������))))
    {
        startZ = transform.localEulerAngles.z;

        if (gasParticles != null)
        {
            emission = gasParticles.emission;
            emission.rateOverTime = 0f;
            gasParticles.Stop();
        }

        if (gasSound != null)
        {
            gasSound.volume = 0f;
            gasSound.loop = true;
            gasSound.playOnAwake = false;
        }
    }

    void Update()
    {
        float currentZ = transform.localEulerAngles.z;
        float deltaAngle = Mathf.DeltaAngle(startZ, currentZ);
        float absDelta = Mathf.Abs(deltaAngle);

        // ������ ����
        isGasOn = absDelta >= activationAngle;

        // ������������� ���� �� 0 �� 1
        float intensity = Mathf.InverseLerp(activationAngle, maxGasAngle, absDelta);
        intensity = Mathf.Clamp01(intensity);

        // ���������� ���������
        if (gasParticles != null)
        {
            if (isGasOn)
            {
                if (!gasParticles.isPlaying) gasParticles.Play();
                emission.rateOverTime = Mathf.Lerp(5f, 50f, intensity);
            }
            else
            {
                emission.rateOverTime = 0f;
                if (gasParticles.isPlaying) gasParticles.Stop();
            }
        }

        // ���������� ������
        if (gasSound != null)
        {
            if (isGasOn)
            {
                if (!gasSound.isPlaying) gasSound.Play();
                gasSound.volume = intensity;
                // gasSound.pitch = Mathf.Lerp(0.8f, 1.2f, intensity); // �����������
            }
            else
            {
                gasSound.volume = 0f;
                if (gasSound.isPlaying) gasSound.Stop();
            }
        }
    }

    public bool IsGasOn => isGasOn;

}
