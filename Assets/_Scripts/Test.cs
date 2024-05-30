using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit.Interactables;

public class Test : MonoBehaviour
{
    [SerializeField] private XRGrabInteractable _grabInteractable;

    private void Update()
    {
        Debug.Log(_grabInteractable.isSelected);
    }
}
