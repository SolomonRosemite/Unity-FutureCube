﻿using UnityEngine;

public class Mission : MonoBehaviour
{
    public static Mission mission;

    [HideInInspector] public bool Reward;

    void Start() => mission = this;

    // When Player Completes the First Level
    public void FirstLevelCompleteFunc()
    {
        if (LevelJson.levelJson.FirstLevelComplete != true)
        {
            Reward = true;

            MissionRewardAni.ins.GetReward("FirstLevelComplete");

            // Give Player V Coins
            LoadJson.loadJson.JsonEditV_Coins(1000);
        }

        // Level Complete for the first time. Only Once
        LevelJson.levelJson.JsonFirstLevelComplete(true);
    }

    // When Player Completes a Level without fail
    public void FirstTryFunc()
    {

        if (LevelJson.levelJson.FirstTry != true && TriesCounter.triesCounter.Tries == 0)
        {
            Reward = true;

            MissionRewardAni.ins.GetReward("FirstTry");

            // Give Player V Coins
            LoadJson.loadJson.JsonEditV_Coins(1700);

        }

        if (TriesCounter.triesCounter.Tries == 0)
        {
            LevelJson.levelJson.JsonFirstTryFunc(true);
        }
    }

    // When Player has fallen off the Platfrom
    public void PlayerOutOfMapFunc()
    {
        if (LevelJson.levelJson.PlayerOutOfMap != true)
        {
            Reward = true;

            Countdown.ins.SetUIOrder();

            MissionRewardAni.ins.GetReward("PlayerOutOfMap");

            // Give Player V Coins
            LoadJson.loadJson.JsonEditV_Coins(500);
        }

        // Level falling out of Map
        LevelJson.levelJson.JsonPlayerOutOfMapFunc(true);
    }

    // When Player Completes the first Season
    public void SeasionOneCompletedFunc(int SceneNum)
    {
        if (SceneNum == 06)
        {
            if (LevelJson.levelJson.SeasionOneCompleted != true)
            {
                Reward = true;

                MissionRewardAni.ins.GetReward("SeasionOneCompleted");

                // Give Player V Coins
                LoadJson.loadJson.JsonEditV_Coins(3000);

            }
            // Complete Seasion One
            LevelJson.levelJson.JsonSeasionOneCompletedFunc(true);
        }
    }
}