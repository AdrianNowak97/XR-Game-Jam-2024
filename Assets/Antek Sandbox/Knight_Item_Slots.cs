using System;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit.Interactables;

public class Knight_Item_Slots : MonoBehaviour
{
    [SerializeField] private Material _material;

    private XRGrabInteractable _xRGrabInteractable;
    private Outline _outline;

    private GameObject _item;

    private void OnTriggerStay(Collider other)
    {
        if (other.tag != "Item") return;
        if (other.gameObject != _item) return;

        if (_xRGrabInteractable.isSelected)
        {
            other.transform.SetParent(null);
            _outline.OutlineMode = Outline.Mode.OutlineAll;
        }
        else
        {
            other.transform.SetParent(this.transform);
            other.transform.localPosition = Vector3.zero;
            other.transform.localRotation = Quaternion.identity;
            _outline.OutlineMode = Outline.Mode.OutlineHidden;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag != "Item") return;
        if (_item != null) return;
        _item = other.gameObject;
        _outline = other.GetComponent<Outline>();
        _xRGrabInteractable = other.GetComponent<XRGrabInteractable>();
        _outline.OutlineMode = Outline.Mode.OutlineAll;
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag != "Item") return;
        if (other.gameObject != _item) return;
        _item = null;
        _outline.OutlineMode = Outline.Mode.OutlineHidden;
    }

    #region Gizmo
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawSphere(this.transform.position, 0.05f);
    }

    private void Awake()
    {
        var go = GameObject.CreatePrimitive(PrimitiveType.Sphere);
        go.transform.parent = this.transform;
        go.GetComponent<Renderer>().material = _material;
        go.transform.position = this.transform.position;
        go.GetComponent<Collider>().enabled = false;
        go.transform.localScale = new Vector3(0.1f, 0.1f, 0.1f);
    }
    #endregion
}
