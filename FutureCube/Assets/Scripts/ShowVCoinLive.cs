using UnityEngine.UI;
using UnityEngine;

public class ShowVCoinLive : MonoBehaviour
{
    // Minimum and maximum values for the transition.
    float minimum = 0.0f;

    // Time taken for the transition.
    float duration = 2f;

    float startTime;

    public int Mode = 0;
    private float nextActionTime = 0.0f;
    public float period = .5f;

    public Text V_Coins;

    private int VCoins;

    void Awake()
    {
        V_Coins = gameObject.GetComponent<Text>();

        // Make a note of the time the script started.
        startTime = Time.time;
        minimum = LoadJson.loadJson.V_Coins;
    }

    void Update()
    {
        if (Time.time > nextActionTime)
        {
            nextActionTime += period;

            if (Mode == 1)
            {
                V_Coins.text = "V-Coins: " + LoadJson.loadJson.V_Coins.ToString("n0") + " V";
            }
            else if (Mode == 2)
            {
                // Calculate the fraction of the total duration that has passed.
                float t = (Time.time - startTime) / duration;
                V_Coins.text = "V-Coins: " + Mathf.SmoothStep(minimum, LoadJson.loadJson.V_Coins, t).ToString("n0") + " V";
            }
            else if (Mode == 3)
            {
                Mathf.Lerp(minimum, LoadJson.loadJson.V_Coins, 20);
            }
        }
    }
}
