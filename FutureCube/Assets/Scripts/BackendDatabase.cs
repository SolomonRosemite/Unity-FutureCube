using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

using Firebase.Firestore;

public class BackendDatabase : MonoBehaviour
{
    public static BackendDatabase backend;
    private FirebaseFirestore db;

    void Start()
    {
        db = FirebaseFirestore.DefaultInstance;
        backend = this;
    }

    public async Task<List<string>> ReadScore()
    {
        List<string> HighScores = new List<string>();

        CollectionReference reference;
        reference = db.Collection("HighScores");
        var scores = await (reference.GetSnapshotAsync());

        foreach (var item in scores)
        {
            HighScores.Add(item.ToDictionary()["score"].ToString());
        }

        return HighScores;
    }

    public async void WriteScore(string username, string jsonScore)
    {
        string table = "HighScores";

        Dictionary<string, dynamic> scores = new Dictionary<string, dynamic>();
        scores["score"] = jsonScore;
        scores["username"] = username;

        DocumentReference reference;
        reference = db.Collection(table).Document(username);

        await reference.SetAsync(scores, SetOptions.MergeAll);
    }

    public async Task<(Dictionary<string, object>, bool)> GetPlayerNoLimitModeScore(string username)
    {
        DocumentReference reference;
        reference = db.Collection("NoLimitScores").Document(username);

        var doc = await reference.GetSnapshotAsync();
        return (doc.ToDictionary(), doc.Exists);
    }

    public async void WriteScoreNoLimitMode(string username, NoLimitScore score)
    {
        Dictionary<string, object> scores = new Dictionary<string, object>();
        scores["username"] = username;

        string table = "NoLimitScores";

        DocumentReference reference;
        reference = db.Collection(table).Document(username);

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

        var value = await GetPlayerNoLimitModeScore(username);

        if (value.Item2 == false)
        {
            if (scoreKey == "NormalScore")
            {
                scores["HardScore"] = -2;
                await reference.SetAsync(scores, SetOptions.MergeAll);
                return;
            }

            scores["NormalScore"] = -2;
            await reference.SetAsync(scores, SetOptions.MergeAll);
            return;
        }

        int currentScore = System.Convert.ToInt32(value.Item1[scoreKey]);

        scores[scoreKey] = Mathf.Max((int)scores[scoreKey], currentScore);

        await reference.SetAsync(scores, SetOptions.MergeAll);
    }

    public async Task<(Dictionary<string, object>, bool)> UserExists(string username, string table = "HighScores")
    {
        CollectionReference reference;
        reference = db.Collection("HighScores");
        var scores = await (reference.GetSnapshotAsync());

        foreach (var item in scores)
        {
            if (username == item.ToDictionary()["username"].ToString())
            {
                return (item.ToDictionary(), true);
            }
        }
        return (null, false);
    }

    public void WriteFeedback(string username, string context)
    {
        Dictionary<string, dynamic> user = new Dictionary<string, dynamic>();

        user["username"] = username;
        user["message"] = context;

        db.Collection("Feedbacks").Document(username).SetAsync(user);
    }

    public async Task<double> GetGameVersion()
    {
        DocumentReference reference;
        reference = db.Collection("General").Document("Version");
        object version = (await reference.GetSnapshotAsync()).ToDictionary()["version"];

        return (double)version;
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