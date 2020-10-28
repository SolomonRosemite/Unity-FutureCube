using UnityEngine.Audio;
using UnityEngine.UI;
using UnityEngine;

public class Test : MonoBehaviour
{
    public AudioMixer mainMixer;
    bool bypassed = false;

    void Start()
    {
        Change(bypassed);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            Change(bypassed);
        }
    }

    void Change(bool byPass)
    {
        if (byPass == true)
        {

            mainMixer.SetFloat("gain", 1.00f);
            mainMixer.SetFloat("Octave range", 5.00f);
            mainMixer.SetFloat("Center freq", 22000.0f);
            bypassed = false;
            return;
        }
        mainMixer.SetFloat("gain", 0.31f);
        mainMixer.SetFloat("Octave range", 5.00f);
        mainMixer.SetFloat("Center freq", 3746.00f);

        bypassed = true;
    }

}
