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
        if (LevelCompleted == false)
        {
            if (gameHasEnded == false)
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

                TriesCounter.triesCounter.Lost();
                gameHasEnded = true;
                PauseV2.pauseV2.GameOver();

                // Makes the LevelPercentageText Invisible
                GameObject.Find("LevelPercentageText").GetComponent<Text>().color = new Color(0, 0, 0, 0);
            }
        }
    }
}
