using UnityEngine;

public class CheckWin : MonoBehaviour
{
    [SerializeField] private GameObject winUIPanel;

    public void ShowWinUI()
    {
        if (winUIPanel != null)
        {
            winUIPanel.SetActive(true); //� ����� ������ ����,  �� � ��� ��� �� ���������� ��� � ������� �����(����........ ������� �� ������)
        }
    }
}
