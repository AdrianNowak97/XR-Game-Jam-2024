using System;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class Stats_Count_At_End : MonoBehaviour
{
    [SerializeField] private List<GameObject> inventorySlots = new List<GameObject>();
    [SerializeField] private List<SO_Enemy> enemyList = new List<SO_Enemy>();
    [SerializeField] private SO_Enemy acctualEnemy;

    private float pointsGained;
    
    private int allMagicDMG;
    private int allMeeleDMG;
    private int allRangeDMG;



    void RollRandomEnemy()
    {
        acctualEnemy = enemyList[Random.Range(0, enemyList.Count)];
    }

    void OnHorseSlap()
    {
        for (int i = 0; i < inventorySlots.Count -1; i++)
        {
           allMagicDMG += inventorySlots[i].GetComponentInChildren<ItemStats>().magicDMG;
           allMeeleDMG += inventorySlots[i].GetComponentInChildren<ItemStats>().meeleDMG;
           allRangeDMG += inventorySlots[i].GetComponentInChildren<ItemStats>().rangeDMG;
        }

        switch (acctualEnemy._class)
        {
            case SO_Enemy.Class.Warrior:
                pointsGained = allMagicDMG * 1.25f + allMeeleDMG + allRangeDMG * 0.95f;
                break;
            case SO_Enemy.Class.Ranged:
                pointsGained = allMagicDMG * 0.85f + allMeeleDMG * 1.25f + allRangeDMG;
                break;
            case SO_Enemy.Class.Mage:
                pointsGained = allMagicDMG + allMeeleDMG * 0.75f + allRangeDMG * 1.25f; 
                break;
            default:
                throw new ArgumentOutOfRangeException();
        }

        switch (acctualEnemy._race)
        {
            case SO_Enemy.Race.Rat:
                break;
            case SO_Enemy.Race.Kobold:
                break;
            case SO_Enemy.Race.Goblin:
                break;
            case SO_Enemy.Race.Halfling:
                break;
            case SO_Enemy.Race.Human:
                break;
            case SO_Enemy.Race.Elf:
                break;
            case SO_Enemy.Race.Orc:
                break;
            case SO_Enemy.Race.Troll:
                break;
            case SO_Enemy.Race.Demon:
                break;
            case SO_Enemy.Race.Roxy:
                break;
            default:
                throw new ArgumentOutOfRangeException();
        }
        
        
    }
}
