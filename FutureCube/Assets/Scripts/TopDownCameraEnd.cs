using System.Collections;
using UnityEngine;

public class TopDownCameraEnd : MonoBehaviour
{
    public static TopDownCameraEnd ins;
    [HideInInspector] public bool SetbackCamera = false;
    public Rigidbody Player;
    public GameObject TopPlatform;

    void Start()
    {
        ins = this;
    }

    void OnCollisionEnter(Collision collisionInfo)
    {
        if (collisionInfo.collider.name == "Player")
        {
            StartCoroutine(TopPlatformSetFalse());
        }

        if (collisionInfo.collider.name == "Player" && SetbackCamera == true)
        {
            TopDownCamera.ins.FixCamera();
            StartCoroutine(Timer());
        }
    }

    IEnumerator Timer()
    {
        Player.transform.rotation = Quaternion.Euler(0, 0, 0);

        yield return new WaitForSeconds(1);

        Player.transform.rotation = Quaternion.Euler(0, 0, 0);

        enabled = false;
    }

    IEnumerator TopPlatformSetFalse()
    {
        yield return new WaitForSeconds(1);

        TopPlatform.SetActive(false);
    }
}
