using UnityEngine;

public class MuteUnmute : MonoBehaviour
{
    private GameObject myGameObject;

    public bool Mute = false;

    public AudioSource MusicSource;

    void Start()
    {
        myGameObject = GameObject.FindGameObjectWithTag("OnLoadDestroy");

        MusicSource = gameObject.GetComponent<AudioSource>();
    }

    public void UnmuteOrMute() => Mute = !Mute;
}
