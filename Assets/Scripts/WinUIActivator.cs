using UnityEngine;

public class WinUIActivator : MonoBehaviour
{
    [SerializeField] private GameObject winUIPanel;

    public void ShowWinUI() => winUIPanel?.SetActive(true);
}
