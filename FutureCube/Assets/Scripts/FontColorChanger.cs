using UnityEngine.UI;
using UnityEngine;

public class FontColorChanger : MonoBehaviour
{
    public Text text;
    public float Speed = 4.7f;

    private float Timer;

    // Update is called once per frame
    void Update()
    {
        Timer = 12 * (Time.deltaTime * Speed);
        if (Timer > 1)
        {
            float red = UnityEngine.Random.Range(0f, 1f);
            float green = UnityEngine.Random.Range(0f, 1f);
            float blue = UnityEngine.Random.Range(0f, 1f);

            text.color = new Color(red, green, blue);

            Timer = 0;
        }
    }
}
