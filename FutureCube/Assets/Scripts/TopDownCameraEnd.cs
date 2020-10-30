using System.Collections;
using UnityEngine;

public class TopDownCameraEnd : MonoBehaviour
{
    public static TopDownCameraEnd ins;
    [HideInInspector] public bool SetbackCamera = false;
    public Rigidbody Player;
    public GameObject TopPlatform;

    private bool firstCollision = true;
    
    void Start()
    {
        ins = this;
    }

    void OnCollisionEnter(Collision collisionInfo)
    {
        print(collisionInfo.collider.name);
        if (collisionInfo.collider.name == "Player")
            if (!firstCollision)
            {
                StartCoroutine(TopPlatformSetFalse());
            } else 
                firstCollision = false;

        if (collisionInfo.collider.name == "Player" && SetbackCamera)
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
