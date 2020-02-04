using UnityEngine.UI;
using UnityEngine;

public class ButtonManager : MonoBehaviour
{
    private RawImage RewardImage;

    void Start()
    {
        RewardImage = GameObject.Find("Store Reward").GetComponent<RawImage>();
        RewardImage.enabled = false;
    }

    void Update()
    {
        if (Mission.mission.Reward == true)
        {
            // image.color = ImageColor;
            SelectRandomV2.ins.TurnAllOff();
            RewardImage.enabled = true;
            Mission.mission.Reward = false;
        }
    }
}
