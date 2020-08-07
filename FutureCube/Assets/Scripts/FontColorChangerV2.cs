using UnityEngine.UI;
using UnityEngine;

public class FontColorChangerV2 : MonoBehaviour
{
    public Button button;
    public float Speed;

    private float Timer;

    void Update()
    {
        Timer = 12 * (Time.deltaTime * Speed);
        if (Timer > 1)
        {
            float red = UnityEngine.Random.Range(0f, 1f);
            float green = UnityEngine.Random.Range(0f, 1f);
            float blue = UnityEngine.Random.Range(0f, 1f);

            ColorBlock colorVar = button.colors;
            colorVar.highlightedColor = new Color(red, green, blue);
            button.colors = colorVar;

            Timer = 0;
        }
    }
}
