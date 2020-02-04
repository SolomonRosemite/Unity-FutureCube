using UnityEngine;

public class SetUI : MonoBehaviour
{
    private void Start()
    {
        if (SetAspectRatio.setAspectRatio.RightAspectRatio == false)
        {
            try { GameObject.Find("Tap To Retry text").GetComponent<RectTransform>().localPosition = new Vector3(-30, -500); } catch { }
        }
        else
        {
            enabled = false;
        }
    }

}
