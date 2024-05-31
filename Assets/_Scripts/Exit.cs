using UnityEngine;
using System.Collections;

// Quits the player when the user hits escape

public class Exit : MonoBehaviour
{
    void Update()
    {
        if (Input.GetKey("escape"))
        {
            Debug.Log("Quitting");
            Application.Quit();
        }
    }
}
