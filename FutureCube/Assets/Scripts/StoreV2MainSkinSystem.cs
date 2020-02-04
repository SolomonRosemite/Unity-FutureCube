using UnityEngine;

public class StoreV2MainSkinSystem : MonoBehaviour
{
    public GameObject[] Selected;
    public GameObject[] PriceTag;

    void Start()
    {
        for (int i = 0; i < LoadJson.loadJson.CurrentSkin.Length; i++)
        {
            if (LoadJson.loadJson.CurrentSkin[i] == 0)
            {
                Selected[i].SetActive(false);
                PriceTag[i].SetActive(true);
            }
            else if (LoadJson.loadJson.CurrentSkin[i] == 1)
            {
                Selected[i].SetActive(false);
                PriceTag[i].SetActive(false);
            }
            else if (LoadJson.loadJson.CurrentSkin[i] == 2)
            {
                Selected[i].SetActive(true);
                PriceTag[i].SetActive(false);
            }
        }
    }

}
