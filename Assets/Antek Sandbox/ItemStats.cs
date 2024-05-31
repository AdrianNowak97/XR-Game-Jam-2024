using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit.Interactables;

[RequireComponent(typeof(Outline))]
[RequireComponent(typeof(XRGrabInteractable))]
public class ItemStats : MonoBehaviour
{
    
    public int bonusWith;
    public int withOutBonus;

    public ItemClass _itemClass;
    public Item _item;
    
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
