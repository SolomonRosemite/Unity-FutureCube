using UnityEngine.Audio;
using UnityEngine.UI;
using UnityEngine;

public class SliderVolume : MonoBehaviour
{
    public static SliderVolume ins;
    public AudioMixer Mixer;
    public Slider SliderValue;

    public Toggle SFXButton;
    public Toggle MusicButton;

    private void Start()
    {
        ins = this;

        if (PcOrPhoneDetect.ins.Platform == 1)
        {
            if (LoadJson.loadJson.MusicOnOff == false)
            {
                Mixer.SetFloat("musicVol", (-10));
            }
            else if (LoadJson.loadJson.MusicOnOff == true)
            {
                Mixer.SetFloat("musicVol", (-80));
                MusicButton.isOn = true;
            }

            if (LoadJson.loadJson.SFXOnOff == false)
            {
                Mixer.SetFloat("sfxVol", (-20));
            }
            else if (LoadJson.loadJson.SFXOnOff == true)
            {
                Mixer.SetFloat("sfxVol", (-80));
                SFXButton.isOn = true;
            }
            SliderValue.value = LoadJson.loadJson.Volume;
        }
        else if (PcOrPhoneDetect.ins.Platform == 2)
        {
            if (LoadJson.loadJson.MusicOnOff == false)
            {
                Mixer.SetFloat("musicVol", (-0));
            }
            else if (LoadJson.loadJson.MusicOnOff == true)
            {
                Mixer.SetFloat("musicVol", (-80));
                MusicButton.isOn = true;
            }

            if (LoadJson.loadJson.SFXOnOff == false)
            {
                Mixer.SetFloat("sfxVol", (-20));
            }
            else if (LoadJson.loadJson.SFXOnOff == true)
            {
                Mixer.SetFloat("sfxVol", (-80));
                SFXButton.isOn = true;
            }
        }
    }

    public void SetLevel(float SliderValue)
    {
        Mixer.SetFloat("MasterVol", (SliderValue));
        LoadJson.loadJson.JsonEditVolume(SliderValue);
    }

    public void MuteUnmuteMusic(bool Mute)
    {
        if (Mute == true)
        {
            Mixer.SetFloat("musicVol", (-80));
            LoadJson.loadJson.JsonEditMusic(Mute);
        }

        if (Mute == false)
        {
            if (PcOrPhoneDetect.ins.Platform == 1)
            {
                Mixer.SetFloat("musicVol", (-10));
            }
            else if (PcOrPhoneDetect.ins.Platform == 2)
            {
                Mixer.SetFloat("musicVol", (-10));
            }
            LoadJson.loadJson.JsonEditMusic(Mute);
        }
    }

    public void MuteUnmuteSFX(bool Mute)
    {
        if (Mute == true)
        {
            Mixer.SetFloat("sfxVol", (-80));
            LoadJson.loadJson.JsonEditSFX(Mute);
        }

        if (Mute == false)
        {
            Mixer.SetFloat("sfxVol", (-20));
            LoadJson.loadJson.JsonEditSFX(Mute);
        }

    }

}