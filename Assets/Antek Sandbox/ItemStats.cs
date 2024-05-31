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

    private void Awake()
    {
        startingPosition = transform.position;
        startRotation = transform.rotation;
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
}
