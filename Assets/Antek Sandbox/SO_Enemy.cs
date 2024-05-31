using UnityEngine;
[CreateAssetMenu]
public class SO_Enemy : ScriptableObject
{
    public int pointsNeeded;
    
    public Race _race;
    public Class _class;

    public string enemyInfo;
    
     public enum Race
    {
        Rat,
        Kobold,
        Goblin,
        Halfling,
        Human,
        Orc,
        Elf,
        Troll,
        Demon,
        Roxy
    }

    public enum Class
    {
        Warrior,
        Ranged,
        Mage
    }
}
