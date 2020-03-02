using System.Collections;
using UnityEngine;
using System.IO;

public class LevelJson : MonoBehaviour
{
    public static LevelJson levelJson;

    [HideInInspector] public int Level01;
    [HideInInspector] public int Level02;
    [HideInInspector] public int Level03;
    [HideInInspector] public int Level04;
    [HideInInspector] public int Level05;
    [HideInInspector] public int Level06;

    [HideInInspector] public int Level11;
    [HideInInspector] public int Level12;
    [HideInInspector] public int Level13;
    [HideInInspector] public int Level14;
    [HideInInspector] public int Level15;
    [HideInInspector] public int Level16;
    [HideInInspector] public bool SeasionOneCompleted;
    [HideInInspector] public bool FirstLevelComplete;
    [HideInInspector] public bool PlayerOutOfMap;
    [HideInInspector] public bool FirstTry;
    [HideInInspector] public string Playername;

    void Start()
    {
        levelJson = this;

        StartCoroutine(CheckPlatform());
    }

    public void CreateJson()
    {
        LoadJsonFile LJF = new LoadJsonFile();

        LJF.Playername = "Player";

        LJF.Level01 = -1;
        LJF.Level02 = -1;
        LJF.Level03 = -1;
        LJF.Level04 = -1;
        LJF.Level05 = -1;
        LJF.Level06 = -1;

        LJF.Level11 = -1;
        LJF.Level12 = -1;
        LJF.Level13 = -1;
        LJF.Level14 = -1;
        LJF.Level15 = -1;
        LJF.Level16 = -1;

        LJF.SeasionOneCompleted = false;
        LJF.FirstLevelComplete = false;
        LJF.PlayerOutOfMap = false;
        LJF.FirstTry = false;

        string JsonWrite = JsonUtility.ToJson(LJF, true);
        if (PcOrPhoneDetect.ins.Platform == 1) { File.WriteAllText(Application.dataPath + "/LevelSave.json", JsonWrite); }
        else { File.WriteAllText(Application.persistentDataPath + "/LevelSave.json", JsonWrite); }
    }

    public void JsonLoader()
    {
        string JsonRead;

        if (PcOrPhoneDetect.ins.Platform == 1) { JsonRead = File.ReadAllText(Application.dataPath + "/LevelSave.json"); }
        else { JsonRead = File.ReadAllText(Application.persistentDataPath + "/LevelSave.json"); }

        LoadJsonFile loadedPlayer = JsonUtility.FromJson<LoadJsonFile>(JsonRead);

        Playername = LoadJson.loadJson.PlayerName;

        Level01 = loadedPlayer.Level01;
        Level02 = loadedPlayer.Level02;
        Level03 = loadedPlayer.Level03;
        Level04 = loadedPlayer.Level04;
        Level05 = loadedPlayer.Level05;
        Level06 = loadedPlayer.Level06;

        Level11 = loadedPlayer.Level11;
        Level12 = loadedPlayer.Level12;
        Level13 = loadedPlayer.Level13;
        Level14 = loadedPlayer.Level14;
        Level15 = loadedPlayer.Level15;
        Level16 = loadedPlayer.Level16;

        SeasionOneCompleted = loadedPlayer.SeasionOneCompleted;
        FirstLevelComplete = loadedPlayer.FirstLevelComplete;
        PlayerOutOfMap = loadedPlayer.PlayerOutOfMap;
        FirstTry = loadedPlayer.FirstTry;
    }

    IEnumerator CheckPlatform()
    {
        yield return new WaitForSeconds(1);

        if (PcOrPhoneDetect.ins.Platform == 1)
        {
            // If the Json PlayerData exsist then Load json file
            if (File.Exists(Application.dataPath + "/LevelSave.json")) { JsonLoader(); }
            // If not Create one
            else { CreateJson(); }
        }
        if (PcOrPhoneDetect.ins.Platform == 2)
        {
            // If the Json PlayerData exsist then Load json file
            if (File.Exists(Application.persistentDataPath + "/LevelSave.json")) { JsonLoader(); }
            // If not Create one
            else { CreateJson(); }
        }
        else
        {
        }
    }

    public void LevelCompleted(int SceneLevel, int Score)
    {
        Playername = LoadJson.loadJson.PlayerName;

        switch (SceneLevel)
        {
            case 1:
                if (Level01 < Score)
                {
                    Level01 = Score;
                }
                break;
            case 2:
                if (Level02 < Score)
                {
                    Level02 = Score;
                }
                break;
            case 3:
                if (Level03 < Score)
                {
                    Level03 = Score;
                }
                break;
            case 4:
                if (Level04 < Score)
                {
                    Level04 = Score;
                }
                break;
            case 5:
                if (Level05 < Score)
                {
                    Level05 = Score;
                }
                break;
            case 6:
                if (Level06 < Score)
                {
                    Level06 = Score;
                }
                break;
            case 11:
                if (Level11 < Score)
                {
                    Level11 = Score;
                }
                break;
            case 12:
                if (Level12 < Score)
                {
                    Level12 = Score;
                }
                break;
            case 13:
                if (Level13 < Score)
                {
                    Level13 = Score;
                }
                break;
            case 14:
                if (Level14 < Score)
                {
                    Level14 = Score;
                }
                break;
            case 15:
                if (Level15 < Score)
                {
                    Level15 = Score;
                }
                break;
            case 16:
                if (Level16 < Score)
                {
                    Level16 = Score;
                }
                break;
        }

        if (Playername != "Player")
        {
            SetScoreVerified();
            JsonLoader();
        }
        else
        {
            SetScore();
            JsonLoader();
        }

    }
    public void SetScoreVerified()
    {
        LoadJsonFile LJF = new LoadJsonFile();

        LJF.Playername = LoadJson.loadJson.PlayerName;
        Playername = LoadJson.loadJson.PlayerName;

        LJF.Level01 = Level01;
        LJF.Level02 = Level02;
        LJF.Level03 = Level03;
        LJF.Level04 = Level04;
        LJF.Level05 = Level05;
        LJF.Level06 = Level06;

        LJF.Level11 = Level11;
        LJF.Level12 = Level12;
        LJF.Level13 = Level13;
        LJF.Level14 = Level14;
        LJF.Level15 = Level15;
        LJF.Level16 = Level16;

        LJF.SeasionOneCompleted = SeasionOneCompleted;
        LJF.FirstLevelComplete = FirstLevelComplete;
        LJF.PlayerOutOfMap = PlayerOutOfMap;
        LJF.FirstTry = FirstTry;

        string JsonWrite = JsonUtility.ToJson(LJF, true);
        if (PcOrPhoneDetect.ins.Platform == 1) { File.WriteAllText(Application.dataPath + "/LevelSave.json", JsonWrite); }
        else { File.WriteAllText(Application.persistentDataPath + "/LevelSave.json", JsonWrite); }

        // Upload Player
        string Url = "https://docs.google.com/forms/u/0/d/e/1FAIpQLScym2xMlBKtPTf2ImXAvLbk_VgNsBeoipR5EbIHyUXzx6rkwA/formResponse";
        string[] Entry = new string[1] { "entry.831246646" };
        StartCoroutine(SelfSystemApi.ins.Post(Url, JsonWrite, Entry));
    }

    public void SetScore()
    {
        LoadJsonFile LJF = new LoadJsonFile();

        LJF.Playername = LoadJson.loadJson.PlayerName;
        Playername = LoadJson.loadJson.PlayerName;

        LJF.Level01 = Level01;
        LJF.Level02 = Level02;
        LJF.Level03 = Level03;
        LJF.Level04 = Level04;
        LJF.Level05 = Level05;
        LJF.Level06 = Level06;

        LJF.Level11 = Level11;
        LJF.Level12 = Level12;
        LJF.Level13 = Level13;
        LJF.Level14 = Level14;
        LJF.Level15 = Level15;
        LJF.Level16 = Level16;

        LJF.SeasionOneCompleted = SeasionOneCompleted;
        LJF.FirstLevelComplete = FirstLevelComplete;
        LJF.PlayerOutOfMap = PlayerOutOfMap;
        LJF.FirstTry = FirstTry;

        string JsonWrite = JsonUtility.ToJson(LJF, true);
        if (PcOrPhoneDetect.ins.Platform == 1) { File.WriteAllText(Application.dataPath + "/LevelSave.json", JsonWrite); }
        else { File.WriteAllText(Application.persistentDataPath + "/LevelSave.json", JsonWrite); }
    }

    // Edit's
    public void JsonFirstLevelComplete(bool Input)
    {
        if (FirstLevelComplete != true)
        {
            LoadJsonFile LJF = new LoadJsonFile();

            LJF.Playername = LoadJson.loadJson.PlayerName;
            Playername = LoadJson.loadJson.PlayerName;

            LJF.Level01 = Level01;
            LJF.Level02 = Level02;
            LJF.Level03 = Level03;
            LJF.Level04 = Level04;
            LJF.Level05 = Level05;
            LJF.Level06 = Level06;

            LJF.Level11 = Level11;
            LJF.Level12 = Level12;
            LJF.Level13 = Level13;
            LJF.Level14 = Level14;
            LJF.Level15 = Level15;
            LJF.Level16 = Level16;

            LJF.SeasionOneCompleted = SeasionOneCompleted;
            LJF.FirstLevelComplete = Input;
            FirstLevelComplete = Input;
            LJF.PlayerOutOfMap = PlayerOutOfMap;
            LJF.FirstTry = FirstTry;

            string JsonWrite = JsonUtility.ToJson(LJF, true);
            if (PcOrPhoneDetect.ins.Platform == 1) { File.WriteAllText(Application.dataPath + "/LevelSave.json", JsonWrite); }
            else { File.WriteAllText(Application.persistentDataPath + "/LevelSave.json", JsonWrite); }
        }
    }

    public void JsonFirstTryFunc(bool Input)
    {
        if (FirstTry != true)
        {
            LoadJsonFile LJF = new LoadJsonFile();

            LJF.Playername = LoadJson.loadJson.PlayerName;
            Playername = LoadJson.loadJson.PlayerName;

            LJF.Level01 = Level01;
            LJF.Level02 = Level02;
            LJF.Level03 = Level03;
            LJF.Level04 = Level04;
            LJF.Level05 = Level05;
            LJF.Level06 = Level06;

            LJF.Level11 = Level11;
            LJF.Level12 = Level12;
            LJF.Level13 = Level13;
            LJF.Level14 = Level14;
            LJF.Level15 = Level15;
            LJF.Level16 = Level16;

            LJF.SeasionOneCompleted = SeasionOneCompleted;
            LJF.FirstLevelComplete = FirstLevelComplete;
            LJF.PlayerOutOfMap = PlayerOutOfMap;
            LJF.FirstTry = Input;
            FirstTry = Input;

            string JsonWrite = JsonUtility.ToJson(LJF, true);
            if (PcOrPhoneDetect.ins.Platform == 1) { File.WriteAllText(Application.dataPath + "/LevelSave.json", JsonWrite); }
            else { File.WriteAllText(Application.persistentDataPath + "/LevelSave.json", JsonWrite); }
        }
    }

    public void JsonPlayerOutOfMapFunc(bool Input)
    {
        if (PlayerOutOfMap != true)
        {
            LoadJsonFile LJF = new LoadJsonFile();

            LJF.Playername = LoadJson.loadJson.PlayerName;
            Playername = LoadJson.loadJson.PlayerName;

            LJF.Level01 = Level01;
            LJF.Level02 = Level02;
            LJF.Level03 = Level03;
            LJF.Level04 = Level04;
            LJF.Level05 = Level05;
            LJF.Level06 = Level06;

            LJF.Level11 = Level11;
            LJF.Level12 = Level12;
            LJF.Level13 = Level13;
            LJF.Level14 = Level14;
            LJF.Level15 = Level15;
            LJF.Level16 = Level16;

            LJF.SeasionOneCompleted = SeasionOneCompleted;
            LJF.FirstLevelComplete = FirstLevelComplete;
            LJF.PlayerOutOfMap = Input;
            PlayerOutOfMap = Input;
            LJF.FirstTry = FirstTry;

            string JsonWrite = JsonUtility.ToJson(LJF, true);
            if (PcOrPhoneDetect.ins.Platform == 1) { File.WriteAllText(Application.dataPath + "/LevelSave.json", JsonWrite); }
            else { File.WriteAllText(Application.persistentDataPath + "/LevelSave.json", JsonWrite); }
        }
    }

    public void JsonSeasionOneCompletedFunc(bool Input)
    {
        if (SeasionOneCompleted != true)
        {
            LoadJsonFile LJF = new LoadJsonFile();

            LJF.Playername = LoadJson.loadJson.PlayerName;
            Playername = LoadJson.loadJson.PlayerName;

            LJF.Level01 = Level01;
            LJF.Level02 = Level02;
            LJF.Level03 = Level03;
            LJF.Level04 = Level04;
            LJF.Level05 = Level05;
            LJF.Level06 = Level06;

            LJF.Level11 = Level11;
            LJF.Level12 = Level12;
            LJF.Level13 = Level13;
            LJF.Level14 = Level14;
            LJF.Level15 = Level15;
            LJF.Level16 = Level16;

            LJF.SeasionOneCompleted = Input;
            SeasionOneCompleted = Input;
            LJF.FirstLevelComplete = FirstLevelComplete;
            LJF.PlayerOutOfMap = PlayerOutOfMap;
            LJF.FirstTry = FirstTry;

            string JsonWrite = JsonUtility.ToJson(LJF, true);
            if (PcOrPhoneDetect.ins.Platform == 1) { File.WriteAllText(Application.dataPath + "/LevelSave.json", JsonWrite); }
            else { File.WriteAllText(Application.persistentDataPath + "/LevelSave.json", JsonWrite); }
        }
    }

    public void Setname()
    {
        LoadJsonFile LJF = new LoadJsonFile();

        LJF.Playername = LoadJson.loadJson.PlayerName;
        Playername = LoadJson.loadJson.PlayerName;

        LJF.Level01 = Level01;
        LJF.Level02 = Level02;
        LJF.Level03 = Level03;
        LJF.Level04 = Level04;
        LJF.Level05 = Level05;
        LJF.Level06 = Level06;

        LJF.Level11 = Level11;
        LJF.Level12 = Level12;
        LJF.Level13 = Level13;
        LJF.Level14 = Level14;
        LJF.Level15 = Level15;
        LJF.Level16 = Level16;

        LJF.SeasionOneCompleted = SeasionOneCompleted;
        LJF.FirstLevelComplete = FirstLevelComplete;
        LJF.PlayerOutOfMap = PlayerOutOfMap;
        LJF.FirstTry = FirstTry;

        SetScoreVerified();

        string JsonWrite = JsonUtility.ToJson(LJF, true);
        if (PcOrPhoneDetect.ins.Platform == 1) { File.WriteAllText(Application.dataPath + "/LevelSave.json", JsonWrite); }
        else { File.WriteAllText(Application.persistentDataPath + "/LevelSave.json", JsonWrite); }
    }

    [SerializeField]
    public class LoadJsonFile
    {
        public string Playername;

        // Seasion One
        public int Level01;
        public int Level02;
        public int Level03;
        public int Level04;
        public int Level05;
        public int Level06;

        // Season Two
        public int Level11;
        public int Level12;
        public int Level13;
        public int Level14;
        public int Level15;
        public int Level16;

        // Mission
        public bool FirstLevelComplete;
        public bool FirstTry;
        public bool PlayerOutOfMap;
        public bool SeasionOneCompleted;
    }
}
