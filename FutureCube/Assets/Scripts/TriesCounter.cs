using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine;

public class TriesCounter : MonoBehaviour
{
    public static TriesCounter triesCounter;
    private Text Counter;

    [HideInInspector]
    public int Tries = 0;

    private void Start()
    {
        triesCounter = this;
    }

    public void Lost()
    {
        Tries += 1;
    }

    public void ResetCounter()
    {
        Tries = 0;
    }
}
