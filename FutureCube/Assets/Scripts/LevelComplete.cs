using System.Linq;
using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelComplete : MonoBehaviour
{
    public string NextScene;

    void Start()
    {
        string currentScene = SceneManager.GetActiveScene().name;

        var levelString = new String(currentScene.Where(Char.IsNumber).ToArray());

        int level = int.Parse(levelString);

        if (level == 6)
        {
            NextScene = $"Thanks for Playing Cube";
            return;
        }
        else if (level < 10)
        {
            NextScene = $"Level0{level + 1}";
            return;
        }

        NextScene = $"Level{level + 1}";
    }

    public void LoadNextLevel()
    {
        // Mission
        Mission.mission.FirstTryFunc();
        Mission.mission.FirstLevelCompleteFunc();

        // Turn off Menu
        GameObject.Find("Menu UI V3").SetActive(false);

        // Create a temporary reference to the current scene.
        Scene currentScene = SceneManager.GetActiveScene();

        int Level = Int32.Parse(currentScene.name.Substring(currentScene.name.Length - 1));

        // Example "Level03" => "03"
        string TEMP = currentScene.name.Substring(currentScene.name.Length - 2);
        int levelInt = Int32.Parse(TEMP);
        LevelJson.levelJson.LevelCompleted(levelInt, PointSystem.pointSystem.Point);

        if (Level == 6)
        {
            LoadJson.loadJson.JsonEditCompletedLevel(10);
        }
        else
        {
            if (Level > LoadJson.loadJson.LevelComplete)
            {
                LoadJson.loadJson.JsonEditCompletedLevel(Level);
            }
        }

        Mission.mission.SeasionOneCompletedFunc(levelInt);
        StartCoroutine(LoadLevel());
    }

    IEnumerator LoadLevel()
    {
        yield return new WaitForSeconds(2.8f);

        TriesCounter.triesCounter.ResetCounter();
        LevelPercentageText.levelPercentageText.TempVar = 0;

        SceneManager.LoadScene(NextScene);
    }

}
