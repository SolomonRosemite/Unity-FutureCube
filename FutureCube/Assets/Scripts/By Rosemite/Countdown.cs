using System.Collections;
using UnityEngine.UI;
using UnityEngine;

public class Countdown : MonoBehaviour
{
    public static Countdown ins;
    public GameObject Panel;
    public GameObject PanelV2;
    public GameObject PanelV3;
    public GameObject PanelV4;
    public Rigidbody Rb;

    [Space]

    public float countdown = 5f;
    public float currentTime;

    public Text countdownText;

    void Start()
    {
        ins = this;

        Rb.useGravity = false;
        Panel.gameObject.SetActive(true);
        PanelV2.gameObject.SetActive(true);
        PanelV3.gameObject.SetActive(false);
        try { PanelV4.gameObject.SetActive(true); } catch { }
        GameObject.FindGameObjectWithTag("PlayerPcOrPhone").GetComponent<PointSystem>().enabled = false;
        currentTime = countdown;
    }

    void Update()
    {
        currentTime -= 1 * Time.deltaTime;
        countdownText.text = currentTime.ToString("0");

        if (currentTime < -0.5)
        {
            Panel.gameObject.SetActive(false);
            PanelV2.gameObject.SetActive(false);
            PanelV3.gameObject.SetActive(true);
            try { PanelV4.gameObject.SetActive(false); } catch { }
            GameObject.FindGameObjectWithTag("PlayerPcOrPhone").GetComponent<PointSystem>().enabled = true;

            Rb.useGravity = true;
        }
    }

    public void SetUIOrder()
    {
        gameObject.GetComponent<Canvas>().sortingOrder = 1002;
    }
}
