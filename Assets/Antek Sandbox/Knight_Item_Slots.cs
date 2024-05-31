using System;
using System.Collections;
using Unity.VisualScripting;
using Unity.XR.CoreUtils;
using UnityEditor;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit.Interactables;

public class Knight_Item_Slots : MonoBehaviour
{
    [SerializeField] private Material _material;

    private XRGrabInteractable _xRGrabInteractable;
    private Outline _outline;

    //Sound Scripts
    private bool isItemInSlot = false;
    [SerializeField] private SoundFXManager _soundFXManager;
    [SerializeField] private AudioClip _audioClip;
    //End Sound Scripts
    
    private GameObject _item;

    [SerializeField] private bool isWeaponSlot;

    private void OnEnable()
    {
        WinningConditionEventSystem.OnKnightComeBack += BackItem;
    }

    private void OnDisable()
    {
        WinningConditionEventSystem.OnKnightComeBack -= BackItem;
    }

    private void BackItem(int stars)
    {
        if (_outline)_outline.OutlineMode = Outline.Mode.OutlineHidden;
        if (_item) _item.transform.parent = null;
        if (_item) _item.transform.position = _item.transform.GetComponent<ItemStats>().startingPosition;
        if (_item) _item.transform.rotation = _item.transform.GetComponent<ItemStats>().startRotation;
        if (_item) _item.transform.GetComponent<Rigidbody>().isKinematic = true;
        _outline = null;
        _xRGrabInteractable = null;
        StartCoroutine(SetAsNonKinematic(_item));
        _item = null;
    }

    private IEnumerator SetAsNonKinematic(GameObject item)
    {
        if(item == null) yield break;
        yield return new WaitForSeconds(0.5f);
        item.transform.GetComponent<Rigidbody>().isKinematic = false;
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.tag != "Item") return;
        if (other.gameObject != _item) return;

        if (_xRGrabInteractable.isSelected)
        {
            other.transform.SetParent(null);
            _outline.OutlineMode = Outline.Mode.OutlineAll;
            isItemInSlot = false;
        }
        else
        {
            if (isWeaponSlot == true && _item.GetComponent<ItemStats>()._itemClass != ItemStats.ItemClass.Nothing)
            {
                other.transform.SetParent(this.transform);
                other.transform.localPosition = Vector3.zero;
                other.transform.localRotation = Quaternion.identity;
                _outline.OutlineMode = Outline.Mode.OutlineHidden;
            }
            else if (_item.GetComponent<ItemStats>()._itemClass == ItemStats.ItemClass.Nothing)
            {
                other.transform.SetParent(this.transform);
                other.transform.localPosition = Vector3.zero;
                other.transform.localRotation = Quaternion.identity;
                _outline.OutlineMode = Outline.Mode.OutlineHidden;
            }

            if (isItemInSlot == false)
            {
                _soundFXManager.SimpleFXClipPlay(_audioClip);
                isItemInSlot = true;
            }
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
        if(isWeaponSlot) Gizmos.color = Color.red;
        else Gizmos.color = Color.green;
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
