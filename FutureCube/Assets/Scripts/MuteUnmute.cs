using UnityEngine;

public class MuteUnmute : MonoBehaviour
{
    private GameObject GO;

    public bool Mute = false;

    public AudioSource MusicSource;

    void Start()
    {
        GO = GameObject.FindGameObjectWithTag("OnLoadDestroy");

        MusicSource = GO.GetComponent<AudioSource>();
    }

    public void UnmuteOrMute()
    {
        if (Mute == true)
        {
            Mute = false;

        }
        if (Mute == false)
        {
            Mute = true;

        }

    }
}
