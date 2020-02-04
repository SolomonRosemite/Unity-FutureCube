using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelComplete : MonoBehaviour
{
    public string NextSence;

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
        int Last2Level = Int32.Parse(TEMP);

        LevelJson.levelJson.LevelCompleted(Last2Level, PointSystem.pointSystem.Point);

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

        Mission.mission.SeasionOneCompletedFunc(Last2Level);
        StartCoroutine(LoadLevel());
    }

    IEnumerator LoadLevel()
    {
        yield return new WaitForSeconds(2.8f);

        TriesCounter.triesCounter.ResetCounter();
        LevelPercentageText.levelPercentageText.TempVar = 0;

        SceneManager.LoadScene(NextSence);
    }

}
