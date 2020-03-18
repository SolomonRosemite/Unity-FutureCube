using System.Collections.Generic;
using BackendlessAPI.Persistence;
using BackendlessAPI.Exception;
using System.Globalization;
using BackendlessAPI.Async;
using System.Collections;
using Newtonsoft.Json;
using BackendlessAPI;
using UnityEngine;
using System.IO;
using System;

public class BackendDatabase : MonoBehaviour
{
    public static BackendDatabase ins;
    void Start()
    {
        ins = this;

        // logging in to backend
        Backendless.InitApp(GenerateCredentials.applicationId, GenerateCredentials.apiKey);
    }

    public List<string> ReadScore()
    {
        List<string> HighScores = new List<string>();

        DataQueryBuilder queryBuilder = DataQueryBuilder.Create();

        int scoreCount = Backendless.Data.Of("HighScores").GetObjectCount();
        queryBuilder.SetPageSize(scoreCount);

        var scores = Backendless.Data.Of("HighScores").Find(queryBuilder);
        foreach (var item in scores)
        {
            HighScores.Add(item["score"].ToString());
        }

        return HighScores;
    }

    public void WriteScore(string username, string score)
    {
        Dictionary<string, dynamic> scores = new Dictionary<string, dynamic>();

        scores["score"] = score;

        if (UserExists(username))
        {
            Backendless.Data.Of("HighScores").UpdateAsync($"username = '{username}'", scores);
        }
        else
        {
            scores["username"] = username;
            Backendless.Data.Of("HighScores").SaveAsync(scores);
        }
    }

    public bool UserExists(string username)
    {
        DataQueryBuilder queryBuilder = DataQueryBuilder.Create();

        int scoreCount = Backendless.Data.Of("HighScores").GetObjectCount();
        queryBuilder.SetPageSize(scoreCount);

        var scores = Backendless.Data.Of("HighScores").Find(queryBuilder);

        foreach (var item in scores)
        {
            if (username == item["username"].ToString())
            {
                return true;
            }
        }
        return false;
    }

    public void WriteFeedback(string username, string context)
    {
        Dictionary<string, dynamic> user = new Dictionary<string, dynamic>();

        user["username"] = username;
        user["feedbackContext"] = context;

        Backendless.Data.Of("Feedback").Save(user);
    }

    public float GetGameVersion()
    {
        var tempversion = (Backendless.Data.Of("GameVersion").Find())[0];
        double temp = (double)tempversion["version"];
        float version = (float)temp;

        return version;
    }
}