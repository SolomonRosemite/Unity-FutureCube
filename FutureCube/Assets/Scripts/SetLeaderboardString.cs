using System.Collections.Generic;
using System.Collections;
using UnityEngine;

public class SetLeaderboardString : MonoBehaviour
{
    public GameObject[] gameObjects;

    // Is Getting Called from a button.
    public void ShowLeaderboard(string Level)
    {
        for (int i = 0; i < gameObjects.Length; i++)
        {
            if (gameObjects[i].name != Level)
            {
                gameObjects[i].SetActive(false);
            }
            else
            {
                gameObjects[i].SetActive(true);
            }
        }

        SetLeaderboardUI.ins.UpdateText("Level " + Level);
    }

    public void Hide()
    {
    }


}
