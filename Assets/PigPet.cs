using System;
using System.Collections;
using UnityEngine;
using UnityEngine.VFX;

public class PigPet : MonoBehaviour
{
    public VisualEffect visualEffect;
    public bool isPlaying;

    private void Awake()
    {
        visualEffect = GetComponent<VisualEffect>();
    }


    public void Pet()
    {
        
        if (isPlaying == false)
        {
            isPlaying = true;
            visualEffect.Play();
            StartCoroutine(SpawnHearts());
        }
        
    }

    IEnumerator SpawnHearts()
    {
        yield return new WaitForSeconds(2);
        visualEffect.Stop();
        isPlaying = false;
    }
}

