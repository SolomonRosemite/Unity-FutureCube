using UnityEngine.UI;
using UnityEngine;

public class Leaderboard : MonoBehaviour
{
    public Text PlayerOfflineText;

    void Start()
    {
        PlayerOfflineText.enabled = true;

        if (Application.internetReachability != NetworkReachability.NotReachable)
        {
            PlayerOfflineText.text = "This Function is not Done Yet.";
        }
        else
        {
            PlayerOfflineText.text = "Sorry. You are Offline.";
        }
    }
}
