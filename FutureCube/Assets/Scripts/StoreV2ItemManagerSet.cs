using UnityEngine;

public class StoreV2ItemManagerSet : MonoBehaviour
{
    public byte IndexItem;

    [Space]

    public GameObject Selected;
    public GameObject PriceTag;

    void Start()
    {
        try
        {
            // This is if there is a new Skin but not set in the Json yet.
            byte TrashTest = LoadJson.loadJson.CurrentSkin[IndexItem];
        }
        catch
        {
            LoadJson.loadJson.JsonEditSkinFix(IndexItem);
            print("new skin registered");
        }
    }

    void Update()
    {
        // 0 Is not Purchased, 1 is just Purchased, 2 is Purchased and Selected
        if (0 == LoadJson.loadJson.CurrentSkin[IndexItem])
        {
            Selected.SetActive(false);
            PriceTag.SetActive(true);
        }
        else if (1 == LoadJson.loadJson.CurrentSkin[IndexItem])
        {
            Selected.SetActive(false);
            PriceTag.SetActive(false);
        }
        else if (2 == LoadJson.loadJson.CurrentSkin[IndexItem])
        {
            Selected.SetActive(true);
            PriceTag.SetActive(false);
        }
    }
}
