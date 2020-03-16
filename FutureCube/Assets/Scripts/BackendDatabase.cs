using System.Collections.Generic;
using BackendlessAPI.Exception;
using BackendlessAPI.Async;
using System.Collections;
using Newtonsoft.Json;
using BackendlessAPI;
using UnityEngine;
using System.IO;
using System;

public class BackendDatabase : MonoBehaviour
{
    void Start()
    {
        // logging to backend
        Dictionary<string, dynamic> json = new Dictionary<string, dynamic>();

        // Read Json
        string jsonFromFile;
        using (var reader = new StreamReader("Assets\\Scripts\\credentials.json"))
        {
            jsonFromFile = reader.ReadToEnd();
        }

        json = JsonConvert.DeserializeObject<Dictionary<string, dynamic>>(jsonFromFile);

        Backendless.InitApp(json["applicationId"], json["api-key"]);

        // string username = "ChickenFarm";
        WriteScore("Jeese", "100");
    }

    static void ReadScore()
    {
        List<string> HighScores = new List<string>();

        var scores = Backendless.Data.Of("HighScores").Find();
        foreach (var item in scores)
        {
            HighScores.Add(item["score"].ToString());
        }

        foreach (var item in HighScores)
        {
            Console.WriteLine(item);
        }
    }

    static void WriteScore(string username, string score)
    {
        Dictionary<string, dynamic> scores = new Dictionary<string, dynamic>();

        scores["username"] = username;
        scores["score"] = score;

        if (UserExists(username))
        {
            Backendless.Data.Of("HighScores").Update($"username = '{username}'", scores);
        }
        else
        {
            Backendless.Data.Of("HighScores").Save(scores);
        }
    }

    static bool UserExists(string username)
    {
        var scores = Backendless.Data.Of("HighScores").Find();
        foreach (var item in scores)
        {
            if (username == item["username"].ToString())
            {
                return true;
            }
        }
        return false;
    }
}
