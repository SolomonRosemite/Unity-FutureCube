using UnityEngine.SceneManagement;
using System.Collections;
using UnityEngine.UI;
using UnityEngine;

public class SmallFunctions : MonoBehaviour
{
    public static SmallFunctions ins;
    public bool TurnOffMusic;

    public GameObject FeedBackPanel;

    void Start()
    {
        ins = this;

        // Create a temporary reference to the current scene.
        Scene currentScene = SceneManager.GetActiveScene();

        if (currentScene.name == "Level06" && TurnOffMusic == true)
        {
            StartCoroutine(Set());
        }
    }

    IEnumerator Set()
    {
        yield return new WaitForSeconds(1.5f);

        FindAndKill.ins.EndOfScene();
        FindMusic.ins.Trigger();
    }

    public void FixScene()
    {
        GameObject.FindGameObjectWithTag("PlayerPcOrPhone").GetComponent<PlayerCollision>().backToMenu = true;
    }

    public void SetBackSortingOrder()
    {
        GameObject.FindGameObjectWithTag("Manager Canvas").GetComponent<Canvas>().sortingOrder = 998;
    }

    public void FeedBack()
    {
        string context = GameObject.Find("InputField FeedBack").GetComponent<InputField>().text;
        BackendDatabase.backend.WriteFeedback(LoadJson.loadJson.PlayerName, context);
        FeedBackPanel.SetActive(true);
    }

    public void SetScoreBoardActive()
    {
        GameObject.Find("GameHandler").GetComponent<SmallFunctionsV2>().Go();
    }

    public void SetScoreBoardOffline(bool Offline)
    {
        GameObject.Find("GameHandler").GetComponent<SmallFunctionsV2>().ShowGameObject(Offline);

        if (Offline != true)
        {
            GameObject.Find("GameHandler").GetComponent<SmallFunctionsV2>().SetText("Loading...");
        }
    }

}
