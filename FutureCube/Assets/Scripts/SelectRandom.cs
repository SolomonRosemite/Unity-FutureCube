using UnityEngine;

public class SelectRandom : MonoBehaviour
{
    public static SelectRandom ins;

    public bool UseAudio = true;
    public bool UseAudioWithVideo = true;
    public int Quantity;
    public GameObject[] Videos;
    public AudioClip[] shoot;

    private AudioSource audioSource;

    private AudioClip shootClip;

    private int indexV2;

    private void Awake()
    {
        ins = this;

        if (UseAudio)
        {
            audioSource = gameObject.GetComponent<AudioSource>();

            int index = Random.Range(0, shoot.Length);
            shootClip = shoot[index];

            indexV2 = index;

            audioSource.clip = shootClip;
        }
        else if (UseAudioWithVideo)
        {
            audioSource = gameObject.GetComponent<AudioSource>();

            int index = Random.Range(0, shoot.Length);
            shootClip = shoot[index];

            indexV2 = index;

            audioSource.clip = shootClip;

            try { Videos[0].SetActive(false); } catch { }

            Videos[indexV2].SetActive(true);

        }
        else
        {
            try { Videos[0].SetActive(false); } catch { }
            indexV2 = Random.Range(0, Quantity);
        }
    }

    void Start()
    {
        if (UseAudio)
        {
            Videos[indexV2].SetActive(true);
        }
        else if (UseAudioWithVideo)
        {
        }
        else
        {
            Videos[indexV2].SetActive(true);
        }
    }

    public void PlayMusic()
    {
        audioSource.Play();
    }

}