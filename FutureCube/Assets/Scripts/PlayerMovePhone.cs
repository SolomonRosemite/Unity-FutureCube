using EZCameraShake;
using UnityEngine;

public class PlayerMovePhone : MonoBehaviour
{
    public static PlayerMovePhone playerMovement;

    // This is a reference to the Rigidbody component called "rb"
    public Rigidbody rb;

    public float forwardForce = 2000f;  // Variable that determines the forward force
    public float sidewaysForce = 500f;  // Variable that determines the sideways force

    public bool backToMenu = false;
    public bool OnGround = false;

    [Space]

    public bool noLimitMode = false;
    public float forwardTempo = 5000f;

    [HideInInspector]
    public bool GameOver = false;
    private float ScreenWidth;

    void OnCollisionEnter(Collision collisionInfo)
    {
        if (collisionInfo.collider.tag == "Ground")
        {
            OnGround = true;
        }
    }

    void Start()
    {
        ScreenWidth = Screen.width;
        playerMovement = this;

        if (noLimitMode == true)
            forwardForce = forwardTempo;
    }

    void FixedUpdate()
    {
        if (noLimitMode)
            forwardForce += .5f;

        if (OnGround == true)
        {
            // Add a forward force
            rb.AddForce(0, 0, forwardForce * Time.deltaTime);

            int i = 0;
            if (i < Input.touchCount)
            {
                if (Input.GetTouch(i).position.x > ScreenWidth / 2)
                {
                    //move right
                    rb.AddForce(sidewaysForce * Time.deltaTime, 0, 0);
                }
                if (Input.GetTouch(i).position.x < ScreenWidth / 2)
                {
                    //move left
                    rb.AddForce(-sidewaysForce * Time.deltaTime, 0, 0);
                }
            }

            if (rb.position.y < -3f)
            {
                Mission.mission.PlayerOutOfMapFunc();
                FindObjectOfType<GameManager>().EndGame();
            }
        }

    }

    public void SetbackToMenuTrue()
    {
        backToMenu = true;
    }

    public void ChangeMovement()
    {
        forwardForce = -forwardForce;
    }

    public void ChangeMovementV2()
    {
        sidewaysForce = -sidewaysForce;
    }

    public void CoinBoost(float Boost)
    {
        CameraShaker.Instance.ShakeOnce(4f, 4f, 1f, 1f);
        rb.AddForce(0, 0, forwardForce * Time.deltaTime * Boost);
    }
}
