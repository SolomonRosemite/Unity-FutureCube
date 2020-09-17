using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class PlayerSpeed : MonoBehaviour
{
    public GameObject player;
    public Text text;

    private PlayerMovement playerMovement;
    private PlayerMovePhone playerMovePhone;


    void Start()
    {
        if (PcOrPhoneDetect.ins.Platform == 1)
        {
            playerMovement = player.GetComponent<PlayerMovement>();
        }
        else
        {
            playerMovePhone = player.GetComponent<PlayerMovePhone>();
        }
    }

    void Update() => text.text = $"Speed: {GetPlayerSpeed().ToString("0")}";

    private float GetPlayerSpeed()
    {
        if (PcOrPhoneDetect.ins.Platform == 1)
            return playerMovement.forwardForce / 10;
        return playerMovePhone.forwardForce / 10;
    }
}
