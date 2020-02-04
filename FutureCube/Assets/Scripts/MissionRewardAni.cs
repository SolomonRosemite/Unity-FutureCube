using UnityEngine;

public class MissionRewardAni : MonoBehaviour
{
    public static MissionRewardAni ins;
    public GameObject[] AchievementGameObjects;

    void Start()
    {
        ins = this;
    }

    public void GetReward(string Mission)
    {
        switch (Mission)
        {
            case "FirstLevelComplete":
                AchievementGameObjects[0].SetActive(true);
                break;
            case "FirstTry":
                AchievementGameObjects[1].SetActive(true);
                break;
            case "PlayerOutOfMap":
                AchievementGameObjects[2].SetActive(true);
                break;
            case "SeasionOneCompleted":
                AchievementGameObjects[3].SetActive(true);
                break;
            default:
                break;
        }
    }
}
