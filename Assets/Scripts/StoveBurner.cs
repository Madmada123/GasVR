using UnityEngine;

public class StoveBurner : MonoBehaviour
{
    [Header("Ссылки")]
    [SerializeField] private TurnGas gasValve; // Ссылка на объект газа (вентиль)
    [SerializeField] private ParticleSystem[] flameEffects; // Все огни конфорки
    [SerializeField] private CheckWin checkWin;
    [SerializeField] private float delayBeforeWinUI = 2f; // секунда-другая паузы

    private bool isIgnited = false;

    private void Start()
    {
        // На всякий случай гасим все огни при старте
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
        // Проверка уже сработавшего воспламенения
        if (isIgnited) return;

        // Проверяем: горящая ли это спичка?
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

        Debug.Log("[StoveBurner] Конфорка успешно зажжена!");

        //Отложенный вызов UI
        if (checkWin != null)
        {
            Invoke(nameof(TriggerWinUI), delayBeforeWinUI);
        }
    }

    private void TriggerWinUI()
    {
        checkWin.ShowWinUI();            //Пасхалочка для код ревью, мне нравится ваш эйчар Альмира или как правильно Алмира?
    }



}
