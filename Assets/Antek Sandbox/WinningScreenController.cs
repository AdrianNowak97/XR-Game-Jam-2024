using System.Collections.Generic;
using UnityEngine;

public class WinningScreenController : MonoBehaviour
{
    [SerializeField] private List<GameObject> medals = new List<GameObject>();
    
    void Start()
    {
        WinningConditionEventSystem.current.OnKnightComeBack += OnKnightComeBack;
    }
    

    void OnKnightComeBack(int howManyStars)
    {
        switch (howManyStars)
        {
            case 0:
                break;
            case 1:
                medals[0].SetActive(true);
                break;
            case 2:
                medals[0].SetActive(true);
                medals[1].SetActive(true);
                break;
            case 3:
                for (int i = 0; i < medals.Count-1; i++)
                {
                    medals[i].SetActive(true);
                }
                break;
        }
    }
}
