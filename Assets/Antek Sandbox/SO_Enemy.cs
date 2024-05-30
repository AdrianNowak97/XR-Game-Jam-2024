using UnityEngine;
[CreateAssetMenu]
public class SO_Enemy : ScriptableObject
{
    [Header("Enemy DMG")]
    public int enemyMagicDMG;
    public int enemyMeleeDMG;
    public int enemyRangeDMG;

    public Race _race;
    public Class _class;
    
     public enum Race
    {
        Rat,
        Kobold,
        Goblin,
        Halfling,
        Human,
        Elf,
        Orc,
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
