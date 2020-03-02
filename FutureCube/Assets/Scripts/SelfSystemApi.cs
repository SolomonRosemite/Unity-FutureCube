using System.Text.RegularExpressions;
using UnityEngine.SceneManagement;
using System.Collections.Generic;
using UnityEngine.Networking;
using System.Collections;
using UnityEngine.UI;
using UnityEngine;

public class SelfSystemApi : MonoBehaviour
{
    [HideInInspector] public static SelfSystemApi ins;
    [HideInInspector] public GameObject FeedBack;
    [HideInInspector] public string WebResponseTEMP;
    [HideInInspector] public int count = 0;

    List<string> JsonPlayer = new List<string>();
    List<string> JsonPlayerTEMP = new List<string>();
    private string FeedBackText;
    private string URL;
    private string[] Entry = new string[1];
    private string WebResponse;

    private float nextActionTime = 0.0f;
    private float period = 1f;
    private bool CheckedAlready = false;

    [Space]

    public bool Test = false;
    // HighScore System
    [HideInInspector] public List<string> Playername = new List<string>();
    [HideInInspector] public List<int> Level01 = new List<int>();
    [HideInInspector] public List<int> Level02 = new List<int>();
    [HideInInspector] public List<int> Level03 = new List<int>();
    [HideInInspector] public List<int> Level04 = new List<int>();
    [HideInInspector] public List<int> Level05 = new List<int>();
    [HideInInspector] public List<int> Level06 = new List<int>();
    [HideInInspector] public List<int> Level11 = new List<int>();
    [HideInInspector] public List<int> Level12 = new List<int>();
    [HideInInspector] public List<int> Level13 = new List<int>();
    [HideInInspector] public List<int> Level14 = new List<int>();
    [HideInInspector] public List<int> Level15 = new List<int>();
    [HideInInspector] public List<int> Level16 = new List<int>();
    [HideInInspector] public List<int> TotalPoints = new List<int>();

    void Start()
    {
        ins = this;
        Set();

        if (Test == true)
        {
            StartCoroutine(GetContent("https://docs.google.com/spreadsheets/d/e/2PACX-1vQ5aZVt76NCY0w1MeogvmBP1T79lfayXye6bp1aII-u_U2L8qWKZESG7J2ZWBnjDfA7Fvmh4Sz6g0zw/pub?gid=1522364317&single=true&output=tsv"));
        }

        // Create a temporary reference to the current scene.
        Scene currentScene = SceneManager.GetActiveScene();
        if (currentScene.name == "Leaderboard V2")
        {
            try { SmallFunctions.ins.SetScoreBoardOffline(CheckInternet()); } catch { }
            StartCoroutine(GetContent("https://docs.google.com/spreadsheets/d/e/2PACX-1vQ5aZVt76NCY0w1MeogvmBP1T79lfayXye6bp1aII-u_U2L8qWKZESG7J2ZWBnjDfA7Fvmh4Sz6g0zw/pub?gid=1522364317&single=true&output=tsv"));
        }
    }

    void Update()
    {
        if (Time.time > nextActionTime)
        {
            nextActionTime += period;

            // Create a temporary reference to the current scene.
            Scene currentScene = SceneManager.GetActiveScene();
            if ("Clean Settings UI" == currentScene.name)
            {
                try
                {
                    CheckedAlready = true;
                    StartCoroutine(GetContent("https://docs.google.com/spreadsheets/d/e/2PACX-1vQ5aZVt76NCY0w1MeogvmBP1T79lfayXye6bp1aII-u_U2L8qWKZESG7J2ZWBnjDfA7Fvmh4Sz6g0zw/pub?gid=1522364317&single=true&output=tsv"));
                }
                catch
                {
                    print("bad");
                    TotalPoints.Clear();
                    Playername.Clear();

                    Level01.Clear();
                    Level02.Clear();
                    Level03.Clear();
                    Level04.Clear();
                    Level05.Clear();
                    Level06.Clear();

                    Level11.Clear();
                    Level12.Clear();
                    Level13.Clear();
                    Level14.Clear();
                    Level15.Clear();
                    Level16.Clear();
                }
            }
            else if ("Select Mode" == currentScene.name && CheckedAlready == true)
            {
                TotalPoints.Clear();
                Playername.Clear();

                Level01.Clear();
                Level02.Clear();
                Level03.Clear();
                Level04.Clear();
                Level05.Clear();
                Level06.Clear();

                Level11.Clear();
                Level12.Clear();
                Level13.Clear();
                Level14.Clear();
                Level15.Clear();
                Level16.Clear();

                CheckedAlready = false;
            }
        }
    }

    void Set()
    {
        Entry[0] = "entry.239890376";
        URL = "https://docs.google.com/forms/u/0/d/e/1FAIpQLScGp0DH8zwcc5Pdpd9MYBiZZlQzkxIz14OrPRTc_u1HvrGBcQ/formResponse";
    }

    public IEnumerator Post(string url, string context, string[] entry)
    {
        WWWForm form = new WWWForm();

        for (int i = 0; i < entry.Length; i++)
        {
            form.AddField(entry[i], context);
        }

        using (UnityWebRequest www = UnityWebRequest.Post(url, form))
        {
            yield return www.SendWebRequest();

            if (www.isNetworkError || www.isHttpError)
            {
                Debug.Log(www.error + " bad");
            }
            else
            {
                Debug.Log("Form upload complete!");
            }
        }
    }

    public IEnumerator GetContent(string uri, bool UseScore = true)
    {
        WebResponseTEMP = null;

        using (UnityWebRequest webRequest = UnityWebRequest.Get(uri))
        {
            // Request and wait for the desired page.
            yield return webRequest.SendWebRequest();

            string[] pages = uri.Split(',');
            int page = pages.Length - 1;

            if (webRequest.isNetworkError)
            {
                Debug.Log(pages[page] + ": Error: " + webRequest.error);
            }
            else
            {
                WebResponse = webRequest.downloadHandler.text;
                if (UseScore == true)
                {
                    SetScore();
                }
                else
                {
                    WebResponseTEMP = webRequest.downloadHandler.text;
                }
            }
        }
    }

    void SetScore()
    {
        var pattern = @"(\{(?:.*?)\})";
        int index = 0;
        foreach (string m in System.Text.RegularExpressions.Regex.Split(WebResponse, pattern))
        {
            if (m.Contains("{"))
            {
                JsonPlayer.Add(m);
                index++;
            }
        }

        index--;

        int Tempindex = 0;


        while (index >= Tempindex)
        {
            // Read Json (String)
            Json(JsonPlayer[index]);
            index--;
        }
        try { GameObject.Find("GameHandler").GetComponent<SmallFunctionsV2>().Go(); } catch { }
    }

    void Json(string JsonRead)
    {
        LoadJsonFile loadedPlayer = JsonUtility.FromJson<LoadJsonFile>(JsonRead);

        bool Add = true;

        for (int i = 0; i < count; i++)
        {
            if (Playername[i] == loadedPlayer.Playername)
            {
                Add = false;
            }
        }

        if (Add == true)
        {
            Playername.Add(loadedPlayer.Playername);
            Level01.Add(loadedPlayer.Level01);
            Level02.Add(loadedPlayer.Level02);
            Level03.Add(loadedPlayer.Level03);
            Level04.Add(loadedPlayer.Level04);
            Level05.Add(loadedPlayer.Level05);
            Level06.Add(loadedPlayer.Level06);

            Level06.Add(loadedPlayer.Level11);
            Level06.Add(loadedPlayer.Level12);
            Level06.Add(loadedPlayer.Level13);
            Level06.Add(loadedPlayer.Level14);
            Level06.Add(loadedPlayer.Level15);
            Level06.Add(loadedPlayer.Level16);

            TotalPoints.Add(loadedPlayer.Level01 + loadedPlayer.Level02 + loadedPlayer.Level03 + loadedPlayer.Level04 + loadedPlayer.Level05 + loadedPlayer.Level06 + loadedPlayer.Level11 + loadedPlayer.Level12 + loadedPlayer.Level13 + loadedPlayer.Level14 + loadedPlayer.Level15 + loadedPlayer.Level16);

            count++;

            Add = false;
        }

    }

    public void Send()
    {
        FeedBackText = FeedBack.GetComponent<InputField>().text;
        StartCoroutine(Post(URL, FeedBackText, Entry));
    }

    public void SendFromButton(string context)
    {
        StartCoroutine(Post(URL, context, Entry));
    }

    public void SendFullRequest(string url, string context, string[] entry)
    {
        StartCoroutine(Post(url, context, entry));
    }

    bool CheckInternet()
    {
        if (Application.internetReachability == NetworkReachability.NotReachable)
        {
            print("Player is Offline");
            return true;
        }
        print("Player is Online");
        return false;
    }

    public class LoadJsonFile
    {
        public string Playername;
        public int Level01;
        public int Level02;
        public int Level03;
        public int Level04;
        public int Level05;
        public int Level06;
        public int Level11;
        public int Level12;
        public int Level13;
        public int Level14;
        public int Level15;
        public int Level16;
    }
}