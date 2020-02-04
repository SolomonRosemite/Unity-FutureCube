using UnityEngine.UI;
using UnityEngine;

public class ShowScore : MonoBehaviour
{
    public Text Score;

    void Start()
    {
        // If Score is negative Say "You have to PLay first to See your Score :D"
        if (LevelJson.levelJson.Level01 != -1)
        {
            int TotalScore = CalcTotalScore();
            Score.text = "Your Total Score: " + TotalScore.ToString("n0");
        }
        else
        {
            Score.text = "You have to Play first\nto See your Score :D";
        }
    }

    int CalcTotalScore()
    {
        return LevelJson.levelJson.Level01 + LevelJson.levelJson.Level02 + LevelJson.levelJson.Level03 + LevelJson.levelJson.Level04 + LevelJson.levelJson.Level05 + LevelJson.levelJson.Level06;
    }

}
