using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

[RequireComponent(typeof(XRBaseInteractable))]
public class XROutlineByReference : MonoBehaviour
{
    [SerializeField] private Outline targetOutline;

    private void Awake()
    {
        targetOutline.enabled = false;

        var interactable = GetComponent<XRBaseInteractable>();
        interactable.hoverEntered.AddListener(_ => targetOutline.enabled = true);
        interactable.hoverExited.AddListener(_ => targetOutline.enabled = false);
    }
}
