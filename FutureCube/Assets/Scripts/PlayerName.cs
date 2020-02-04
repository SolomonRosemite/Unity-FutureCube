using UnityEngine.UI;
using UnityEngine;

public class PlayerName : MonoBehaviour
{
    public InputField Playername;

    private void Start()
    {
        try { Playername.text = LoadJson.loadJson.PlayerName; } catch { }
    }

    public void SetName()
    {
        LoadJson.loadJson.JsonEditPlayerName(Playername.text);
    }

}
