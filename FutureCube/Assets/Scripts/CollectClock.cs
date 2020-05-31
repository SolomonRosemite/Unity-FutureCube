using System.Collections;
using UnityEngine;

public class CollectClock : MonoBehaviour
{
    public static CollectClock ins;
    public SliderForClock sliderForClock;

    private Camera Cam;

    public GameObject Clock;
    public MeshRenderer ClockMesh;
    public GameObject sliderGameObject;

    [Space]

    public float timeScale = .7f;
    public float Duration = 1;

    [Space]

    public int CamPOVChangeSpeed = 10;
    public int EndPOV;

    [Space]

    public bool CloseClockAfterUse = true;

    [Space]
    public float PitchSpeed = 1;
    public float PitchValue = .5f;

    [HideInInspector]
    public bool start = false;
    private AudioSource audioSource;
    private bool StartPitchUp;
    private bool StartPitch;
    private bool Reverse = false;
    private float StartPOV;

    private void Start()
    {
        try { sliderGameObject.SetActive(false); } catch { }

        ins = this;

        Cam = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
        audioSource = GameObject.FindGameObjectWithTag("OnLoadDestroy").GetComponent<AudioSource>();

        StartPOV = Cam.fieldOfView;
    }

    private void Update()
    {
        if (start == true)
        {
            Cam.fieldOfView -= CamPOVChangeSpeed * Time.deltaTime * Time.timeScale;
            if (Cam.fieldOfView <= EndPOV)
            {
                StartPitch = true;
                start = false;
            }
        }
        else if (Reverse == true)
        {
            Cam.fieldOfView += CamPOVChangeSpeed * Time.deltaTime * Time.timeScale;
            if (Cam.fieldOfView >= StartPOV)
            {
                Reverse = false;
                StartPitch = false;
                StartPitchUp = true;
            }
        }

        if (StartPitch == true)
        {
            if (audioSource.pitch >= PitchValue)
            {
                // Pitch Down
                audioSource.pitch -= 1 * Time.deltaTime * PitchSpeed;
            }
        }
        else if (StartPitchUp == true)
        {
            try
            {
                if (audioSource.pitch <= 1)
                {
                    audioSource.pitch += 1 * Time.deltaTime * CollectClock.ins.PitchSpeed;

                    if (audioSource.pitch >= 1)
                    {
                        audioSource.pitch = 1;

                        if (CloseClockAfterUse)
                        {
                            Clock.SetActive(false);
                        }
                    }
                }

            }
            catch (MissingComponentException e)
            {
                Debug.LogError("Audio Pitch: " + e);
            }

        }
    }

    public IEnumerator ClockCollected()
    {
        // For the Audio Pitch
        start = true;

        // Progress bar
        sliderGameObject.SetActive(true);
        sliderForClock.SetDuration(Duration);

        // Hide Mesh 
        ClockMesh.enabled = false;

        yield return new WaitForSeconds(.2f);
        StartCoroutine(this.ClockV2());
    }

    public IEnumerator ClockV2()
    {
        sliderForClock.Starter();

        Time.timeScale = timeScale;

        if (PcOrPhoneDetect.ins.Platform == 1)
        {
            PlayerMovement.playerMovement.sidewaysForce *= 1.5f;
        }
        else
        {
            PlayerMovePhone.playerMovement.sidewaysForce *= 1.5f;
        }

        yield return new WaitForSeconds(Duration);

        if (PcOrPhoneDetect.ins.Platform == 1)
        {
            PlayerMovement.playerMovement.sidewaysForce /= 1.5f;
        }
        else
        {
            PlayerMovePhone.playerMovement.sidewaysForce /= 1.5f;
        }

        Reverse = true;

        Time.timeScale = 1;
    }

    public void SetSilder(float Duration)
    {

        // Progress bar
        sliderGameObject.SetActive(true);
        sliderForClock.SetDuration(Duration);
        sliderForClock.Starter();
    }
}
