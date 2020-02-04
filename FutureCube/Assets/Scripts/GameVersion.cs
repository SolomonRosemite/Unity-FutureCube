using UnityEngine.SceneManagement;
using System.Collections;
using UnityEngine;

public class GameVersion : MonoBehaviour
{
    private string VersionTEMP;
    private float Version;
    private bool UpdateAvailable;


    private float nextActionTime;
    private float period = 0.5f;

    void Start()
    {
        if (Application.internetReachability != NetworkReachability.NotReachable)
        {
            StartCoroutine(CheckVersion());
        }
        else
        {
            //Player is Offline
        }
    }

    IEnumerator CheckVersion()
    {
        yield return new WaitForSeconds(2.5f);

        StartCoroutine(SelfSystemApi.ins.GetContent("https://docs.google.com/spreadsheets/d/e/2PACX-1vQ5aZVt76NCY0w1MeogvmBP1T79lfayXye6bp1aII-u_U2L8qWKZESG7J2ZWBnjDfA7Fvmh4Sz6g0zw/pub?gid=522086444&single=true&output=tsv", false));

        while (SelfSystemApi.ins.WebResponseTEMP == null)
        {
            // wait
            yield return new WaitForSeconds(1);
        }

        VersionTEMP = SelfSystemApi.ins.WebResponseTEMP;

        var pattern = @"(\{(?:.*?)\})";
        foreach (string m in System.Text.RegularExpressions.Regex.Split(VersionTEMP, pattern))
        {
            if (m.Contains("{"))
            {
                VersionTEMP = m.Remove(m.Length - 1);
                VersionTEMP = VersionTEMP.Substring(1);
                Version = float.Parse(VersionTEMP);
            }
        }

        if (Version > LoadJson.Version)
        {
            UpdateAvailable = true;
        }
        else
        {
            enabled = false;
        }

    }

    void Update()
    {
        if (Time.time > nextActionTime)
        {
            nextActionTime += period;

            // Create a temporary reference to the current scene.
            Scene currentScene = SceneManager.GetActiveScene();

            if (UpdateAvailable == true && currentScene.name == "Select Mode")
            {
                GameObject.Find("Manager").GetComponent<SelectRandomV2>().UpdateGO();
                LoadJson.loadJson.UpdateAvailable = true;
                enabled = false;
            }
        }
    }

}
