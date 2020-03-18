using System.Collections.Generic;
using BackendlessAPI.Persistence;
using BackendlessAPI.Exception;
using System.Threading.Tasks;
using System.Globalization;
using BackendlessAPI.Async;
using System.Collections;
using BackendlessAPI;
using UnityEngine;
using System.IO;
using System;

public class BackendDatabase : MonoBehaviour
{
    public static BackendDatabase backend;
    void Start()
    {
        backend = this;

        // logging in to backend
        Backendless.InitApp(GenerateCredentials.applicationId, GenerateCredentials.apiKey);
    }

    public async Task<List<string>> ReadScore()
    {
        List<string> HighScores = new List<string>();

        DataQueryBuilder queryBuilder = DataQueryBuilder.Create();

        int scoreCount = await Backendless.Data.Of("HighScores").GetObjectCountAsync();
        queryBuilder.SetPageSize(scoreCount);

        var scores = await Backendless.Data.Of("HighScores").FindAsync(queryBuilder);
        foreach (var item in scores)
        {
            HighScores.Add(item["score"].ToString());
        }

        return HighScores;
    }

    public async void WriteScore(string username, string score)
    {
        Dictionary<string, dynamic> scores = new Dictionary<string, dynamic>();

        scores["score"] = score;

        if (await UserExists(username))
        {
            Backendless.Data.Of("HighScores").Update($"username = '{username}'", scores);
        }
        else
        {
            scores["username"] = username;
            Backendless.Data.Of("HighScores").Save(scores);
        }
    }

    public async Task<bool> UserExists(string username)
    {
        DataQueryBuilder queryBuilder = DataQueryBuilder.Create();

        int scoreCount = await Backendless.Data.Of("HighScores").GetObjectCountAsync();
        queryBuilder.SetPageSize(scoreCount);

        var scores = await Backendless.Data.Of("HighScores").FindAsync(queryBuilder);

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

        Backendless.Data.Of("Feedback").SaveAsync(user);
    }

    public async Task<float> GetGameVersion()
    {
        var tempversion = (await Backendless.Data.Of("GameVersion").FindAsync())[0];
        double temp = (double)tempversion["version"];
        float version = (float)temp;

        return version;
    }
}