using UnityEngine;

public class ActivateFPS : MonoBehaviour
{
    public ShowFPS ShowFPSScript;

    public void FPS(bool ShowFPSbool)
    {
        if (ShowFPSbool == true)
        {
            ShowFPSScript.enabled = true;
            ShowFPSScript.ShowFPSCounterFunc(true);
            ShowFPSScript.ShowFPSCounter = true;
            ShowFPSScript.Start();
        }
        else if (ShowFPSbool == false)
        {
            ShowFPSScript.enabled = false;
            ShowFPSScript.ShowFPSCounterFunc(false);
            ShowFPSScript.ShowFPSCounter = false;
            ShowFPSScript.Start();
        }
    }

    public void GO(bool ShowFPSbool)
    {
        GameObject.Find("Master").GetComponent<ActivateFPS>().FPS(ShowFPSbool);
    }
}
