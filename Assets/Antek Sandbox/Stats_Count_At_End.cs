using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Random = UnityEngine.Random;

public class Stats_Count_At_End : MonoBehaviour
{
    [SerializeField] private List<GameObject> inventorySlots = new List<GameObject>();
    [SerializeField] private GameObject weaponSlot;
    private List<ItemStats.Item> itemsList = new List<ItemStats.Item>();
    [SerializeField] private List<SO_Enemy> enemyList = new List<SO_Enemy>();
    private SO_Enemy acctualEnemy;

    private float pointsGained;
    private ItemStats itemsStats;

    public int howManyStarts;
    
    void RollRandomEnemy()
    {
        acctualEnemy = enemyList[Random.Range(0, enemyList.Count)];
    }

    void OnHorseSlap()
    {
        itemsStats = weaponSlot.GetComponentInChildren<ItemStats>();
        
        for (int i = 0; i < inventorySlots.Count -1; i++)
        {
            itemsList.Add(inventorySlots[i].GetComponentInChildren<ItemStats>()._item);
        }

        switch (acctualEnemy._class)
        {
            case SO_Enemy.Class.Warrior:
                switch (itemsStats._itemClass)
                {
                    case ItemStats.ItemClass.Nothing:
                        break;
                    case ItemStats.ItemClass.Warrior:
                        pointsGained += 0;
                        break;
                    case ItemStats.ItemClass.Range:
                        pointsGained += -25;
                        if (itemsList.Contains(ItemStats.Item.łuk) || itemsList.Contains(ItemStats.Item.kusza) &&
                            itemsList.Contains(ItemStats.Item.kołczan))
                        {
                            pointsGained += 25;
                        }
                        break;
                    case ItemStats.ItemClass.Mage:
                        pointsGained += 50;
                        break;
                    default:
                        throw new ArgumentOutOfRangeException();
                }

                switch (acctualEnemy._race)
                {
                    case SO_Enemy.Race.Rat:
                        RatStatsCheck(); 
                        break;
                    case SO_Enemy.Race.Kobold:
                        KoboldStatCheck();
                        break;
                    case SO_Enemy.Race.Goblin:
                        GoblinStatCheck();
                        break;
                    case SO_Enemy.Race.Human:
                        HumanStatCheck();
                        break;
                    case SO_Enemy.Race.Orc:
                        OrcStatCheck();
                        break;
                    case SO_Enemy.Race.Troll:
                        TrollStatCheck();
                        break;
                    case SO_Enemy.Race.Demon:
                        DemonStatCheck();
                        break;
                    case SO_Enemy.Race.Roxy:
                        break;
                    default:
                        throw new ArgumentOutOfRangeException();
                }

                if (itemsList.Contains(ItemStats.Item.tarczMała))
                {
                    pointsGained += 25;
                }
                break;
            case SO_Enemy.Class.Ranged:
                switch (itemsStats._itemClass)
                {
                    case ItemStats.ItemClass.Nothing:
                        break;
                    case ItemStats.ItemClass.Warrior:
                        pointsGained += 50;
                        break;
                    case ItemStats.ItemClass.Range:
                        pointsGained += 0;
                        break;
                    case ItemStats.ItemClass.Mage:
                        pointsGained += -25;
                        break;
                    default:
                        throw new ArgumentOutOfRangeException();
                }

                switch (acctualEnemy._race)
                {
                    case SO_Enemy.Race.Goblin:
                        GoblinStatCheck();
                        break;
                    case SO_Enemy.Race.Halfling:
                        HalflingStatsCheck();
                        break;
                    case SO_Enemy.Race.Human:
                        HumanStatCheck();
                        break;
                    case SO_Enemy.Race.Elf:
                        ElfStatCheck();
                        break;
                    case SO_Enemy.Race.Roxy:
                        break;
                    default:
                        throw new ArgumentOutOfRangeException();
                }

                if (itemsList.Contains(ItemStats.Item.tarczaDuża))
                {
                    pointsGained += 25;
                }
                else
                {
                    pointsGained += -10;
                }
                break;
            case SO_Enemy.Class.Mage:
                switch (itemsStats._itemClass)
                {
                    case ItemStats.ItemClass.Nothing:
                        break;
                    case ItemStats.ItemClass.Warrior:
                        pointsGained += -25;
                        break;
                    case ItemStats.ItemClass.Range:
                        pointsGained += 50;
                        break;
                    case ItemStats.ItemClass.Mage:
                        pointsGained += 0;
                        break;
                    default:
                        throw new ArgumentOutOfRangeException();
                }

                switch (acctualEnemy._race)
                {
                    case SO_Enemy.Race.Rat:
                        RatStatsCheck();
                        break;
                    case SO_Enemy.Race.Goblin:
                        GoblinStatCheck();
                        break;
                    case SO_Enemy.Race.Halfling:
                        HalflingStatsCheck();
                        break;
                    case SO_Enemy.Race.Human:
                        HumanStatCheck();
                        break;
                    case SO_Enemy.Race.Elf:
                        ElfStatCheck();
                        break;
                    case SO_Enemy.Race.Demon:
                        DemonStatCheck();
                        break;
                    case SO_Enemy.Race.Roxy:
                        break;
                    default:
                        throw new ArgumentOutOfRangeException();
                }

                if (itemsList.Contains(ItemStats.Item.tarczaanytmagiczna))
                {
                    pointsGained += 25;
                }
                break;
            default:
                throw new ArgumentOutOfRangeException();
        }

        if (itemsList.Contains(ItemStats.Item.ziołaLecznicze) || itemsList.Contains(ItemStats.Item.bandaże) ||
            itemsList.Contains(ItemStats.Item.jedzenie))
        {
            pointsGained += 25;
        }

        if (pointsGained > acctualEnemy.pointsNeeded)
        {
            if (pointsGained > 99)
            {
                howManyStarts = 3;
            }
            else if(pointsGained > 50 && pointsGained <= 99)
            {
                howManyStarts = 2;
            }
            else
            {
                howManyStarts = 1;
            }
        }
        else
        {
            howManyStarts = 0;
        }

        WinningConditionEventSystem.current.KnightComeBack(howManyStarts);
    }

    private void ElfStatCheck()
    {
        if (itemsList.Contains(ItemStats.Item.butelkaPlastikowa))
        {
            pointsGained += 25;
        }
    }

    private void HalflingStatsCheck()
    {
        if (itemsList.Contains(ItemStats.Item.sztylet))
        {
            pointsGained += 50;
        }
        else
        {
            pointsGained += -10;
        }
    }

    private void DemonStatCheck()
    {
        if (itemsList.Contains(ItemStats.Item.świętySymbol))
        {
            pointsGained += 25;
        }
        else
        {
            pointsGained += -25;
        }
    }

    private void TrollStatCheck()
    {
        if (itemsList.Contains(ItemStats.Item.martwySzczur))
        {
            pointsGained += 25;
        }

        if (itemsList.Contains(ItemStats.Item.włócznia) || itemsStats._itemClass == ItemStats.ItemClass.Range || itemsStats._itemClass == ItemStats.ItemClass.Mage)
        {
            pointsGained += 25;
        }
        
    }

    private void OrcStatCheck()
    {
        if (itemsList.Contains(ItemStats.Item.antidotum))
        {
            pointsGained += 25;
        }
        else
        {
            pointsGained -= 40;
        }

        if (itemsList.Contains(ItemStats.Item.martwySzczur))
        {
            pointsGained += 25;
        }
    }

    private void HumanStatCheck()
    {
        if (itemsList.Contains(ItemStats.Item.monety))
        {
            pointsGained += 25;
        }
    }

    private void GoblinStatCheck()
    {
        if (itemsList.Contains(ItemStats.Item.miecz) && itemsList.Contains(ItemStats.Item.sztylet))
        {
            pointsGained += 50;
        }
        else
        {
            pointsGained += -10;
        }

        if (itemsList.Contains(ItemStats.Item.martwySzczur))
        {
            pointsGained += 25;
        }
    }

    private void KoboldStatCheck()
    {
        if (itemsList.Contains(ItemStats.Item.lampion))
        {
            pointsGained += 25;
        }
        else
        {
            pointsGained += -50;
        }
    }

    private void RatStatsCheck()
    {
        if (itemsList.Contains(ItemStats.Item.młot))
        {
            pointsGained += 100;
        }
    }
}
