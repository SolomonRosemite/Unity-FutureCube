using System.Collections;
using UnityEngine.UI;
using UnityEngine;

public class CollectRandomBox : MonoBehaviour
{
    public static CollectRandomBox ins;

    public CollectCoin coin;
    public CollectBubble bubble;
    public CollectClock clock;

    [Space]

    public Animator animator;

    public Fade UIFade;

    [Space]

    public GameObject[] Items;

    public GameObject UI;

    public Text ItemName;

    [Space]

    public AudioSource audioSource;
    public AudioClip[] AudioClips;

    [Space]
    public Color CoinTextColor = new Color(0.2F, 0.3F, 0.4F, 0.5F);
    public Color BubbleTextColor = new Color(0.2F, 0.3F, 0.4F, 0.5F);
    public Color ClockTextColor = new Color(0.2F, 0.3F, 0.4F, 0.5F);
    public Color UnluckyTextColor = new Color(0.2F, 0.3F, 0.4F, 0.5F);

    private bool ItemsReady;
    private float time;
    private int index;
    private MeshRenderer mesh;
    void Start()
    {
        ins = this;

        animator.SetBool("PlayAni", false);

        // Get index = Item 
        index = Random.Range(0, Items.Length);

        // Set UI Inactive
        UI.SetActive(false);

        // Get Mesh (Box)
        mesh = GameObject.FindGameObjectWithTag("Random Box").GetComponent<MeshRenderer>();
    }

    public IEnumerator CollectedRandomBox()
    {
        // Hide Box
        mesh.enabled = false;

        // Show UI and play Ani.
        UI.SetActive(true);

        // Play Sound
        audioSource.clip = AudioClips[0];
        audioSource.Play();

        // (We have "Unluky 2 times to Higher the probability :D")
        switch (index)
        {
            case 0:
                // Give Coin Boost Item
                ItemName.text = "Coin Boost";
                ItemName.color = CoinTextColor;
                time = 1;
                break;
            case 1:
                // Give Bubble Item
                ItemName.text = "Bubble";
                ItemName.color = BubbleTextColor;
                time = 1;
                break;
            case 2:
                // Give Slowdown Item
                ItemName.text = ">cLoCK<";
                ItemName.color = ClockTextColor;
                time = 1;
                break;
            case 3:
                // Give Slowdown Item
                ItemName.text = ">cLoCK<";
                ItemName.color = ClockTextColor;
                time = 1;
                break;
            case 4:
                // Reverse Playerinput
                ItemName.text = "Reverse";
                ItemName.color = UnluckyTextColor;
                time = .5f;
                break;
        }

        yield return new WaitForSeconds(time);

        // Play animator
        animator.SetBool("PlayAni", true);

        // If Unlucky
        if (index == 4)
        {
            StartCoroutine(Reverse());
        }

        // If index is 3 its Clock
        if (index == 3)
        {
            Items[2].SetActive(true);
        }
        else
        {
            try { Items[index].SetActive(true); } catch { }
        }


        // Get Item Ready to use!
        ItemsReady = true;

        // Play Sound
        audioSource.clip = AudioClips[1];
        audioSource.Play();
    }

    void Update()
    {
        if (ItemsReady && PcOrPhoneDetect.ins.Platform == 1)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                UseItem();
                ItemsReady = false;
                UIFade.CallAnimatorBool("FadeOut", true);
            }
        }

        if (PauseV2.pauseV2.OverGame == true)
        {
            ItemsReady = false;

            // Prevents Error when tring to fade while ui is inactive.
            try { UIFade.CallAnimatorBool("FadeOut", true); } catch { }
        }
    }

    // For the Phone Gets called by a Button
    public void UseItemInputPhone()
    {
        if (ItemsReady == true)
        {
            UseItem();

            UIFade.CallAnimatorBool("FadeOut", true);
            ItemsReady = false;

        }
    }

    void UseItem()
    {
        switch (index)
        {

            case 0:
                StartCoroutine(coin.CoinCollected(0));
                break;
            case 1:
                GameObject.FindGameObjectWithTag("PlayerPcOrPhone").GetComponent<PlayerCollision>().TEMP = true;
                StartCoroutine(bubble.BubbleCollected());
                break;
            case 2:
                StartCoroutine(clock.ClockCollected());
                break;
            case 3:
                StartCoroutine(clock.ClockCollected());
                break;
        }
        UIFade.CallAnimatorBool("FadeOut", true);
    }

    IEnumerator Reverse()
    {
        clock.SetSilder(2.5f);

        UIFade.CallAnimatorBool("FadeOut", true);

        if (PcOrPhoneDetect.ins.Platform == 1)
        {
            PlayerMovement.playerMovement.ChangeMovementV2();
        }
        else if (PcOrPhoneDetect.ins.Platform == 2)
        {
            PlayerMovePhone.playerMovement.ChangeMovementV2();
        }

        yield return new WaitForSeconds(2.5f);

        if (PcOrPhoneDetect.ins.Platform == 1)
        {
            PlayerMovement.playerMovement.ChangeMovementV2();
        }
        else if (PcOrPhoneDetect.ins.Platform == 2)
        {
            PlayerMovePhone.playerMovement.ChangeMovementV2();
        }
    }
}
