using UnityEngine;

public class MissionRewardAni : MonoBehaviour
{
    public static MissionRewardAni ins;
    public GameObject[] achievementGameObjects;

    void Start()
    {
        ins = this;
    }

    public void GetReward(string Mission)
    {
        print(Mission);
        switch (Mission)
        {
            case "FirstLevelComplete":
                achievementGameObjects[0].SetActive(true);
                break;
            case "FirstTry":
                achievementGameObjects[1].SetActive(true);
                break;
            case "PlayerOutOfMap":
                achievementGameObjects[2].SetActive(true);
                break;
            case "SeasionOneCompleted":
                achievementGameObjects[3].SetActive(true);
                break;
            default:
                break;
        }
    }
}
