using System.Collections;
using UnityEngine.UI;
using UnityEngine;

public class StoreV2ItemManager : MonoBehaviour
{
    public byte SkinID;

    [Space]

    public GameObject Selected;
    public GameObject PriceShield;

    private bool SetSkinColor;

    public void Buy(int Price)
    {
        // Check if Item is already Purchased
        if (LoadJson.loadJson.CurrentSkin[SkinID] == 1 || LoadJson.loadJson.CurrentSkin[SkinID] == 2)
        {
            Select();
        }
        else if (LoadJson.loadJson.CurrentSkin[SkinID] == 0)
        {
            if (LoadJson.loadJson.V_Coins >= Price)
            {
                SetSkinColor = true;

                // buy Item with V Coins
                LoadJson.loadJson.JsonEditV_CoinsFixed(LoadJson.loadJson.V_Coins - Price);

                Reload(2, SkinID);
            }
            else
            {
                // not enough V Coins
                print("U don't have enough V Coins");
            }
        }
    }

    public void Reload(byte SkinStatus, byte Index)
    {
        for (int i = 0; i < LoadJson.loadJson.CurrentSkin.Length; i++)
        {
            if (LoadJson.loadJson.CurrentSkin[i] == 2)
            {
                LoadJson.loadJson.CurrentSkin[i] = 1;
            }
        }

        // Save Skin infos like (Skin is Purchased and Selected)
        LoadJson.loadJson.JsonEditSkin(2, SkinID);
    }

    public void Select()
    {
        Reload(2, SkinID);

        Selected.SetActive(true);
        PriceShield.SetActive(false);

        SetSkinColor = true;
    }

    public void _SetSkin(Image color)
    {
        StartCoroutine(SetSkin(color));
    }

    public IEnumerator SetSkin(Image color)
    {
        yield return new WaitForSeconds(.7f);

        if (SetSkinColor == true)
        {
            SkinSystemForButtons.ins.GetColor(color);
            SetSkinColor = false;

        }
    }

}
