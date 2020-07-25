using System.Collections;
using EZCameraShake;
using UnityEngine;

public class TopDownCamera : MonoBehaviour
{
    public static TopDownCamera ins;

    // Camera
    private Camera TopDownCam;
    private byte Turn = 0;

    // FollowPlayer
    public FollowPlayer followPlayer;
    private Vector3 SavedOffset;

    // EZCameraShake
    public CameraShaker cameraShaker;

    public bool TopDownCamOnlyOnce = true;

    void Start()
    {
        ins = this;

        TopDownCam = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
    }

    void OnCollisionEnter(Collision collisionInfo)
    {
        if (collisionInfo.collider.tag == "PlayerPcOrPhone")
        {
            SetCamera();
        }
    }

    void Update()
    {
        // Turn Player
        if (Turn == 1 && TopDownCamOnlyOnce == true)
        {
            TopDownCam.gameObject.transform.Rotate(Vector3.right, 10.0f * Time.deltaTime * 15f);

            if (TopDownCam.gameObject.transform.rotation.x >= 0.70)
            {
                Turn = 0;
                TopDownCamOnlyOnce = false;
            }
        }

        if (Turn == 2)
        {
            TopDownCam.gameObject.transform.Rotate(Vector3.left, 10.0f * Time.deltaTime * 20f);

            if (TopDownCam.gameObject.transform.rotation.x <= 0)
            {
                Turn = 0;
            }
        }
    }

    void SetCamera()
    {
        TopDownCameraEnd.ins.SetbackCamera = true;

        // EZCameraShake
        cameraShaker.enabled = false;

        Turn = 1;
        TopDownCam.fieldOfView = 120;

        // FollowPlayer
        SavedOffset = followPlayer.offset;
        followPlayer.offset = new Vector3(0, 15, 15);

    }

    public void FixCamera()
    {
        TopDownCameraEnd.ins.SetbackCamera = false;

        // FollowPlayer
        followPlayer.offset = SavedOffset;

        // Reset Camera Rotation
        TopDownCam.fieldOfView = 74;
        Turn = 2;

        // EZCameraShake
        StartCoroutine(EnableShaker());
    }

    IEnumerator EnableShaker()
    {
        yield return new WaitForSeconds(.6f);

        cameraShaker.enabled = true;
    }
}
