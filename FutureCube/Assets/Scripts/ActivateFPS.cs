using UnityEngine;

public class ActivateFPS : MonoBehaviour
{
    public ShowFPS ShowFpsScript;

    public void FPS(bool ShowFps)
    {
        if (ShowFps == true)
        {
            ShowFpsScript.enabled = true;
            ShowFpsScript.ShowFPSCounterFunc(true);
            ShowFpsScript.ShowFPSCounter = true;
            ShowFpsScript.Start();
        }
        else if (ShowFps == false)
        {
            ShowFpsScript.enabled = false;
            ShowFpsScript.ShowFPSCounterFunc(false);
            ShowFpsScript.ShowFPSCounter = false;
            ShowFpsScript.Start();
        }
    }

    public void GO(bool ShowFps)
    {
        GameObject.Find("Master").GetComponent<ActivateFPS>().FPS(ShowFps);
    }
}
