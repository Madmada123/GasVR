using UnityEngine;

public class CheckWin : MonoBehaviour
{
    [SerializeField] private GameObject winUIPanel;

    public void ShowWinUI()
    {
        if (winUIPanel != null)
        {
            winUIPanel.SetActive(true); //а здесь ничего нету,  но я рад что вы посмотрели код и сделали ревью(пссс........ примите на работу)
        }
    }
}
