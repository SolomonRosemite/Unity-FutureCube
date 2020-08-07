using System.Collections;
using UnityEngine.UI;
using UnityEngine;

public class SliderForClock : MonoBehaviour
{
    public static SliderForClock ins;
    public Slider slider;
    private float time;

    void Awake()
    {
        ins = this;
    }

    public void SetDuration(float Duration)
    {
        slider.maxValue = Duration;
        slider.value = Duration;
        time = Duration;
    }

    public void StartSlider()
    {
        StartCoroutine(Slide());
    }

    public IEnumerator Slide()
    {
        while (time > 0)
        {
            time -= Time.deltaTime;
            slider.value = time;
            yield return null;
        }
        this.gameObject.SetActive(false);
    }
}
