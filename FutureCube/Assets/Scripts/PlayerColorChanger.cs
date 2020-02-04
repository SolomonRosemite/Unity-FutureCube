using UnityEngine;

public class PlayerColorChanger : MonoBehaviour
{
    public static PlayerColorChanger ins;

    [HideInInspector]
    public bool Hit = false;

    public GameObject Player;
    public Transform TransformPlayer;
    public Renderer PlayerRenderer;
    public float Speed;

    private float Timer;

    private void Start()
    {
        PlayerRenderer = Player.GetComponent<Renderer>();
        ins = this;
    }

    void Update()
    {
        if (Hit == true)
        {
            Timer = 12 * (Time.deltaTime * Speed);
            if (Timer > 1)
            {
                PlayerRenderer.material.SetColor("_Color", Random.ColorHSV());

                Timer = 0;
            }

            TransformPlayer.localScale -= new Vector3(0.01f, 0.01f, 0.01f);
        }

    }
}
