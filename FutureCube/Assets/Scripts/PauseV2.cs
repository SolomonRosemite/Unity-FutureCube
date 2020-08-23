using UnityEngine.Audio;
using UnityEngine;

public class PauseV2 : MonoBehaviour
{
    public static PauseV2 pauseV2;
    public AudioMixer mainMixer;
    public GameObject gameOverUI;
    public GameObject pauseUI;

    public bool gamePaused = false;
    public string tipTextStr;
    public bool gameOver = false;

    private AudioSource audioSource;
    private int tipIndex;

    private void Start()
    {
        pauseV2 = this;
        normalAudio();

        updateTip();

        try { audioSource = GameObject.FindGameObjectWithTag("OnLoadDestroy").GetComponent<AudioSource>(); } catch { }

        // If in Debug mode
        if (Application.platform != RuntimePlatform.WindowsEditor)
        {
            audioSource = GameObject.FindGameObjectWithTag("OnLoadDestroy").GetComponent<AudioSource>();
            return;
        }

        audioSource = gameObject.AddComponent(typeof(AudioSource)) as AudioSource;
    }

    void Update()
    {
        if (Input.GetButtonDown("Cancel"))
        {
            if (gamePaused == true)
            {
                updateTip();
                Resume();
            }
            else
            {
                Pause();
            }
        }
        if (gameOver == true)
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
        pauseUI.SetActive(false);
        gamePaused = false;
        Cursor.visible = false;
    }

    public void Pause()
    {
        muffledAudio();
        GameObject.FindGameObjectWithTag("OnLoadDestroy").GetComponent<AudioSource>().bypassEffects = false;
        Time.timeScale = 0;
        pauseUI.SetActive(true);
        gamePaused = true;
        Cursor.visible = true;
    }

    public void updateTip()
    {
        tipIndex = Random.Range(1, 6);

        if (tipIndex == 1)
        {
            tipTextStr = "Tip: Sometimes picking up a coin is not a good idea";
        }
        if (tipIndex == 2)
        {
            tipTextStr = "Tip: If you Suck at a Level maybe just take a break";
        }
        if (tipIndex == 3)
        {
            tipTextStr = "Tip: In Future you can get Coins to Skips Levels. Maybe...";
        }
        if (tipIndex == 4)
        {
            tipTextStr = "Tip: You get Extra Points for collecting Coins";
        }
        if (tipIndex == 5)
        {
            tipTextStr = "Tip: Finishing with a bubble gets you Extra Points";
        }

    }

    public void Reload()
    {
        GameObject.Find("LevelChanger").GetComponent<LevelChanger>().MainFadeStarter("Reload");
        gameOverUI.SetActive(false);
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

        gameOver = true;
        Cursor.visible = true;
        gameOverUI.SetActive(true);
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
