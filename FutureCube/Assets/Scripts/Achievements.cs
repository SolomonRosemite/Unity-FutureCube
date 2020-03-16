using UnityEngine.Audio;
using UnityEngine.UI;
using UnityEngine;

public class Achievements : MonoBehaviour
{
    public byte AchievementIndex;
    public Text VCoins;

    private AudioSource audioSource;

    void Start()
    {
        switch (AchievementIndex)
        {
            case 1:
                VCoins.text = "+ 1000";
                break;
            case 2:
                VCoins.text = "+ 1700";
                break;
            case 3:
                VCoins.text = "+ 500";
                break;
            case 4:
                VCoins.text = "+ 3000";
                break;
        }

        PlaySound();
    }

    void PlaySound()
    {
        audioSource = GameObject.Find("Achievements").GetComponent<AudioSource>();

        if (audioSource.isPlaying == false)
        {
            audioSource.Play();
        }
    }
}
