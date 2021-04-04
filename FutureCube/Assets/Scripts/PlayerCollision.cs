using System.Collections;
using EZCameraShake;
using UnityEngine;
using System;

public class PlayerCollision : MonoBehaviour
{
    public bool immortal = false;
    public bool noLimitMode = false;

    public GameObject lastHeart;

    private bool timeout = false;

    [HideInInspector]
    public bool backToMenu = false;

    private GameObject BubbleShow;
    private MeshRenderer BubbleRender;

    [HideInInspector]
    public bool TEMP;

    // Events
    public event EventHandler<OnHitObstacleEventArgs> onHitObstacle;
    public class OnHitObstacleEventArgs : EventArgs
    {
        public int heartsRemaining;
    }

    private int heartsRemaining = 2;

    void OnCollisionEnter(Collision collisionInfo)
    {
        if (backToMenu == false)
        {
            // Check if the object collided with has a tag called "Obstacle".
            if (collisionInfo.collider.tag == "Obstacle")
            {
                if (immortal)
                {
                    return;
                }
                try
                {
                    if (TEMP == false) { EndGame(); }
                    else
                    {
                        BubbleShow = GameObject.FindGameObjectWithTag("BubbleTag");

                        BubbleRender = BubbleShow.GetComponent<MeshRenderer>();

                        StartCoroutine(Set());

                        // Doesn't Show the Bubble anymore.
                        BubbleRender.enabled = false;
                    }
                }
                catch { EndGame(); }
            }
        }
    }

    void EndGame()
    {
        if (noLimitMode && heartsRemaining != 0)
        {
            if (timeout == false)
            {
                timeout = true;
                heartsRemaining--;

                EmitHitObstacle();
                StartCoroutine(SetTimeOut(.5f));
            }
            return;
        }

        lastHeart.SetActive(false);

        try { PlayerMovement.playerMovement.enabled = false; }
        catch { PlayerMovePhone.playerMovement.enabled = false; }
        FindObjectOfType<GameManager>().EndGame();
        CameraShaker.Instance.ShakeOnce(4f, 4f, 1f, 1f);
    }

    IEnumerator SetTimeOut(float seconds)
    {
        yield return new WaitForSeconds(seconds);
        timeout = false;
    }

    private void EmitHitObstacle() => onHitObstacle?.Invoke(this, new OnHitObstacleEventArgs { heartsRemaining = heartsRemaining });

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

        // Deactivates the Bubble.
        CollectBubble.ins.BubbleActive = false;
    }
}
