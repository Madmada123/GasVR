using UnityEngine;

public class Match : MonoBehaviour
{
    [SerializeField] private ParticleSystem fireEffect;
    [SerializeField] private AudioSource igniteSound;
    [SerializeField] private string matchboxTag = "Matchbox";

    private bool isLit = false;
    private void Start() //��� ���������� ����� �� ������� ���? �� ������� ������ � ���� ������� �� ��� ����� ����) ������� ��� ������� ���� �������� ������
    {
        if (fireEffect != null)
        {
            fireEffect.Stop(true, ParticleSystemStopBehavior.StopEmittingAndClear);
        }

        if (igniteSound != null)
        {
            igniteSound.Stop(); // �� ������ ������, ����� �� ����� � ������ ������
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log($"[Match] Trigger Enter: '{other.name}', Tag: '{other.tag}'");

        if (isLit)
        {
            Debug.Log("[Match] ��� �����. ����������.");
            return;
        }

        if (other.CompareTag(matchboxTag))
        {
            Debug.Log("[Match] ��������� �������! �������� ������.");
            Ignite();
        }
        else
        {
            Debug.Log("[Match] ��� �� �������. ����������.");
        }
    }



    private void Ignite()
    {
        isLit = true;

        if (fireEffect != null)
            fireEffect.Play();

        if (igniteSound != null)
            igniteSound.Play(); // ������ � ������ ���������
    }

    public bool IsLit => isLit;


}
