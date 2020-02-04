using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PcOrPhoneDetect : MonoBehaviour
{
    public static PcOrPhoneDetect ins;

    [HideInInspector]
    public int Platform = -1;

    private GameObject Panel;

    private float nextActionTime = 0.0f;
    private float period = 0.3f;

    // Start is called before the first frame update
    void Awake()
    {

        //If we are running in a standalone build of the game
#if UNITY_STANDALONE
                Platform = 1;
#endif
#if UNITY_ANDROID
        Platform = 2;
#endif
        //If we are running in the editor
#if UNITY_EDITOR
        Platform = 1;
#endif

#if UNITY_IOS
                Platform = 2;
#endif

#if UNITY_IPHONE
                Platform = 2;
#endif

    }

    private void Start()
    {
        ins = this;
    }

    private void Update()
    {
        // Create a temporary reference to the current scene.
        Scene currentScene = SceneManager.GetActiveScene();

        // Retrieve the name of this scene.
        string sceneName = currentScene.name;

        if (Platform == 1)
        {
            if (sceneName.Contains("Level") == true || sceneName == ("Play") || sceneName == ("Thanks for Playing Cube"))
            {
                try { GameObject.Find("Textnochange").GetComponent<Text>().text = "Press Space to Play"; } catch { }
                try { GameObject.Find("TextProDOnotChangename").GetComponent<Text>().text = "Press Space to Continue"; } catch { }
                try { GameObject.Find("Tap To Retry text").GetComponent<Text>().text = "Press Space to Retry"; } catch { }
            }
        }

        if (sceneName.Contains("Level") == true)
        {
            if (Time.time > nextActionTime)
            {
                nextActionTime += period;

                if (Platform == 1)
                {
                    try { GameObject.Find("Hamburger Button").SetActive(false); } catch { }

                    Panel = GameObject.FindGameObjectWithTag("PlayerPcOrPhone");
                    Panel.GetComponent<PlayerMovement>().enabled = true;
                    Panel.GetComponent<PlayerMovePhone>().enabled = false;
                }

                if (Platform == 2)
                {
                    Panel = GameObject.FindGameObjectWithTag("PlayerPcOrPhone");

                    Panel.GetComponent<PlayerMovement>().enabled = false;
                    Panel.GetComponent<PlayerMovePhone>().enabled = true;
                }
            }
        }

    }
}
