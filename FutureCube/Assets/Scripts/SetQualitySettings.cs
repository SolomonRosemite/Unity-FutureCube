using UnityEngine.UI;
using UnityEngine;

public class SetQualitySettings : MonoBehaviour
{
    public Slider slider;
    public Text QualityText;

    private void Start()
    {
        slider.value = LoadJson.loadJson.SetQuality;

        if (slider.value == 0)
        {
            QualityText.text = "Quality: Lowest";
        }
        else if (slider.value == 1)
        {
            QualityText.text = "Quality: Fast";
        }
        else if (slider.value == 2)
        {
            QualityText.text = "Quality: Simple";
        }
        else if (slider.value == 3)
        {
            QualityText.text = "Quality: Good";
        }
        else if (slider.value == 4)
        {
            QualityText.text = "Quality: Beautiful";
        }
        else if (slider.value == 5)
        {
            QualityText.text = "Quality: Fantastic";
        }
        else
        {
            QualityText.text = "If u see this its not good";
        }

    }


    public void SetQuality()
    {
        float SliderInput = slider.value;

        if (SliderInput == 0)
        {
            QualitySettings.SetQualityLevel(0);
            LoadJson.loadJson.JsonEditQuality(SliderInput);
            QualityText.text = "Quality: Lowest";
        }
        else if (SliderInput == 1)
        {
            QualitySettings.SetQualityLevel(1);
            LoadJson.loadJson.JsonEditQuality(SliderInput);
            QualityText.text = "Quality: Fast";
        }
        else if (SliderInput == 2)
        {
            QualitySettings.SetQualityLevel(2);
            LoadJson.loadJson.JsonEditQuality(SliderInput);
            QualityText.text = "Quality: Simple";
        }
        else if (SliderInput == 3)
        {
            QualitySettings.SetQualityLevel(3);
            LoadJson.loadJson.JsonEditQuality(SliderInput);
            QualityText.text = "Quality: Good";
        }
        else if (SliderInput == 4)
        {
            QualitySettings.SetQualityLevel(4);
            LoadJson.loadJson.JsonEditQuality(SliderInput);
            QualityText.text = "Quality: Beautiful";
        }
        else if (SliderInput == 5)
        {
            QualitySettings.SetQualityLevel(5);
            LoadJson.loadJson.JsonEditQuality(SliderInput);
            QualityText.text = "Quality: Fantastic";
        }
        else
        {
            print("What have u done Solomon");
        }
    }
}
