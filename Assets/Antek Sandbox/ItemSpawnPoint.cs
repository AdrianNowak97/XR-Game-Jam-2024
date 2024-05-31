using UnityEngine;

public class ItemSpawnPoint : MonoBehaviour
{
    [SerializeField] private GameObject objectToSpawn;
   
    void OnEnable()
    {
        WinningConditionEventSystem.OnKnightComeBack += OnKnightBack;
    }

    void OnDisable()
    {
        WinningConditionEventSystem.OnKnightComeBack -= OnKnightBack;
    }
    
    void OnKnightBack(int i)
    {
        Instantiate(objectToSpawn, this.transform.position, this.transform.rotation);
    }
}
