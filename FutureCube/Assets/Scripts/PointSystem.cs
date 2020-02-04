using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine;
using System;

public class PointSystem : MonoBehaviour
{
    public static PointSystem pointSystem;

    public int Point = 0;
    public int CoinPoints = 0;
    public int BubblePoints = 0;

    private Text PointText;
    private readonly string TextForCoinPoints = "Coin +";
    private readonly string TextForBubblePoints = "Bubble +";
    private bool ShowAnimation = false;
    [HideInInspector]
    public string TEMP;
    private readonly int i = 0;
    private GameObject BestScore;
    private void Start()
    {
        pointSystem = this;
    }

    void FixedUpdate()
    {
        // If Player is on Pc 
        if (PcOrPhoneDetect.ins.Platform == 1)
        {
            if (Input.GetAxisRaw("Horizontal") < 0 || Input.GetAxisRaw("Horizontal") > 0)
            {
                Point++;
            }
        }

        // If Player is on Phone 
        else if (PcOrPhoneDetect.ins.Platform == 2)
        {
            if (i < Input.touchCount)
            {
                Point++;
            }
        }
    }

    public void CoinCollected(int CoinPointsInput)
    {
        CoinPoints += CoinPointsInput;
        Point += CoinPointsInput;
        ShowAnimation = true;
    }

    public void ForText()
    {
        try
        {
            if (CollectBubble.ins.BubbleActive == true)
            {
                Point += 100;
                BubblePoints += 100;
                ShowAnimation = true;
            }
        }
        catch { }

        // If bubble or Coin Collected Show +200 with Animation
        if (ShowAnimation)
        {
            if (CoinPoints == 0 && BubblePoints != 0)
            {
                GameObject.FindGameObjectWithTag("PointsTagV2").GetComponent<Text>().text = TextForBubblePoints + BubblePoints.ToString();
            }
            if (CoinPoints != 0 && BubblePoints == 0)
            {
                GameObject.FindGameObjectWithTag("PointsTagV2").GetComponent<Text>().text = TextForCoinPoints + CoinPoints.ToString();
            }
            if (CoinPoints != 0 && BubblePoints != 0)
            {
                GameObject.FindGameObjectWithTag("PointsTagV3").GetComponent<Text>().text = TextForCoinPoints + CoinPoints.ToString();
                GameObject.FindGameObjectWithTag("PointsTagV2").GetComponent<Text>().text = TextForBubblePoints + BubblePoints.ToString();
            }
        }

        // Give Player V Coins
        LoadJson.loadJson.JsonEditV_Coins(PointSystem.pointSystem.Point);

        // Set VCoins
        //GameObject.Find("V Coins").GetComponent<ShowVCoinLive>().enabled = true;

        TEMP = "Total Points: " + Point.ToString();

        PointText = GameObject.FindGameObjectWithTag("PointsTag").GetComponent<Text>();

        BestScore = GameObject.Find("Best Score");
        Calc();

        PointText.text = TEMP;

        try { CollectBubble.ins.BubbleActive = false; } catch { }

        enabled = false;
    }

    void Calc()
    {
        // Create a temporary reference to the current scene.
        Scene currentScene = SceneManager.GetActiveScene();

        string TEMP = currentScene.name.Substring(currentScene.name.Length - 2);
        int SceneLevel = Int32.Parse(TEMP);

        switch (SceneLevel)
        {
            case 1:
                if (LevelJson.levelJson.Level01 >= Point)
                {
                    BestScore.GetComponent<Text>().enabled = false;
                }
                break;
            case 2:
                if (LevelJson.levelJson.Level02 >= Point)
                {
                    BestScore.GetComponent<Text>().enabled = false;
                }
                break;
            case 3:
                if (LevelJson.levelJson.Level03 >= Point)
                {
                    BestScore.GetComponent<Text>().enabled = false;
                }
                break;
            case 4:
                if (LevelJson.levelJson.Level04 >= Point)
                {
                    BestScore.GetComponent<Text>().enabled = false;
                }
                break;
            case 5:
                if (LevelJson.levelJson.Level05 >= Point)
                {
                    BestScore.GetComponent<Text>().enabled = false;
                }
                break;
            case 6:
                if (LevelJson.levelJson.Level06 >= Point)
                {
                    BestScore.GetComponent<Text>().enabled = false;
                }
                break;
        }
    }
}
