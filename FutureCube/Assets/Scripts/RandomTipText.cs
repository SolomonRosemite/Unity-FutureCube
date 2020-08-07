using UnityEngine;
using UnityEngine.UI;

public class RandomTipText : MonoBehaviour
{
    public static RandomTipText randomTipText;

    public Text TipText;

    public void Update()
    {
        TipText.text = PauseV2.pauseV2.tipTextStr;
    }
}
