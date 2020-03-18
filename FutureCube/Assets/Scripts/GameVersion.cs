using UnityEngine.SceneManagement;
using System.Threading.Tasks;
using System.Collections;
using UnityEngine;

public class GameVersion : MonoBehaviour
{
    private string VersionTEMP;
    private float Version;
    private bool UpdateAvailable;

    private float nextActionTime;
    private float period = 0.5f;

    void Start()
    {
        if (Application.internetReachability != NetworkReachability.NotReachable)
        {
            StartCoroutine(Wait(2));
        }
    }

    IEnumerator Wait(int sec)
    {
        yield return new WaitForSeconds(sec);
        CheckVersion();
    }

    async void CheckVersion()
    {
        Version = await BackendDatabase.backend.GetGameVersion();

        if (Version > LoadJson.Version)
        {
            UpdateAvailable = true;
        }
        else
        {
            enabled = false;
        }
    }

    void Update()
    {
        if (Time.time > nextActionTime)
        {
            nextActionTime += period;

            // Create a temporary reference to the current scene.
            Scene currentScene = SceneManager.GetActiveScene();

            if (UpdateAvailable == true && currentScene.name == "Select Mode")
            {
                GameObject.Find("Manager").GetComponent<SelectRandomV2>().UpdateGO();
                LoadJson.loadJson.UpdateAvailable = true;
                enabled = false;
            }
        }
    }

}
