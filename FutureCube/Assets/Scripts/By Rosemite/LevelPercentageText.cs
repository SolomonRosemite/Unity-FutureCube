using UnityEngine.UI;
using UnityEngine;

public class LevelPercentageText : MonoBehaviour
{
    public static LevelPercentageText levelPercentageText;

    public Transform Player;
    public Text Location;

    public float Meters;

    [HideInInspector]
    public float TempVar;
    private string TempVarv2;

    private void Start()
    {
        levelPercentageText = this;
    }

    void Update()
    {
        TempVar = (Player.position.z / Meters) * 100;
        TempVarv2 = TempVar.ToString("0") + "%";


        if (TempVar < -0.8f)
        {
            Location.enabled = false;
        }

        if (TempVar > 0)
        {
            Location.text = TempVarv2;
        }

    }
}
