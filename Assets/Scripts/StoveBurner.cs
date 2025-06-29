using UnityEngine;

public class StoveBurner : MonoBehaviour
{
    [Header("������")]
    [SerializeField] private TurnGas gasValve; // ������ �� ������ ���� (�������)
    [SerializeField] private ParticleSystem[] flameEffects; // ��� ���� ��������
    [SerializeField] private CheckWin checkWin;
    [SerializeField] private float delayBeforeWinUI = 2f; // �������-������ �����

    private bool isIgnited = false;

    private void Start()
    {
        // �� ������ ������ ����� ��� ���� ��� ������
        foreach (var effect in flameEffects)
        {
            if (effect != null)
            {
                effect.Stop(true, ParticleSystemStopBehavior.StopEmittingAndClear);
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        // �������� ��� ������������ �������������
        if (isIgnited) return;

        // ���������: ������� �� ��� ������?
        Match match = other.GetComponent<Match>();
        if (match != null && match.IsLit && gasValve != null && gasValve.IsGasOn)
        {
            Ignite();
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

        Debug.Log("[StoveBurner] �������� ������� �������!");

        //���������� ����� UI
        if (checkWin != null)
        {
            Invoke(nameof(TriggerWinUI), delayBeforeWinUI);
        }
    }

    private void TriggerWinUI()
    {
        checkWin.ShowWinUI();            //���������� ��� ��� �����, ��� �������� ��� ����� ������� ��� ��� ��������� ������?
    }



}
