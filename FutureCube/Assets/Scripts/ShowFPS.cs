using UnityEngine.UI;
using UnityEngine;

public class ShowFPS : MonoBehaviour
{
    public Text FPSText;
    public bool ShowFPSCounter = false;
    private float deltaTime;
    private float fps;

    public void Start()
    {
        if (ShowFPSCounter != true)
        {
            FPSText.gameObject.SetActive(false);
            enabled = false;
        }
        else if (ShowFPSCounter == true)
        {
            FPSText.gameObject.SetActive(true);
        }
    }

    void Update()
    {
        deltaTime += Time.deltaTime;
        deltaTime /= 2.0f;
        fps = 1.0f / deltaTime;
        FPSText.text = "FPS: " + fps.ToString("0");
    }

    public void ShowFPSCounterFunc(bool Yes)
    {
        if (Yes)
        {
            FPSText.gameObject.SetActive(true);
        }
        else
        {
            FPSText.gameObject.SetActive(false);
        }
    }
}
