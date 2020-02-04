using UnityEngine.UI;
using UnityEngine;

public class SkinSystemForButtons : MonoBehaviour
{
    public static SkinSystemForButtons ins;

    void Start()
    {
        ins = this;
    }

    public void GetColor(Image image)
    {
        SkinSystem.ins.PlayerColor = image.color;

        // Save Color To Json
        LoadJson.loadJson.JsonEditPlayerColor(image.color);
    }

}
