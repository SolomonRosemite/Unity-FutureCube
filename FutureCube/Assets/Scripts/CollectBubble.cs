using System.Collections;
using UnityEngine;

public class CollectBubble : MonoBehaviour
{
    public static CollectBubble ins;

    public static Rigidbody Player;
    public GameObject Bubble;
    public AudioSource BubbleSound;

    [HideInInspector]
    public bool BubbleActive;

    private GameObject BubbleShow;
    private MeshRenderer BubbleRender;

    void Start()
    {
        Bubble.SetActive(true);
        ins = this;

        Player = GameObject.FindGameObjectWithTag("PlayerPcOrPhone").GetComponent<Rigidbody>();
    }

    public IEnumerator BubbleCollected()
    {
        // Play Sound FX
        BubbleSound.Play(0);

        // Actives Bubble
        BubbleActive = true;

        // Shows Bubble
        BubbleShow = GameObject.FindGameObjectWithTag("BubbleTag");

        BubbleRender = BubbleShow.GetComponent<MeshRenderer>();

        BubbleRender.enabled = true;

        yield return null;
    }
}
