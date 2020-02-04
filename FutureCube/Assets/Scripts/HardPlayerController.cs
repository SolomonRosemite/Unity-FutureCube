using System.Collections;
using UnityEngine;

public class HardPlayerController : MonoBehaviour
{
    public static HardPlayerController ins;

    [HideInInspector]
    public string StartHardPlayerController;

    [Space]

    public float Seconds;
    private Rigidbody Player;

    void Start()
    {
        ins = this;

        StartHardPlayerController = this.gameObject.name;

        Player = GameObject.FindGameObjectWithTag("PlayerPcOrPhone").GetComponent<Rigidbody>();

    }

    public IEnumerator Freeze()
    {
        if (PcOrPhoneDetect.ins.Platform == 1)
        {
            GameObject.FindGameObjectWithTag("PlayerPcOrPhone").GetComponent<PlayerMovement>().OnGround = false;
            Player.constraints = RigidbodyConstraints.FreezePositionX;
        }
        else if (PcOrPhoneDetect.ins.Platform == 2)
        {
            GameObject.FindGameObjectWithTag("PlayerPcOrPhone").GetComponent<PlayerMovePhone>().OnGround = false;
            Player.constraints = RigidbodyConstraints.FreezePositionX;
        }

        yield return new WaitForSeconds(Seconds);

        if (PcOrPhoneDetect.ins.Platform == 1)
        {
            GameObject.FindGameObjectWithTag("PlayerPcOrPhone").GetComponent<PlayerMovement>().OnGround = true;
            Player.constraints = RigidbodyConstraints.None;
        }
        else if (PcOrPhoneDetect.ins.Platform == 2)
        {
            GameObject.FindGameObjectWithTag("PlayerPcOrPhone").GetComponent<PlayerMovePhone>().OnGround = true;
            Player.constraints = RigidbodyConstraints.None;
        }
        enabled = false;
    }

}
