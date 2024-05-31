using System;
using System.Collections;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit.Interactables;

[RequireComponent(typeof(Outline))]
[RequireComponent(typeof(XRGrabInteractable))]
public class ItemStats : MonoBehaviour
{
    public Vector3 startingPosition;
    public Quaternion startRotation;

    public int bonusWith;
    public int withOutBonus;

    public ItemClass _itemClass;
    public Item _item;

    private WaitForSeconds _wait = new WaitForSeconds(1f);

    private void OnEnable()
    {
        WinningConditionEventSystem.OnNewItemGet += NewItemUnlocked;
    }

    private void Awake()
    {
        StartCoroutine(SafeCheck());
        startingPosition = transform.position;
        startRotation = transform.rotation;
    }

    private IEnumerator SafeCheck()
    {
        while (true)
        {
            yield return _wait;
            if (transform.position.y < -10)
            {
                transform.position = startingPosition;
                transform.rotation = startRotation;
            }
        }
    }

    public enum ItemClass
    {
        Nothing,
        Warrior,
        Range,
        Mage
    }

    public enum Item
    {
        miecz,
        młot,
        sztylet,
        włócznia,
        różdżka,
        łuk,
        kusza,
        tarczMała,
        tarczaDuża,
        antidotum,
        bandaże,
        świętySymbol,
        lampion,
        ziołaLecznicze,
        puszkaPiwa,
        martwySzczur,
        jedzenie,
        kołczan,
        kamień,
        kufel,
        chusteczka,
        rógWojenny,
        widelec,
        but,
        talerz,
        kielichZWinem,
        butelkaPlastikowa,
        puchar,
        monety,
        tarczaanytmagiczna
        
    }

    void NewItemUnlocked(SO_Enemy enemy)
    {
        switch (enemy._race)
        {
            case SO_Enemy.Race.Rat:
                if (_item == Item.martwySzczur)
                {
                    this.gameObject.SetActive(true);
                }
                break;
            case SO_Enemy.Race.Kobold:
                if (_item == Item.sztylet)
                {
                    this.gameObject.SetActive(true);
                }
                break;
            case SO_Enemy.Race.Goblin:
                if (_item == Item.tarczMała)
                {
                    this.gameObject.SetActive(true);
                }
                break;
            case SO_Enemy.Race.Halfling:
                if (_item == Item.puszkaPiwa || _item == Item.monety)
                {
                    this.gameObject.SetActive(true);
                }
                break;
            case SO_Enemy.Race.Human:
                if (_item == Item.antidotum)
                {
                    this.gameObject.SetActive(true);
                }
                break;
            case SO_Enemy.Race.Orc:
                if (_item == Item.włócznia || _item == Item.rógWojenny)
                {
                    this.gameObject.SetActive(true);
                }
                break;
            case SO_Enemy.Race.Elf:
                if (_item == Item.świętySymbol)
                {
                    this.gameObject.SetActive(true);
                }
                break;
            case SO_Enemy.Race.Troll:
                if (_item == Item.but)
                {
                    this.gameObject.SetActive(true);
                }
                break;
            case SO_Enemy.Race.Demon:
                if (_item == Item.tarczaanytmagiczna)
                {
                    this.gameObject.SetActive(true);
                }
                break;
            case SO_Enemy.Race.Roxy:
                if (_item == Item.puchar)
                {
                    this.gameObject.SetActive(true);
                }
                break;
            default:
                throw new ArgumentOutOfRangeException();
        }
    }
}
