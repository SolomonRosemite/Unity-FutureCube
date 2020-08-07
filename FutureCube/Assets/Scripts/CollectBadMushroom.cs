using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectBadMushroom : MonoBehaviour
{
    public static CollectBadMushroom ins;
    public GameObject UI;
    public AudioSource audioSource;

    [Space]

    public CollectClock clock;
    public Fade UIFade;

    private GameObject Player;


    void Start()
    {
        ins = this;

        Player = GameObject.FindGameObjectWithTag("PlayerPcOrPhone");

        UI.SetActive(false);
    }

    public void SolvedTheProblem()
    {
        StartCoroutine(MiniPlayer());
        StartCoroutine(Reverse());
    }

    IEnumerator Reverse()
    {
        gameObject.GetComponent<MeshRenderer>().enabled = false;

        UI.SetActive(true);

        audioSource.Play();

        yield return new WaitForSeconds(.9f);

        StartCoroutine(ReversePlayerMovement());
    }

    IEnumerator ReversePlayerMovement()
    {
        clock.SetSidler(3);

        //UIFade.CallAnimatorBool("FadeOut", true);

        if (PcOrPhoneDetect.ins.Platform == 1)
        {
            PlayerMovement.playerMovement.ChangeMovementV2();
        }
        else if (PcOrPhoneDetect.ins.Platform == 2)
        {
            PlayerMovePhone.playerMovement.ChangeMovementV2();
        }

        yield return new WaitForSeconds(3);

        if (PcOrPhoneDetect.ins.Platform == 1)
        {
            PlayerMovement.playerMovement.ChangeMovementV2();
        }
        else if (PcOrPhoneDetect.ins.Platform == 2)
        {
            PlayerMovePhone.playerMovement.ChangeMovementV2();
        }
    }

    IEnumerator MiniPlayer()
    {
        yield return new WaitForSeconds(.3f);

        Player.transform.localScale = new Vector3(.7f, .7f, .7f);

        yield return new WaitForSeconds(.3f);

        Player.transform.localScale = new Vector3(.4f, .4f, .4f);

        yield return new WaitForSeconds(.3f);

        Player.transform.localScale = new Vector3(.1f, .1f, .1f);

        yield return new WaitForSeconds(3);

        Player.transform.localScale = new Vector3(1, 1, 1);
    }

}
