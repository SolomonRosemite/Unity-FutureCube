using System.Collections.Generic;
using BackendlessAPI.Persistence;
using System.Threading.Tasks;
using BackendlessAPI;
using UnityEngine;

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

        if ((await UserExists(username)).Item2)
        {
            Backendless.Data.Of("HighScores").Update($"username = '{username}'", scores);
        }
        else
        {
            scores["username"] = username;
            Backendless.Data.Of("HighScores").Save(scores);
        }
    }

    public async void WriteScoreNoLimitMode(string username, NoLimitScore score)
    {
        Dictionary<string, object> scores = new Dictionary<string, object>();
        string table = "NoLimitScores";

        string scoreKey;

        if (score.HardScore != -2)
        {
            scores["HardScore"] = score.HardScore;
            scoreKey = "HardScore";
        }
        else
        {
            scores["NormalScore"] = score.NormalScore;
            scoreKey = "NormalScore";
        }

        var x = await UserExists(username, table);

        int currentScore = System.Convert.ToInt32(x.Item1[scoreKey]);

        if (x.Item2)
        {
            if ((int)scores[scoreKey] > currentScore)
                await Backendless.Data.Of(table).UpdateAsync($"username = '{username}'", scores);
        }
        else
        {
            scores["username"] = username;
            await Backendless.Data.Of(table).SaveAsync(scores);
        }
    }

    public async Task<(Dictionary<string, object>, bool)> UserExists(string username, string table = "HighScores")
    {
        DataQueryBuilder queryBuilder = DataQueryBuilder.Create();

        int count = await Backendless.Data.Of(table).GetObjectCountAsync();
        queryBuilder.SetPageSize(count == 0 ? 1 : count);

        var scores = await Backendless.Data.Of(table).FindAsync(queryBuilder);

        foreach (var item in scores)
        {
            if (username == item["username"].ToString())
            {
                return (item, true);
            }
        }
        return (null, false);
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

    public class NoLimitScore
    {
        public readonly int NormalScore;
        public readonly int HardScore;

        public NoLimitScore(int NormalScore, int HardScore)
        {
            this.NormalScore = NormalScore;
            this.HardScore = HardScore;
        }
    }
}