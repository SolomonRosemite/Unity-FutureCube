using System.Collections.Generic;
using System.Collections;
using UnityEngine.UI;
using UnityEngine;

public class SetLeaderboardUI : MonoBehaviour
{
    public static SetLeaderboardUI ins;
    private Text context;

    void Start()
    {
        ins = this;
        context = gameObject.GetComponent<Text>();

        try { context.text = "of all Total Points"; } catch { }
    }

    public void UpdateText(string Level)
    {
        if (Level.Contains("Level"))
        {
            context.text = "of " + Level;
        }
        else
        {
            context.text = "of all Total Points";
        }
    }

}
