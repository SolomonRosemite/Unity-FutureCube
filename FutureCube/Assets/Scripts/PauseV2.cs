using UnityEngine.Audio;
using UnityEngine;

public class PauseV2 : MonoBehaviour
{
    public static PauseV2 pauseV2;
    public AudioMixer mainMixer;
    public GameObject GameOverUI;
    public GameObject PauseUI;

    public bool GamePaused = false;
    public string TipTextStr;
    public bool OverGame = false;

    private AudioSource audioSource;
    private int num;

    private void Start()
    {
        pauseV2 = this;
        normalAudio();
        audioSource = GameObject.FindGameObjectWithTag("OnLoadDestroy").GetComponent<AudioSource>();

        Check();

        try { audioSource = GameObject.FindGameObjectWithTag("OnLoadDestroy").GetComponent<AudioSource>(); } catch { }
    }

    void Update()
    {
        if (Input.GetButtonDown("Cancel"))
        {
            if (GamePaused == true)
            {
                Check();
                Resume();
            }
            else
            {
                Pause();
            }
        }
        if (OverGame == true)
        {
            muffledAudio();
            try
            {
                if (audioSource.pitch <= 1)
                {
                    audioSource.pitch += 1 * Time.deltaTime * CollectClock.ins.PitchSpeed;

                    if (audioSource.pitch >= 1)
                    {
                        audioSource.pitch = 1;
                        enabled = false;
                    }
                }
            }
            catch { }
        }
    }

    public void Resume()
    {
        normalAudio();
        GameObject.FindGameObjectWithTag("OnLoadDestroy").GetComponent<AudioSource>().bypassEffects = true;
        Time.timeScale = 1;
        PauseUI.SetActive(false);
        GamePaused = false;
        Cursor.visible = false;
    }

    public void Pause()
    {
        muffledAudio();
        GameObject.FindGameObjectWithTag("OnLoadDestroy").GetComponent<AudioSource>().bypassEffects = false;
        Time.timeScale = 0;
        PauseUI.SetActive(true);
        GamePaused = true;
        Cursor.visible = true;
    }

    public void Check()
    {
        num = Random.Range(1, 6);

        if (num == 1)
        {
            TipTextStr = "Tip: Sometimes picking up a coin is not a good idea";
        }
        if (num == 2)
        {
            TipTextStr = "Tip: If you Suck at a Level maybe just take a break";
        }
        if (num == 3)
        {
            TipTextStr = "Tip: In Future you can get Coins to Skips Levels. Maybe...";
        }
        if (num == 4)
        {
            TipTextStr = "Tip: You get Extra Points for collecting Coins";
        }
        if (num == 5)
        {
            TipTextStr = "Tip: Finishing with a bubble gets you Extra Points";
        }

    }

    public void Reload()
    {
        GameObject.Find("LevelChanger").GetComponent<LevelChanger>().MainFadeStarter("Reload");
        GameOverUI.SetActive(false);
        Time.timeScale = 1;
    }

    public void GameOver()
    {
        if (PcOrPhoneDetect.ins.Platform == 1)
        {
            PlayerMovement.playerMovement.GameOver = true;
        }
        else if (PcOrPhoneDetect.ins.Platform == 2)
        {
            PlayerMovePhone.playerMovement.GameOver = true;
        }

        OverGame = true;
        Cursor.visible = true;
        GameOverUI.SetActive(true);
        Time.timeScale = .4f;
    }

    void normalAudio()
    {
        mainMixer.SetFloat("gain", 1.00f);
        mainMixer.SetFloat("Octave range", 5.00f);
        mainMixer.SetFloat("Center freq", 22000.0f);
    }

    void muffledAudio()
    {
        // mainMixer.SetFloat("gain", 0.05f);
        // mainMixer.SetFloat("Octave range", 4.47f);
        // mainMixer.SetFloat("Center freq", 8000.00f);

        mainMixer.SetFloat("gain", 0.31f);
        mainMixer.SetFloat("Octave range", 5.00f);
        mainMixer.SetFloat("Center freq", 3746.00f);
    }

}
