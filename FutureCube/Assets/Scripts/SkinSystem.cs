using System.Collections;
using UnityEngine;

public class SkinSystem : MonoBehaviour
{
    public static SkinSystem ins;
    public Color PlayerColor;
    void Start()
    {
        ins = this;

        StartCoroutine(GetSkin());
    }

    IEnumerator GetSkin()
    {
        yield return new WaitForSeconds(.5f);

        PlayerColor = LoadJson.loadJson.PlayerColor;
    }
}
