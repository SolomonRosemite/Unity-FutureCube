using EZCameraShake;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    public static PlayerMovement playerMovement;

    public Rigidbody rb;

    public float forwardForce;  // Variable that determines the forward force
    public float sidewaysForce;  // Variable that determines the sideways force

    public bool backToMenu = false;
    public bool OnGround = false;

    [Space]

    public bool noLimitMode = false;
    public float forwardTempo = 5000f;

    [HideInInspector]
    public bool GameOver = false;

    private void Start()
    {
        playerMovement = this;

        if (noLimitMode == true)
            forwardForce = forwardTempo;
    }

    void OnCollisionEnter(Collision collisionInfo)
    {
        if (collisionInfo.collider.tag == "Ground")
        {
            OnGround = true;
        }
    }

    void FixedUpdate()
    {
        if (noLimitMode)
            forwardForce += .5f;

        if (OnGround == true)
        {
            // Add a forward force
            rb.AddForce(0, 0, forwardForce * Time.deltaTime);

            if (Input.GetAxisRaw("Horizontal") > 0)
            {
                // Add a force to the right
                rb.AddForce(sidewaysForce * Time.deltaTime, 0, 0, ForceMode.VelocityChange);
            }

            if (Input.GetAxisRaw("Horizontal") < 0)
            {
                // Add a force to the left
                rb.AddForce(-sidewaysForce * Time.deltaTime, 0, 0, ForceMode.VelocityChange);
            }

            if (rb.position.y < -3f)
            {
                if (backToMenu is false)
                {
                    Mission.mission.PlayerOutOfMapFunc();
                    FindObjectOfType<GameManager>().EndGame();
                }
            }
        }
    }

    public void ChangeMovement()
    {
        forwardForce = -forwardForce;
    }

    public void ChangeMovementV2()
    {
        sidewaysForce = -sidewaysForce;
    }

    public void SetbackToMenuTrue()
    {
        backToMenu = true;
    }

    public void CoinBoost(float Boost, bool Shake)
    {
        if (Shake is true)
        {
            CameraShaker.Instance.ShakeOnce(4f, 4f, 1f, 1f);
        }
        rb.AddForce(0, 0, forwardForce * Time.deltaTime * Boost);
    }

}
