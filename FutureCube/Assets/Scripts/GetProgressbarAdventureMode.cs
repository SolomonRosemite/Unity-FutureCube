using UnityEngine.UI;
using System.Collections;
using UnityEngine;

public class GetProgressbarAdventureMode : MonoBehaviour
{
    public Slider slider;
    public Text Percentage;

    void Start()
    {
        StartCoroutine(Set());
    }

    IEnumerator Set()
    {
        yield return new WaitForSeconds(0);

        if (LoadJson.loadJson.LevelComplete >= 6)
        {
            slider.value = LoadJson.loadJson.LevelComplete - 4;

            float temp = (LoadJson.loadJson.LevelComplete - 4);

            Percentage.text = ((temp / 12) * 100).ToString("0") + "%";
        }
        else
        {
            slider.value = LoadJson.loadJson.LevelComplete;

            float temp = (LoadJson.loadJson.LevelComplete);

            Percentage.text = ((temp / 12) * 100).ToString("0") + "%";
        }

    }
}
