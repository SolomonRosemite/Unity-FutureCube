using System.Collections;
using UnityEngine;

public class MusicTransition : MonoBehaviour
{
    public static MusicTransition musicTransition;
    public Animator MusicAni;

    private void Start()
    {
        musicTransition = this;
    }

    public void DontDestroy()
    {
        DontDestroyOnLoad(this);
    }

    public void MusicFadeOut()
    {
        MusicAni.SetTrigger("FadeOut");
    }
}
