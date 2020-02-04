using System.Collections;
using UnityEngine;

public class Ramp : MonoBehaviour
{
    public GameObject[] Platforms;
    public GameObject[] Ceiling;

    private GameObject Player;

    [Space]

    public int Boost;

    [Space]

    public float Seconds;

    private void Start()
    {
        Player = GameObject.FindGameObjectWithTag("PlayerPcOrPhone");

        for (int i = 0; i < Platforms.Length; i++)
        {
            Platforms[i].SetActive(false);
        }
    }

    void OnCollisionEnter(Collision collisionInfo)
    {
        if (collisionInfo.collider.tag == "PlayerPcOrPhone")
        {
            HideCeiling();
            StartCoroutine(Timer());
            StartCoroutine(Booster());
        }
    }

    void OnCollisionExit(Collision collisionInfo)
    {
        if (collisionInfo.collider.tag == "PlayerPcOrPhone")
        {
            SetRotation();
        }
    }

    IEnumerator Booster()
    {

        if (PcOrPhoneDetect.ins.Platform == 1)
        {
            PlayerMovement.playerMovement.rb.constraints = RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationY | RigidbodyConstraints.FreezeRotationZ;
            PlayerMovement.playerMovement.rb.AddForce(0, 0, PlayerMovement.playerMovement.forwardForce * Time.deltaTime * Boost);
        }
        if (PcOrPhoneDetect.ins.Platform == 2)
        {
            PlayerMovePhone.playerMovement.rb.constraints = RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationY | RigidbodyConstraints.FreezeRotationZ;
            PlayerMovePhone.playerMovement.rb.AddForce(0, 0, PlayerMovePhone.playerMovement.forwardForce * Time.deltaTime * Boost);
        }

        yield return new WaitForSeconds(2);

        if (PcOrPhoneDetect.ins.Platform == 1)
        {
            PlayerMovement.playerMovement.rb.constraints = RigidbodyConstraints.None;
        }
        if (PcOrPhoneDetect.ins.Platform == 2)
        {
            PlayerMovePhone.playerMovement.rb.constraints = RigidbodyConstraints.None;
        }

    }

    IEnumerator Timer()
    {
        yield return new WaitForSeconds(Seconds);

        ShowPlatforms();
    }

    void SetRotation()
    {
        Player.transform.rotation = Quaternion.Euler(0, 0, 0);
    }

    void ShowPlatforms()
    {
        for (int i = 0; i < Platforms.Length; i++)
        {
            Platforms[i].SetActive(true);
        }
    }

    void HideCeiling()
    {
        for (int i = 0; i < Ceiling.Length; i++)
        {
            Ceiling[i].SetActive(false);
        }
    }

}
