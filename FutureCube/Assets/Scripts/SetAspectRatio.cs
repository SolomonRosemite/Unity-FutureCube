using UnityEngine;

public class SetAspectRatio : MonoBehaviour
{
    public static SetAspectRatio setAspectRatio;

    [HideInInspector]
    public bool RightAspectRatio;

    void Start()
    {
        setAspectRatio = this;

        if (Screen.width / Screen.height == 1.77777777778f)
        {
            // Keep aspect ratio
            RightAspectRatio = true;
        }
        if (Screen.width / Screen.height > 1.77777777778f)
        {
            // Switch posi buttons (Ham. menu)
            RightAspectRatio = false;
        }
        else
        {
            RightAspectRatio = true;
        }
    }

}
