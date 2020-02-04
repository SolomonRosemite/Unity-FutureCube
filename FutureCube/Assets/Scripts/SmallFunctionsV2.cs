using UnityEngine.UI;
using UnityEngine;

public class SmallFunctionsV2 : MonoBehaviour
{
    public Text texter;
    public GameObject SetMeActive;
    public GameObject SetMeActiveV2;
    public GameObject SetMeActiveV3;
    public GameObject SetMeActiveV4;
    public GameObject SetMeActiveV5;

    void Start()
    {
        if (LevelJson.levelJson.Level06 != -1)
        {
            try { SetMeActiveV5.SetActive(true); } catch { }
        }
    }

    public void Go()
    {
        SetMeActive.SetActive(true);
        SetMeActiveV2.SetActive(false);
        GameObject.Find("GameHandler").GetComponent<SmallFunctionsV2>().SetText(" ");
    }

    public void ShowGameObject(bool Status)
    {
        SetMeActiveV3.SetActive(Status);
    }

    public void SetText(string context)
    {
        texter.text = context;
    }

    public void SetActiveGameObject()
    {
        SetMeActiveV4.SetActive(true);
    }

    public void OpenURL(string url)
    {
        Application.OpenURL(url);
    }

}
