using UnityEngine.UI;
using UnityEngine;

public class UsernameSystem : MonoBehaviour
{
    public InputField Playername;
    public Text Warning;
    public Text note;
    public Button Continue;
    public Button Back;

    [Space]

    public GameObject ContinueGameObject;
    public GameObject BackGameObject;

    private int x;

    void Start()
    {
        Playername.text = LoadJson.loadJson.PlayerName;
    }

    public void SetUsername()
    {
        x++;

        if (x > 1)
        {
            MoveButton();
            if (LoadJson.loadJson.PlayerName.ToLower() == "player")
            {
                Continue.interactable = false;
                Continue.image.color = Continue.colors.disabledColor;

                // Checks for Internet Connection
                if (Application.internetReachability == NetworkReachability.NotReachable)
                {
                    note.text = "";
                    Warning.text = "You can't change your Username\nwhile being offline.";
                    Warning.color = Color.red;
                }
                // If Playername is to long
                else if (Playername.text.Length >= 12)
                {
                    note.text = "";
                    Warning.text = "Username can't be to Long.";
                    Warning.color = Color.red;
                }
                // If Playername is to Short
                else if (Playername.text.Length < 3)
                {
                    note.text = "";
                    Warning.text = "Username can't be to Short.";
                    Warning.color = Color.red;
                }
                // If Playername is inappropriate 
                else if (Playername.text.Contains("Player") || Playername.text.Contains(@"""") || Playername.text.Contains("}") || Playername.text.Contains("{") || Playername.text.Contains("Ass") || Playername.text.Contains("fuck") || Playername.text.Contains("fick") || Playername.text.Contains("nigger"))
                {
                    note.text = "";
                    Warning.text = "You can't change your Username\nto " + Playername.text + ".";
                    Warning.color = Color.red;
                }
                // If Playername is already used.
                else if (UsernameUsed() == true)
                {
                    note.text = "";
                    Warning.text = "Username is already Used.";
                    Warning.color = Color.red;

                    if (Playername.text.ToLower() == LoadJson.loadJson.PlayerName.ToLower())
                    {
                        Continue.image.color = Continue.colors.normalColor;
                        Continue.interactable = true;
                    }
                }
                else if (Application.internetReachability == NetworkReachability.NotReachable)
                {
                    Warning.text = "You Can't change your\nwhile being Offline";
                    Warning.color = Color.red;
                }
                // Else Username is Okay
                else
                {
                    Continue.image.color = Continue.colors.normalColor;
                    Continue.interactable = true;

                    Warning.text = "Click \"Done\" to Save the Username.";
                    note.text = "Note: You can change your\nUsername Only Once.";
                    Warning.color = Color.green;
                }
            }
            else
            {
                if (Playername.text.ToLower() == LoadJson.loadJson.PlayerName.ToLower())
                {
                    Continue.image.color = Continue.colors.normalColor;
                    Continue.interactable = true;

                    Warning.text = "";
                }
                else
                {
                    Warning.text = "Sorry but you can Only Change\nyour Username Once";
                    Warning.color = Color.red;

                    Continue.interactable = false;
                    Continue.image.color = Continue.colors.disabledColor;
                }
            }

        }
    }

    bool UsernameUsed()
    {
        // For each Player show them in the ScoreTable
        for (int i = 0; i < SelfSystemApi.ins.count; i++)
        {
            if (SelfSystemApi.ins.Playername[i].ToLower() == Playername.text.ToLower())
            {
                return true;
            }
        }
        return false;
    }

    public void MoveButton()
    {
        BackGameObject.SetActive(true);

        ContinueGameObject.GetComponent<RectTransform>().localPosition = new Vector3(-100, -455);
        BackGameObject.GetComponent<RectTransform>().localPosition = new Vector3(100, -455);
    }

    public void SaveUsername()
    {
        LoadJson.loadJson.JsonEditPlayerName(Playername.text);
    }

}
