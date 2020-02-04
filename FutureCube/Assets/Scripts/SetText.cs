using UnityEngine.UI;
using UnityEngine;

public class SetText : MonoBehaviour
{
    public Text Version;

    void Start()
    {
        Version.text = LoadJson.Version.ToString();
    }

}
