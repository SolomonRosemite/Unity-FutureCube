using UnityEngine;

public class SmallFunctionsV3 : MonoBehaviour
{
    public GameObject Tip;

    void Start()
    {
        try { TipFunc(); } catch { }
    }

    void TipFunc()
    {
        if (LoadJson.loadJson.PlayerName.Contains("Player"))
        {
            Tip.SetActive(true);
        }
        else
        {
            Tip.SetActive(false);
        }
    }

}
