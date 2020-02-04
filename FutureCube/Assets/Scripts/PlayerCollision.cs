using EZCameraShake;
using System.Collections;
using UnityEngine;

public class PlayerCollision : MonoBehaviour
{

    public static PlayerCollision ins;

    [HideInInspector]
    public bool backToMenu = false;

    private GameObject BubbleShow;
    private MeshRenderer BubbleRender;

    [HideInInspector]
    public bool TEMP;

    void OnCollisionEnter(Collision collisionInfo)
    {
        // Obstacle
        if (backToMenu is false)
        {
            // Check if the object collided with has a tag called "Obstacle".
            if (collisionInfo.collider.tag == "Obstacle")
            {
                try
                {
                    if (TEMP == false)
                    {
                        try { PlayerMovement.playerMovement.enabled = false; }
                        catch { PlayerMovePhone.playerMovement.enabled = false; }
                        FindObjectOfType<GameManager>().EndGame();
                        CameraShaker.Instance.ShakeOnce(4f, 4f, 1f, 1f);
                    }
                    // TEMP is our bubble
                    if (TEMP == true)
                    {
                        BubbleShow = GameObject.FindGameObjectWithTag("BubbleTag");

                        BubbleRender = BubbleShow.GetComponent<MeshRenderer>();

                        StartCoroutine(Set());

                        // Dosen't Show the Bubble anymore.
                        BubbleRender.enabled = false;
                    }
                }
                catch
                {
                    try { PlayerMovement.playerMovement.enabled = false; }
                    catch { PlayerMovePhone.playerMovement.enabled = false; }
                    //PlayerColorChanger.ins.Hit = true;
                    FindObjectOfType<GameManager>().EndGame();
                }
            }
        }
        try
        {
            if (collisionInfo.collider.name == HardPlayerController.ins.StartHardPlayerController)
            {
                print("Test");
            }
        }
        catch { }
    }

    void OnTriggerEnter(Collider trigger)
    {

        if (trigger.gameObject.tag == "Coin")
        {
            StartCoroutine(CollectCoin.ins.CoinCollected(200));
        }
        if (trigger.gameObject.tag == "LiteCoin")
        {
            StartCoroutine(CollectCoin.ins.CoinCollected(50));
        }
        if (trigger.gameObject.tag == "ReverseCoin")
        {
            StartCoroutine(CollectCoin.ins.CoinCollected(500));
        }
        if (trigger.gameObject.tag == "Bubble")
        {
            StartCoroutine(CollectBubble.ins.BubbleCollected());
            TEMP = true;
        }
        if (trigger.gameObject.tag == "Clock")
        {
            StartCoroutine(CollectClock.ins.ClockCollected());
        }
        if (trigger.gameObject.tag == "Random Box")
        {
            StartCoroutine(CollectRandomBox.ins.CollectedRandomBox());
        }
        if ((trigger.gameObject.name == "Reverse Mushroom"))
        {
            CollectBadMushroom.ins.SolvedTheProblem();
        }
        print("ghj");

        try
        {
            if (trigger.gameObject.name == HardPlayerController.ins.StartHardPlayerController)
            {
                StartCoroutine(HardPlayerController.ins.Freeze());
            }
        }
        catch { }
    }
    public void SetbackToMenuTrue()
    {
        backToMenu = true;
    }

    private IEnumerator Set()
    {
        yield return new WaitForSeconds(.4f);

        TEMP = false;

        CollectBubble.Player.freezeRotation = false;

        // Deactives the Bubble.
        CollectBubble.ins.BubbleActive = false;
    }
}
