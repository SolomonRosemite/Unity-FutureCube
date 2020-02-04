using UnityEngine;

public class starters : MonoBehaviour
{
    void Start()
    {
        Time.timeScale = 1;
        try { GameObject.FindGameObjectWithTag("OnLoadDestroy").GetComponent<AudioSource>().pitch = 1; } catch { }
    }
}
