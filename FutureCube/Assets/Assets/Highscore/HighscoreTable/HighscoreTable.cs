using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class HighscoreTable : MonoBehaviour
{
    private Transform entryContainer;
    private Transform entryTemplate;
    private List<Transform> highscoreEntryTransformList;
    private byte entrysTotal;
    public float templateHeight;
    public string ScoreOf = "Total";

    private void Start()
    {
        PlayerPrefs.DeleteAll();

        // Idk what this is
        entryContainer = transform.Find("highscoreEntryContainer");
        entryTemplate = entryContainer.Find("highscoreEntryTemplate");
        entryTemplate.gameObject.SetActive(false);
        string jsonString = PlayerPrefs.GetString("highscoreTable");
        Highscores highscores = JsonUtility.FromJson<Highscores>(jsonString);

        switch (ScoreOf)
        {
            case "Level01":
                for (int i = 0; i < SelfSystemApi.ins.count; i++)
                {
                    AddHighscoreEntry(SelfSystemApi.ins.Level01[i], SelfSystemApi.ins.Playername[i]);
                }
                break;

            case "Level02":
                for (int i = 0; i < SelfSystemApi.ins.count; i++)
                {
                    AddHighscoreEntry(SelfSystemApi.ins.Level02[i], SelfSystemApi.ins.Playername[i]);
                }
                break;

            case "Level03":
                for (int i = 0; i < SelfSystemApi.ins.count; i++)
                {
                    AddHighscoreEntry(SelfSystemApi.ins.Level03[i], SelfSystemApi.ins.Playername[i]);
                }
                break;

            case "Level04":
                for (int i = 0; i < SelfSystemApi.ins.count; i++)
                {
                    AddHighscoreEntry(SelfSystemApi.ins.Level04[i], SelfSystemApi.ins.Playername[i]);
                }
                break;

            case "Level05":
                for (int i = 0; i < SelfSystemApi.ins.count; i++)
                {
                    AddHighscoreEntry(SelfSystemApi.ins.Level05[i], SelfSystemApi.ins.Playername[i]);
                }
                break;

            case "Level06":
                for (int i = 0; i < SelfSystemApi.ins.count; i++)
                {
                    AddHighscoreEntry(SelfSystemApi.ins.Level06[i], SelfSystemApi.ins.Playername[i]);
                }
                break;

            case "Level11":
                for (int i = 0; i < SelfSystemApi.ins.count; i++)
                {
                    AddHighscoreEntry(SelfSystemApi.ins.Level11[i], SelfSystemApi.ins.Playername[i]);
                }
                break;

            case "Level12":
                for (int i = 0; i < SelfSystemApi.ins.count; i++)
                {
                    AddHighscoreEntry(SelfSystemApi.ins.Level12[i], SelfSystemApi.ins.Playername[i]);
                }
                break;

            case "Level13":
                for (int i = 0; i < SelfSystemApi.ins.count; i++)
                {
                    AddHighscoreEntry(SelfSystemApi.ins.Level13[i], SelfSystemApi.ins.Playername[i]);
                }
                break;

            case "Level14":
                for (int i = 0; i < SelfSystemApi.ins.count; i++)
                {
                    AddHighscoreEntry(SelfSystemApi.ins.Level14[i], SelfSystemApi.ins.Playername[i]);
                }
                break;

            case "Level15":
                for (int i = 0; i < SelfSystemApi.ins.count; i++)
                {
                    AddHighscoreEntry(SelfSystemApi.ins.Level15[i], SelfSystemApi.ins.Playername[i]);
                }
                break;

            case "Level16":
                for (int i = 0; i < SelfSystemApi.ins.count; i++)
                {
                    AddHighscoreEntry(SelfSystemApi.ins.Level16[i], SelfSystemApi.ins.Playername[i]);
                }
                break;

            case "Total":
                for (int i = 0; i < SelfSystemApi.ins.count; i++)
                {
                    AddHighscoreEntry(SelfSystemApi.ins.TotalPoints[i], SelfSystemApi.ins.Playername[i]);
                }

                break;
        }

        // Reload
        jsonString = PlayerPrefs.GetString("highscoreTable");
        highscores = JsonUtility.FromJson<Highscores>(jsonString);

        // Sort entry list by Score
        for (int i = 0; i < highscores.highscoreEntryList.Count; i++)
        {
            for (int j = i + 1; j < highscores.highscoreEntryList.Count; j++)
            {
                if (highscores.highscoreEntryList[j].score > highscores.highscoreEntryList[i].score)
                {
                    // Swap
                    (highscores.highscoreEntryList[i], highscores.highscoreEntryList[j]) = (highscores.highscoreEntryList[j], highscores.highscoreEntryList[i]);
                }
            }
        }
        // highscores.highscoreEntryList.Sort(Highscores.highscoreEntryList);

        highscoreEntryTransformList = new List<Transform>();
        foreach (HighscoreEntry highscoreEntry in highscores.highscoreEntryList)
        {
            if (12 > entrysTotal)
            {
                if (highscoreEntry.name == LoadJson.loadJson.PlayerName)
                {
                    CreateHighscoreEntryTransform(highscoreEntry, entryContainer, highscoreEntryTransformList, true);
                }
                else
                {
                    CreateHighscoreEntryTransform(highscoreEntry, entryContainer, highscoreEntryTransformList);
                }
                entrysTotal++;
            }
        }
    }

    private void CreateHighscoreEntryTransform(HighscoreEntry highscoreEntry, Transform container, List<Transform> transformList, bool ThisPlayer = false)
    {
        Transform entryTransform = Instantiate(entryTemplate, container);
        RectTransform entryRectTransform = entryTransform.GetComponent<RectTransform>();
        entryRectTransform.anchoredPosition = new Vector2(0, -templateHeight * transformList.Count);
        entryTransform.gameObject.SetActive(true);

        int rank = transformList.Count + 1;
        string rankString;
        switch (rank)
        {
            default: rankString = rank + "TH"; break;

            case 1: rankString = "1ST"; break;
            case 2: rankString = "2ND"; break;
            case 3: rankString = "3RD"; break;
        }

        entryTransform.Find("posText").GetComponent<Text>().text = rankString;

        int score = highscoreEntry.score;

        entryTransform.Find("scoreText").GetComponent<Text>().text = score.ToString();

        string name = highscoreEntry.name;
        entryTransform.Find("nameText").GetComponent<Text>().text = name;

        // Highlight First
        if (rank == 1)
        {
            entryTransform.Find("posText").GetComponent<Text>().color = Color.green;
            entryTransform.Find("scoreText").GetComponent<Text>().color = Color.green;
            entryTransform.Find("nameText").GetComponent<Text>().color = Color.green;
        }

        if (ThisPlayer == true)
        {
            entryTransform.Find("posText").GetComponent<Text>().color = Color.magenta;
            entryTransform.Find("scoreText").GetComponent<Text>().color = Color.magenta;
            entryTransform.Find("nameText").GetComponent<Text>().color = Color.magenta;
        }

        // Set tropy
        switch (rank)
        {
            default:
                entryTransform.Find("trophy").gameObject.SetActive(false);
                entryTransform.Find("1st").gameObject.SetActive(false);
                entryTransform.Find("2st").gameObject.SetActive(false);
                entryTransform.Find("3st").gameObject.SetActive(false);
                break;
            case 1:
                entryTransform.Find("2st").gameObject.SetActive(false);
                entryTransform.Find("3st").gameObject.SetActive(false);
                break;
            case 2:
                entryTransform.Find("1st").gameObject.SetActive(false);
                entryTransform.Find("3st").gameObject.SetActive(false);
                break;
            case 3:
                entryTransform.Find("1st").gameObject.SetActive(false);
                entryTransform.Find("2st").gameObject.SetActive(false);
                break;

        }

        transformList.Add(entryTransform);
    }

    private void AddHighscoreEntry(int score, string name)
    {
        // Create HighscoreEntry
        HighscoreEntry highscoreEntry = new HighscoreEntry { score = score, name = name };

        // Load saved Highscores
        string jsonString = PlayerPrefs.GetString("highscoreTable");
        Highscores highscores = JsonUtility.FromJson<Highscores>(jsonString);

        if (highscores == null)
        {
            // There's no stored table, initialize
            highscores = new Highscores()
            {
                highscoreEntryList = new List<HighscoreEntry>()
            };
        }

        // Add new entry to Highscores
        highscores.highscoreEntryList.Add(highscoreEntry);

        // Save updated Highscores
        string json = JsonUtility.ToJson(highscores);
        PlayerPrefs.SetString("highscoreTable", json);
    }

    private class Highscores
    {
        public List<HighscoreEntry> highscoreEntryList;
    }


    [System.Serializable]
    private class HighscoreEntry
    {
        public int score;
        public string name;
    }

}
