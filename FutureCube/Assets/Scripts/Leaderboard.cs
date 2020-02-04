using UnityEngine.UI;
using UnityEngine;

public class Leaderboard : MonoBehaviour
{
    public Text PlayerOfflineText;

    public bool PlayerOnline = false;

    void Start()
    {
        PlayerOfflineText.enabled = true;

        if (Application.internetReachability != NetworkReachability.NotReachable)
        {
            PlayerOfflineText.text = "This Function is not Done Yet.";
            //PlayerOnline = true;
        }
        else
        {
            PlayerOfflineText.text = "Sorry. You are Offline.";
        }

    }
}
