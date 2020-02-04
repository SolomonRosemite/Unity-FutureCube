using UnityEngine;
using System.Collections;

public class SelectRandomV2 : MonoBehaviour
{
    public static SelectRandomV2 ins;

    public int Mode = 1;

    public float UpdateEveryXSeconds = 1;

    [Space]

    public GameObject[] GameObjects;
    public GameObject UpdateGameObject;

    public AudioClip[] Clips;

    private AudioSource audioSource;

    private float nextActionTime = 0.0f;
    private int times;

    private int index;
    private int lastIndex;

    private void Start()
    {
        ins = this;

        if (Mode is 1)
        {
            GameObjects[0].SetActive(false);
            index = Random.Range(0, GameObjects.Length);

            GameObjects[index].SetActive(true);
        }
        else if (Mode is 2)
        {
            audioSource = gameObject.GetComponent<AudioSource>();

            index = Random.Range(1, Clips.Length);

            lastIndex = index;

            audioSource.clip = Clips[index];

            audioSource.Play();
        }

        if (LoadJson.loadJson.UpdateAvailable == true)
        {
            try { UpdateGameObject.SetActive(true); } catch { }
        }
    }

    void Update()
    {
        if (audioSource != null)
        {
            if (Time.time > nextActionTime)
            {
                nextActionTime += UpdateEveryXSeconds;

                // Runs every X Seconds
                if (audioSource.isPlaying != true)
                {
                    SetIndex();
                }
            }
        }
    }

    void SetIndex()
    {
        index = Random.Range(1, Clips.Length);


        if (index != lastIndex)
        {
            lastIndex = index;

            audioSource.clip = Clips[index];

            audioSource.Play();
        }
        else
        {
            SetIndex();
        }
    }

    public void TurnAllOff()
    {
        try { GameObjects[0].SetActive(false); } catch { }
        try { GameObjects[1].SetActive(false); } catch { }
        try { GameObjects[2].SetActive(false); } catch { }
        try { GameObjects[3].SetActive(false); } catch { }
    }

    public void UpdateGO()
    {
        UpdateGameObject.SetActive(true);
    }
}