using System;
using Unity.VisualScripting;
using UnityEngine;

public class Knight_Item_Slots : MonoBehaviour
{
    public bool isGrabbed;
    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Item")
        {
            switch (isGrabbed)
            {
                case true:
                    other.transform.SetParent(null);
                    other.GetComponent<Outline>().OutlineMode = Outline.Mode.OutlineAll;
                    break;
                case false:
                    other.transform.SetParent(this.transform);
                    other.GetComponent<Outline>().OutlineMode = Outline.Mode.OutlineHidden;
                    break;
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        other.GetComponent<Outline>().OutlineMode = Outline.Mode.OutlineAll;
    }
    private void OnTriggerExit(Collider other)
    {
        other.GetComponent<Outline>().OutlineMode = Outline.Mode.OutlineHidden;
    }
}
