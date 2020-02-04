using UnityEngine.SceneManagement;
using System.Collections;
using UnityEngine.UI;
using UnityEngine;
using System.IO;
using System;

public class LoadJson : MonoBehaviour
{
    public static LoadJson loadJson;
    public Color imagecolor = new Color(0.2F, 0.3F, 0.4F, 0.5F);
    public Color imagecolorDisabled = new Color(0.2F, 0.3F, 0.4F, 0.5F);
    public Color imagecolorFinal = new Color(0.2F, 0.3F, 0.4F, 0.5F);
    public Color imagecolorFinalDisabled = new Color(0.2F, 0.3F, 0.4F, 0.5F);

    // Json Data
    [HideInInspector] public int LevelComplete;

    [HideInInspector] public float Volume;

    [HideInInspector] public bool SFXOnOff;

    [HideInInspector] public bool MusicOnOff;

    [HideInInspector] public float SetQuality;

    [HideInInspector] public string PlayerName;

    [HideInInspector] public byte[] CurrentSkin = new byte[SkinCount];

    private static byte SkinCount = 3;

    [Space]

    public int V_Coins;

    [HideInInspector] public Color PlayerColor;

    [HideInInspector] public byte SkinCountLJF = SkinCount;

    [HideInInspector] public const float Version = 1.85f;
    [HideInInspector] public bool UpdateAvailable;

    void Start()
    {
        loadJson = this;
        StartCoroutine(CheckPlatform());
    }

    void Update()
    {

        // Create a temporary reference to the current scene.
        Scene currentScene = SceneManager.GetActiveScene();

        if ("Adventure Mode Select Lvl" == currentScene.name)
        {

            if (LevelComplete > 6)
            {
                GameObject.Find("Level 2").GetComponent<Button>().enabled = true;
                GameObject.Find("Level 2").GetComponent<Image>().color = imagecolor;
                GameObject.Find("Level 3").GetComponent<Button>().enabled = true;
                GameObject.Find("Level 3").GetComponent<Image>().color = imagecolor;
                GameObject.Find("Level 4").GetComponent<Button>().enabled = true;
                GameObject.Find("Level 4").GetComponent<Image>().color = imagecolor;
                GameObject.Find("Level 5").GetComponent<Button>().enabled = true;
                GameObject.Find("Level 5").GetComponent<Image>().color = imagecolor;
                GameObject.Find("Final").GetComponent<Button>().enabled = true;
                GameObject.Find("Final").GetComponent<Image>().color = imagecolorFinal;

                try { GameObject.Find("TextLevel note").SetActive(false); } catch { }
            }

            switch (LevelComplete)
            {
                case 1:
                    GameObject.Find("Level 2").GetComponent<Button>().enabled = true;
                    GameObject.Find("Level 2").GetComponent<Image>().color = imagecolor;
                    break;

                case 2:
                    GameObject.Find("Level 2").GetComponent<Button>().enabled = true;
                    GameObject.Find("Level 2").GetComponent<Image>().color = imagecolor;
                    GameObject.Find("Level 3").GetComponent<Button>().enabled = true;
                    GameObject.Find("Level 3").GetComponent<Image>().color = imagecolor;
                    break;

                case 3:
                    GameObject.Find("Level 2").GetComponent<Button>().enabled = true;
                    GameObject.Find("Level 2").GetComponent<Image>().color = imagecolor;
                    GameObject.Find("Level 3").GetComponent<Button>().enabled = true;
                    GameObject.Find("Level 3").GetComponent<Image>().color = imagecolor;
                    GameObject.Find("Level 4").GetComponent<Button>().enabled = true;
                    GameObject.Find("Level 4").GetComponent<Image>().color = imagecolor;
                    break;

                case 4:
                    GameObject.Find("Level 2").GetComponent<Button>().enabled = true;
                    GameObject.Find("Level 2").GetComponent<Image>().color = imagecolor;
                    GameObject.Find("Level 3").GetComponent<Button>().enabled = true;
                    GameObject.Find("Level 3").GetComponent<Image>().color = imagecolor;
                    GameObject.Find("Level 4").GetComponent<Button>().enabled = true;
                    GameObject.Find("Level 4").GetComponent<Image>().color = imagecolor;
                    GameObject.Find("Level 5").GetComponent<Button>().enabled = true;
                    GameObject.Find("Level 5").GetComponent<Image>().color = imagecolor;
                    break;

                case 5:
                    GameObject.Find("Level 2").GetComponent<Button>().enabled = true;
                    GameObject.Find("Level 2").GetComponent<Image>().color = imagecolor;
                    GameObject.Find("Level 3").GetComponent<Button>().enabled = true;
                    GameObject.Find("Level 3").GetComponent<Image>().color = imagecolor;
                    GameObject.Find("Level 4").GetComponent<Button>().enabled = true;
                    GameObject.Find("Level 4").GetComponent<Image>().color = imagecolor;
                    GameObject.Find("Level 5").GetComponent<Button>().enabled = true;
                    GameObject.Find("Level 5").GetComponent<Image>().color = imagecolor;
                    GameObject.Find("Final").GetComponent<Button>().enabled = true;
                    GameObject.Find("Final").GetComponent<Image>().color = imagecolorFinal;
                    break;

                case 6:
                    GameObject.Find("Level 2").GetComponent<Button>().enabled = true;
                    GameObject.Find("Level 2").GetComponent<Image>().color = imagecolor;
                    GameObject.Find("Level 3").GetComponent<Button>().enabled = true;
                    GameObject.Find("Level 3").GetComponent<Image>().color = imagecolor;
                    GameObject.Find("Level 4").GetComponent<Button>().enabled = true;
                    GameObject.Find("Level 4").GetComponent<Image>().color = imagecolor;
                    GameObject.Find("Level 5").GetComponent<Button>().enabled = true;
                    GameObject.Find("Level 5").GetComponent<Image>().color = imagecolor;
                    GameObject.Find("Final").GetComponent<Button>().enabled = true;
                    GameObject.Find("Final").GetComponent<Image>().color = imagecolorFinal;
                    JsonEditCompletedLevel(10);
                    break;

                default:
                    break;

            }
        }
        else if ("Adventure Mode LVL Season 2" == currentScene.name)
        {
            if (LevelComplete >= 6)
            {
                GameObject.Find("Level 11").GetComponent<Button>().enabled = true;
                GameObject.Find("Level 11").GetComponent<Image>().color = imagecolor;
            }
            else
            {
                GameObject.Find("Level 11").GetComponent<Button>().enabled = false;
            }

            switch (LevelComplete)
            {
                case 11:
                    GameObject.Find("Level 12").GetComponent<Button>().enabled = true;
                    GameObject.Find("Level 12").GetComponent<Image>().color = imagecolor;
                    break;

                case 12:
                    GameObject.Find("Level 12").GetComponent<Button>().enabled = true;
                    GameObject.Find("Level 12").GetComponent<Image>().color = imagecolor;
                    GameObject.Find("Level 13").GetComponent<Button>().enabled = true;
                    GameObject.Find("Level 13").GetComponent<Image>().color = imagecolor;
                    break;

                case 13:
                    GameObject.Find("Level 12").GetComponent<Button>().enabled = true;
                    GameObject.Find("Level 12").GetComponent<Image>().color = imagecolor;
                    GameObject.Find("Level 13").GetComponent<Button>().enabled = true;
                    GameObject.Find("Level 13").GetComponent<Image>().color = imagecolor;
                    GameObject.Find("Level 14").GetComponent<Button>().enabled = true;
                    GameObject.Find("Level 14").GetComponent<Image>().color = imagecolor;
                    break;

                case 14:
                    GameObject.Find("Level 12").GetComponent<Button>().enabled = true;
                    GameObject.Find("Level 12").GetComponent<Image>().color = imagecolor;
                    GameObject.Find("Level 13").GetComponent<Button>().enabled = true;
                    GameObject.Find("Level 13").GetComponent<Image>().color = imagecolor;
                    GameObject.Find("Level 14").GetComponent<Button>().enabled = true;
                    GameObject.Find("Level 14").GetComponent<Image>().color = imagecolor;
                    GameObject.Find("Level 15").GetComponent<Button>().enabled = true;
                    GameObject.Find("Level 15").GetComponent<Image>().color = imagecolor;
                    break;

                case 15:
                    GameObject.Find("Level 12").GetComponent<Button>().enabled = true;
                    GameObject.Find("Level 12").GetComponent<Image>().color = imagecolor;
                    GameObject.Find("Level 13").GetComponent<Button>().enabled = true;
                    GameObject.Find("Level 13").GetComponent<Image>().color = imagecolor;
                    GameObject.Find("Level 14").GetComponent<Button>().enabled = true;
                    GameObject.Find("Level 14").GetComponent<Image>().color = imagecolor;
                    GameObject.Find("Level 15").GetComponent<Button>().enabled = true;
                    GameObject.Find("Level 15").GetComponent<Image>().color = imagecolor;
                    GameObject.Find("Final 11").GetComponent<Button>().enabled = true;
                    GameObject.Find("Final 11").GetComponent<Image>().color = imagecolorFinal;
                    break;

                case 16:
                    GameObject.Find("Level 12").GetComponent<Button>().enabled = true;
                    GameObject.Find("Level 12").GetComponent<Image>().color = imagecolor;
                    GameObject.Find("Level 13").GetComponent<Button>().enabled = true;
                    GameObject.Find("Level 13").GetComponent<Image>().color = imagecolor;
                    GameObject.Find("Level 14").GetComponent<Button>().enabled = true;
                    GameObject.Find("Level 14").GetComponent<Image>().color = imagecolor;
                    GameObject.Find("Level 15").GetComponent<Button>().enabled = true;
                    GameObject.Find("Level 15").GetComponent<Image>().color = imagecolor;
                    GameObject.Find("Final 11").GetComponent<Button>().enabled = true;
                    GameObject.Find("Final 11").GetComponent<Image>().color = imagecolorFinal;
                    break;
            }
        }
    }

    // Json Create, Load, Check
    public void CreateJson()
    {
        LoadJsonFile LJF = new LoadJsonFile();

        if (PcOrPhoneDetect.ins.Platform == 1)
        {
            LJF.Volume = -20;
        }
        else if (PcOrPhoneDetect.ins.Platform == 2)
        {
            LJF.Volume = 0;
        }

        PlayerColor.r = 1;
        PlayerColor.g = 0.1098039f;
        PlayerColor.b = 0.1098039f;
        PlayerColor.a = 1;

        LJF.LevelComplete = 0;
        LJF.SFXOnOff = false;
        LJF.MusicOnOff = false;
        LJF.PlayerName = "Player";
        LJF.SetQuality = 3f;
        LJF.V_Coins = 0;
        LJF.CurrentSkin[0] = 2;
        LJF.PlayerColor = PlayerColor;

        // All after Vars here
        LevelComplete = LJF.LevelComplete;
        Volume = LJF.Volume;
        SFXOnOff = LJF.SFXOnOff;
        MusicOnOff = LJF.MusicOnOff;
        PlayerName = LJF.PlayerName;
        SetQuality = LJF.SetQuality;
        V_Coins = LJF.V_Coins;
        PlayerColor = LJF.PlayerColor;
        CurrentSkin = LJF.CurrentSkin;

        string JsonWrite = JsonUtility.ToJson(LJF, true);
        if (PcOrPhoneDetect.ins.Platform == 1) { File.WriteAllText(Application.dataPath + "/PlayerChocolateSave.json", JsonWrite); }
        else { File.WriteAllText(Application.persistentDataPath + "/PlayerChocolateSave.json", JsonWrite); }

        JsonLoader();
    }

    public void JsonLoader()
    {
        string JsonRead;

        if (PcOrPhoneDetect.ins.Platform == 1) { JsonRead = File.ReadAllText(Application.dataPath + "/PlayerChocolateSave.json"); }
        else { JsonRead = File.ReadAllText(Application.persistentDataPath + "/PlayerChocolateSave.json"); }

        LoadJsonFile loadedPlayer = JsonUtility.FromJson<LoadJsonFile>(JsonRead);

        // All after Vars here
        LevelComplete = loadedPlayer.LevelComplete;
        Volume = loadedPlayer.Volume;
        MusicOnOff = loadedPlayer.MusicOnOff;
        SFXOnOff = loadedPlayer.SFXOnOff;
        PlayerName = loadedPlayer.PlayerName;
        V_Coins = loadedPlayer.V_Coins;
        PlayerColor = loadedPlayer.PlayerColor;
        CurrentSkin = loadedPlayer.CurrentSkin;

        // Set the Quality
        SetQuality = loadedPlayer.SetQuality;
        QualitySettings.SetQualityLevel((int)Math.Ceiling(SetQuality));
    }

    public IEnumerator CheckPlatform()
    {
        yield return new WaitForSeconds(.5f);
        if (PcOrPhoneDetect.ins.Platform == 1)
        {
            // If the Json PlayerData exsist then Load json file
            if (File.Exists(Application.dataPath + "/PlayerChocolateSave.json")) { JsonLoader(); }
            // If not Create one
            else { CreateJson(); }
        }
        if (PcOrPhoneDetect.ins.Platform == 2)
        {
            // If the Json PlayerData exsist then Load json file
            if (File.Exists(Application.persistentDataPath + "/PlayerChocolateSave.json")) { JsonLoader(); SetAudioLevels.ins.SetLevelForPhone(); }
            // If not Create one
            else { CreateJson(); }
        }
        else
        {
            print("Json " + "Platform: " + PcOrPhoneDetect.ins.Platform);
            SetAudioLevels.ins.SetLevelForDesktop();
        }
    }


    //Edits
    public void JsonEditCompletedLevel(int CompletedLevelnumber)
    {
        LoadJsonFile LJF = new LoadJsonFile();
        LJF.LevelComplete = CompletedLevelnumber;
        this.LevelComplete = CompletedLevelnumber;
        LJF.SFXOnOff = SFXOnOff;
        LJF.Volume = Volume;
        LJF.PlayerName = PlayerName;
        LJF.MusicOnOff = MusicOnOff;
        LJF.SetQuality = SetQuality;
        LJF.PlayerColor = PlayerColor;
        LJF.V_Coins = V_Coins;
        LJF.CurrentSkin = CurrentSkin;

        string JsonWrite = JsonUtility.ToJson(LJF, true);
        if (PcOrPhoneDetect.ins.Platform == 1) { File.WriteAllText(Application.dataPath + "/PlayerChocolateSave.json", JsonWrite); }
        else { File.WriteAllText(Application.persistentDataPath + "/PlayerChocolateSave.json", JsonWrite); }

    }

    public void JsonEditVolume(float Volume)
    {
        LoadJsonFile LJF = new LoadJsonFile();
        LJF.Volume = Volume;
        this.Volume = Volume;
        LJF.SFXOnOff = SFXOnOff;
        LJF.LevelComplete = LevelComplete;
        LJF.PlayerName = PlayerName;
        LJF.MusicOnOff = MusicOnOff;
        LJF.SetQuality = SetQuality;
        LJF.V_Coins = V_Coins;
        LJF.PlayerColor = PlayerColor;
        LJF.CurrentSkin = CurrentSkin;

        string JsonWrite = JsonUtility.ToJson(LJF, true);
        if (PcOrPhoneDetect.ins.Platform == 1) { File.WriteAllText(Application.dataPath + "/PlayerChocolateSave.json", JsonWrite); }
        else { File.WriteAllText(Application.persistentDataPath + "/PlayerChocolateSave.json", JsonWrite); }
    }

    public void JsonEditSFX(bool SFXOnOff)
    {
        LoadJsonFile LJF = new LoadJsonFile();
        LJF.SFXOnOff = SFXOnOff;
        this.SFXOnOff = SFXOnOff;
        LJF.Volume = Volume;
        LJF.LevelComplete = LevelComplete;
        LJF.PlayerName = PlayerName;
        LJF.MusicOnOff = MusicOnOff;
        LJF.SetQuality = SetQuality;
        LJF.PlayerColor = PlayerColor;
        LJF.CurrentSkin = CurrentSkin;
        LJF.V_Coins = V_Coins;

        string JsonWrite = JsonUtility.ToJson(LJF, true);
        if (PcOrPhoneDetect.ins.Platform == 1) { File.WriteAllText(Application.dataPath + "/PlayerChocolateSave.json", JsonWrite); }
        else { File.WriteAllText(Application.persistentDataPath + "/PlayerChocolateSave.json", JsonWrite); }
    }

    public void JsonEditPlayerName(string PlayerName)
    {
        LoadJsonFile LJF = new LoadJsonFile();
        LJF.SFXOnOff = SFXOnOff;
        LJF.Volume = Volume;
        LJF.LevelComplete = LevelComplete;
        LJF.PlayerName = PlayerName;
        this.PlayerName = PlayerName;
        LJF.MusicOnOff = MusicOnOff;
        LJF.SetQuality = SetQuality;
        LJF.PlayerColor = PlayerColor;
        LJF.CurrentSkin = CurrentSkin;
        LJF.V_Coins = V_Coins;

        LevelJson.levelJson.Setname();

        string JsonWrite = JsonUtility.ToJson(LJF, true);
        if (PcOrPhoneDetect.ins.Platform == 1) { File.WriteAllText(Application.dataPath + "/PlayerChocolateSave.json", JsonWrite); }
        else { File.WriteAllText(Application.persistentDataPath + "/PlayerChocolateSave.json", JsonWrite); }
    }

    public void JsonEditMusic(bool MusicOnOff)
    {
        LoadJsonFile LJF = new LoadJsonFile();
        LJF.SFXOnOff = SFXOnOff;
        LJF.Volume = Volume;
        LJF.LevelComplete = LevelComplete;
        LJF.PlayerName = PlayerName;
        LJF.MusicOnOff = MusicOnOff;
        this.MusicOnOff = MusicOnOff;
        LJF.SetQuality = SetQuality;
        LJF.PlayerColor = PlayerColor;
        LJF.CurrentSkin = CurrentSkin;
        LJF.V_Coins = V_Coins;

        string JsonWrite = JsonUtility.ToJson(LJF, true);
        if (PcOrPhoneDetect.ins.Platform == 1) { File.WriteAllText(Application.dataPath + "/PlayerChocolateSave.json", JsonWrite); }
        else { File.WriteAllText(Application.persistentDataPath + "/PlayerChocolateSave.json", JsonWrite); }
    }

    public void JsonEditQuality(float Quality)
    {
        LoadJsonFile LJF = new LoadJsonFile();
        LJF.SFXOnOff = SFXOnOff;
        LJF.Volume = Volume;
        LJF.LevelComplete = LevelComplete;
        LJF.PlayerName = PlayerName;
        LJF.MusicOnOff = MusicOnOff;
        this.SetQuality = Quality;
        LJF.SetQuality = Quality;
        LJF.PlayerColor = PlayerColor;
        LJF.CurrentSkin = CurrentSkin;
        LJF.V_Coins = V_Coins;

        string JsonWrite = JsonUtility.ToJson(LJF, true);
        if (PcOrPhoneDetect.ins.Platform == 1) { File.WriteAllText(Application.dataPath + "/PlayerChocolateSave.json", JsonWrite); }
        else { File.WriteAllText(Application.persistentDataPath + "/PlayerChocolateSave.json", JsonWrite); }
    }

    public void JsonEditV_Coins(int V_CoinsInput)
    {
        LoadJsonFile LJF = new LoadJsonFile();
        LJF.SFXOnOff = SFXOnOff;
        LJF.Volume = Volume;
        LJF.LevelComplete = LevelComplete;
        LJF.PlayerName = PlayerName;
        LJF.MusicOnOff = MusicOnOff;
        LJF.SetQuality = SetQuality;
        V_Coins += V_CoinsInput;
        LJF.V_Coins += V_Coins;
        LJF.PlayerColor = PlayerColor;
        LJF.CurrentSkin = CurrentSkin;

        string JsonWrite = JsonUtility.ToJson(LJF, true);
        if (PcOrPhoneDetect.ins.Platform == 1) { File.WriteAllText(Application.dataPath + "/PlayerChocolateSave.json", JsonWrite); }
        else { File.WriteAllText(Application.persistentDataPath + "/PlayerChocolateSave.json", JsonWrite); }
    }

    public void JsonEditV_CoinsFixed(int V_CoinsInput)
    {
        LoadJsonFile LJF = new LoadJsonFile();
        LJF.SFXOnOff = SFXOnOff;
        LJF.Volume = Volume;
        LJF.LevelComplete = LevelComplete;
        LJF.PlayerName = PlayerName;
        LJF.MusicOnOff = MusicOnOff;
        LJF.SetQuality = SetQuality;
        V_Coins = V_CoinsInput;
        LJF.V_Coins = V_Coins;
        LJF.PlayerColor = PlayerColor;
        LJF.CurrentSkin = CurrentSkin;

        string JsonWrite = JsonUtility.ToJson(LJF, true);
        if (PcOrPhoneDetect.ins.Platform == 1) { File.WriteAllText(Application.dataPath + "/PlayerChocolateSave.json", JsonWrite); }
        else { File.WriteAllText(Application.persistentDataPath + "/PlayerChocolateSave.json", JsonWrite); }
    }

    public void JsonEditPlayerColor(Color color)
    {
        LoadJsonFile LJF = new LoadJsonFile();
        LJF.SFXOnOff = SFXOnOff;
        LJF.Volume = Volume;
        LJF.LevelComplete = LevelComplete;
        LJF.PlayerName = PlayerName;
        LJF.MusicOnOff = MusicOnOff;
        LJF.SetQuality = SetQuality;
        LJF.V_Coins = V_Coins;
        LJF.PlayerColor = color;
        this.PlayerColor = color;
        LJF.CurrentSkin = CurrentSkin;

        string JsonWrite = JsonUtility.ToJson(LJF, true);
        if (PcOrPhoneDetect.ins.Platform == 1) { File.WriteAllText(Application.dataPath + "/PlayerChocolateSave.json", JsonWrite); }
        else { File.WriteAllText(Application.persistentDataPath + "/PlayerChocolateSave.json", JsonWrite); }
    }

    public void JsonEditSkin(byte SkinStatus, byte Index)
    {
        LoadJsonFile LJF = new LoadJsonFile();
        LJF.SFXOnOff = SFXOnOff;
        LJF.Volume = Volume;
        LJF.LevelComplete = LevelComplete;
        LJF.PlayerName = PlayerName;
        LJF.MusicOnOff = MusicOnOff;
        LJF.SetQuality = SetQuality;
        LJF.V_Coins = V_Coins;
        LJF.PlayerColor = PlayerColor;

        CurrentSkin[Index] = SkinStatus;
        LJF.CurrentSkin = CurrentSkin;

        string JsonWrite = JsonUtility.ToJson(LJF, true);
        if (PcOrPhoneDetect.ins.Platform == 1) { File.WriteAllText(Application.dataPath + "/PlayerChocolateSave.json", JsonWrite); }
        else { File.WriteAllText(Application.persistentDataPath + "/PlayerChocolateSave.json", JsonWrite); }
    }

    public void JsonEditSkinFix(byte Index)
    {
        LoadJsonFile LJF = new LoadJsonFile();
        LJF.SFXOnOff = SFXOnOff;
        LJF.Volume = Volume;
        LJF.LevelComplete = LevelComplete;
        LJF.PlayerName = PlayerName;
        LJF.MusicOnOff = MusicOnOff;
        LJF.SetQuality = SetQuality;
        LJF.V_Coins = V_Coins;
        LJF.PlayerColor = PlayerColor;

        byte[] TEMP = new byte[SkinCount];

        for (int i = 0; i < CurrentSkin.Length; i++)
        {
            TEMP[i] = CurrentSkin[i];
        }

        CurrentSkin = TEMP;
        LJF.CurrentSkin = CurrentSkin;

        string JsonWrite = JsonUtility.ToJson(LJF, true);
        if (PcOrPhoneDetect.ins.Platform == 1) { File.WriteAllText(Application.dataPath + "/PlayerChocolateSave.json", JsonWrite); }
        else { File.WriteAllText(Application.persistentDataPath + "/PlayerChocolateSave.json", JsonWrite); }
    }

    public class LoadJsonFile
    {
        public int LevelComplete;
        public float Volume;
        public bool SFXOnOff;
        public bool MusicOnOff;
        public string PlayerName;
        public float SetQuality;
        public int V_Coins;
        public Color PlayerColor;
        public byte[] CurrentSkin = new byte[LoadJson.loadJson.SkinCountLJF];
    }
}
