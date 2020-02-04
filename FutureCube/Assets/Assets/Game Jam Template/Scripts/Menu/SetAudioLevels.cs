using UnityEngine;
using System.Collections;
using UnityEngine.Audio;

public class SetAudioLevels : MonoBehaviour
{
    public static SetAudioLevels ins;
    public AudioMixer mainMixer;

    private void Start()
    {
        ins = this;
    }

    public void SetLevelForDesktop()
    {
        mainMixer.SetFloat("MasterVol", LoadJson.loadJson.Volume);

        if (LoadJson.loadJson.MusicOnOff == false)
        {
            mainMixer.SetFloat("musicVol", (-10));
        }
        else if (LoadJson.loadJson.MusicOnOff == true)
        {
            mainMixer.SetFloat("musicVol", (-80));
        }

        if (LoadJson.loadJson.SFXOnOff == false)
        {
            mainMixer.SetFloat("sfxVol", (-20));
        }
        else if (LoadJson.loadJson.SFXOnOff == true)
        {
            mainMixer.SetFloat("sfxVol", (-80));
        }

        SelectRandom.ins.PlayMusic();
    }

    public void SetLevelForPhone()
    {
        mainMixer.SetFloat("MasterVol", 0);

        if (LoadJson.loadJson.MusicOnOff == false)
        {
            mainMixer.SetFloat("musicVol", (-0));
        }
        else if (LoadJson.loadJson.MusicOnOff == true)
        {

            mainMixer.SetFloat("musicVol", (-80));
        }

        if (LoadJson.loadJson.SFXOnOff == false)
        {
            mainMixer.SetFloat("sfxVol", (-20));
        }
        else if (LoadJson.loadJson.SFXOnOff == true)
        {
            mainMixer.SetFloat("sfxVol", (-80));
        }

        SelectRandom.ins.PlayMusic();
    }

}

/*
    //Call this function and pass in the float parameter musicLvl to set the volume of the AudioMixerGroup Music in mainMixer
    public void SetMusicLevel(float musicLvl)
    {
        mainMixer.SetFloat("musicVol", musicLvl);
    }

    //Call this function and pass in the float parameter sfxLevel to set the volume of the AudioMixerGroup SoundFx in mainMixer
    public void SetSfxLevel(float sfxLevel)
    {
        mainMixer.SetFloat("sfxVol", sfxLevel);
    }
*/
