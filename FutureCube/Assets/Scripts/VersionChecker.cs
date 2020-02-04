using UnityEngine;

public class VersionChecker : MonoBehaviour
{
    public GameObject UpdateGameObject;

    void Start()
    {
        if (LoadJson.loadJson.UpdateAvailable == true)
        {
            try { UpdateGameObject.SetActive(true); } catch { }
        }
    }

    public void OpenURL(string url)
    {
        Application.OpenURL(url);
    }
}
