using UnityEngine.UI;
using UnityEngine;

public class TapOrSpace : MonoBehaviour
{
    public Button button;

    void Update()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            button.onClick.Invoke();
        }
    }
}
