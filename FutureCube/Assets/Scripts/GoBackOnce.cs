using UnityEngine.UI;
using UnityEngine;

public class GoBackOnce : MonoBehaviour
{
    public Button button;

    void Update()
    {
        if (Input.GetButtonDown("Cancel"))
        {
            button.onClick.Invoke();
        }
    }
}
