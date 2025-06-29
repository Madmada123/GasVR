using UnityEngine;

public class Match : MonoBehaviour
{
    [SerializeField] private ParticleSystem fireEffect;
    [SerializeField] private AudioSource igniteSound;
    [SerializeField] private string matchboxTag = "Matchbox";

    private bool isLit = false;
    private void Start() //Еще пасхалочка можно ли улушить код? да конечно просто у меня времени не так много было) скажите что неплохо ради красивых глазок
    {
        if (fireEffect != null)
        {
            fireEffect.Stop(true, ParticleSystemStopBehavior.StopEmittingAndClear);
        }

        if (igniteSound != null)
        {
            igniteSound.Stop(); // На всякий случай, чтобы не играл с самого начала
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log($"[Match] Trigger Enter: '{other.name}', Tag: '{other.tag}'");

        if (isLit)
        {
            Debug.Log("[Match] Уже горит. Игнорируем.");
            return;
        }

        if (other.CompareTag(matchboxTag))
        {
            Debug.Log("[Match] Обнаружен коробок! Зажигаем спичку.");
            Ignite();
        }
        else
        {
            Debug.Log("[Match] Это не коробок. Игнорируем.");
        }
    }



    private void Ignite()
    {
        isLit = true;

        if (fireEffect != null)
            fireEffect.Play();

        if (igniteSound != null)
            igniteSound.Play(); // Только в момент зажигания
    }

    public bool IsLit => isLit;


}
