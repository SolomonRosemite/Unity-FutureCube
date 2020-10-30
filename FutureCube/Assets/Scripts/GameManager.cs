using System;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    public static GameManager gameManager;

    [HideInInspector]
    public bool gameHasEnded = false;

    public float restartDelay = 1f;

    public GameObject completeLevelUI;

    [HideInInspector]
    public bool LevelCompleted = false;

    private void Start()
    {
        gameManager = this;
    }

    public void CompleteLevel()
    {
        if (PcOrPhoneDetect.ins.Platform == 1)
        {
            GameObject.FindGameObjectWithTag("PlayerPcOrPhone").GetComponent<PlayerMovement>().OnGround = false;
            GameObject.FindGameObjectWithTag("PlayerPcOrPhone").GetComponent<PlayerMovement>().backToMenu = true;
        }
        else if (PcOrPhoneDetect.ins.Platform == 2)
        {
            GameObject.FindGameObjectWithTag("PlayerPcOrPhone").GetComponent<PlayerMovePhone>().OnGround = false;
            GameObject.FindGameObjectWithTag("PlayerPcOrPhone").GetComponent<PlayerMovePhone>().backToMenu = true;
        }

        completeLevelUI.SetActive(true);
    }

    public void EndGame()
    {
        if (LevelCompleted == false && gameHasEnded == false)
        {
            if (PcOrPhoneDetect.ins.Platform == 1)
            {
                GameObject.FindGameObjectWithTag("PlayerPcOrPhone").GetComponent<PlayerMovement>().OnGround = false;
                GameObject.FindGameObjectWithTag("PlayerPcOrPhone").GetComponent<PlayerMovement>().backToMenu = true;
            }
            else if (PcOrPhoneDetect.ins.Platform == 2)
            {
                GameObject.FindGameObjectWithTag("PlayerPcOrPhone").GetComponent<PlayerMovePhone>().OnGround = false;
                GameObject.FindGameObjectWithTag("PlayerPcOrPhone").GetComponent<PlayerMovePhone>().backToMenu = true;
            }

            // Create a temporary reference to the current scene.
            Scene currentScene = SceneManager.GetActiveScene();

            // Retrieve the name of this scene.
            string sceneName = currentScene.name;

            string name = LoadJson.loadJson.PlayerName;

            if (sceneName == "Play No Limit" && name != "Player")
            {
                switch (LoadJson.loadJson.Difficulty)
                {
                    case ChunkDifficulty.easy:
                        BackendDatabase.backend.WriteScoreNoLimitMode(name, new BackendDatabase.NoLimitScore
                        (
                            PointSystem.pointSystem.Point + (int)Score.score.pos,
                            -2
                        ));
                        break;
                    case ChunkDifficulty.medium:
                        BackendDatabase.backend.WriteScoreNoLimitMode(name, new BackendDatabase.NoLimitScore
                        (
                            PointSystem.pointSystem.Point + (int)Score.score.pos,
                            -2
                        ));
                        break;
                    case ChunkDifficulty.hard:
                        BackendDatabase.backend.WriteScoreNoLimitMode(name, new BackendDatabase.NoLimitScore
                        (
                            -2,
                            PointSystem.pointSystem.Point + (int)Score.score.pos
                        ));
                        break;
                }
            }

            TriesCounter.triesCounter.Lost();
            gameHasEnded = true;
            PauseV2.pauseV2.GameOver();

            // Makes the LevelPercentageText Invisible
            GameObject.Find("LevelPercentageText").GetComponent<Text>().color = new Color(0, 0, 0, 0);
            try
            {
                GameObject.Find("Score").GetComponent<Text>().color = new Color(0, 0, 0, 0);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }
    }
}
