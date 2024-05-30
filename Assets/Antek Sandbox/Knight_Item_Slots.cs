using System;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;

public class Knight_Item_Slots : MonoBehaviour
{
    public bool isGrabbed;


    private void OnDrawGizmos()
    {
        Gizmos.DrawSphere(this.transform.position,0.5f);
    }

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
                    other.transform.position = Vector3.zero;
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
