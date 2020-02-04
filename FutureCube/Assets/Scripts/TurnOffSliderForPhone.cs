using UnityEngine;

public class TurnOffSliderForPhone : MonoBehaviour
{
    public GameObject SliderGameobject;

    void Start()
    {
        if (PcOrPhoneDetect.ins.Platform == 2)
        {
            SliderGameobject.SetActive(false);
        }
    }
}
