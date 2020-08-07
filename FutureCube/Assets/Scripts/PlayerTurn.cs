using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PlayerTurn : MonoBehaviour
{
    // Player
    public float R;
    public float G;
    public float B;

    Color color;

    public GameObject Player;
    public Renderer PlayerRenderer;

    // Floor
    public float RGround;
    public float GGround;
    public float BGround;

    Color colorGround;

    public GameObject Ground;
    public Renderer GroundRenderer;

    public Vector3 Offset;

    [Space]

    public GameObject[] ShowgameObjects;

    public GameObject[] HidegameObjects;

    private bool TurnNow = false;

    private void Start()
    {
        try
        {
            LevelPercentageText.levelPercentageText.TempVar = 0;
        }
        catch { }

        PlayerRenderer = Player.GetComponent<Renderer>();
        color = new Color(R / 255, G / 255, B / 255, 1f);

        GroundRenderer = Ground.GetComponent<Renderer>();
        colorGround = new Color(RGround / 255, GGround / 255, BGround / 255, 1f);

        for (int i = 0; i < HidegameObjects.Length; i++)
        {
            HidegameObjects[i].SetActive(true);
        }

        for (int i = 0; i < ShowgameObjects.Length; i++)
        {
            ShowgameObjects[i].SetActive(false);
        }

    }

    private void Update()
    {
        try
        {
            if (LevelPercentageText.levelPercentageText.TempVar >= 50 && TurnNow is false)
            {
                Reversed();
                if (PcOrPhoneDetect.ins.Platform == 1)
                {
                    PlayerMovement.playerMovement.ChangeMovement();
                }
                if (PcOrPhoneDetect.ins.Platform == 2)
                {
                    PlayerMovePhone.playerMovement.ChangeMovement();
                }
                TurnNow = true;
            }
        }
        catch { }
    }

    public void Reversed()
    {
        PlayerRenderer.material.SetColor("_Color", color);
        GroundRenderer.material.SetColor("_Color", colorGround);

        ChangeCamColor.ins.startReverse = true;
        FollowPlayer.ins.offset = Offset;

        for (int i = 0; i < HidegameObjects.Length; i++)
        {
            HidegameObjects[i].SetActive(false);
        }

        for (int i = 0; i < ShowgameObjects.Length; i++)
        {
            ShowgameObjects[i].SetActive(true);
        }
    }
}
