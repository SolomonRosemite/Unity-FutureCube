using UnityEngine;

public class ShowSelf : MonoBehaviour
{
    public GameObject optionsPanel;

    public void Show()
    {
        optionsPanel.SetActive(true);
    }

    public void Hide()
    {
        optionsPanel.SetActive(false);
    }
}
