using UnityEngine;

public class ItemSpawnPoint : MonoBehaviour
{
    [SerializeField] private GameObject objectToSpawn;
   
    void Start()
    {
        WinningConditionEventSystem.current.OnKnightComeBack += OnKnightBack;
    }
    
    void OnKnightBack(int i)
    {
        Instantiate(objectToSpawn, this.transform.position, this.transform.rotation);
    }
}
