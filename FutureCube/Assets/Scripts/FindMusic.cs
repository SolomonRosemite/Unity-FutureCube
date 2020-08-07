using UnityEngine;

public class FindMusic : MonoBehaviour
{
    public static FindMusic ins;

    void Start()
    {
        ins = this;
    }

    public void Trigger()
    {
        try
        {
            GameObject.FindGameObjectWithTag("OnLoadDestroy").GetComponent<MusicTransition>().MusicFadeOut();
        }
        catch { }
    }

}
