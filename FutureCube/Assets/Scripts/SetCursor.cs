using UnityEngine.SceneManagement;
using UnityEngine;

public class SetCursor : MonoBehaviour
{
    void Update()
    {
        try
        {
            if (PauseV2.pauseV2.GamePaused)
            {
                Cursor.visible = true;
            }
            if (PauseV2.pauseV2.GamePaused == false)
            {
                // Create a temporary reference to the current scene.
                Scene currentScene = SceneManager.GetActiveScene();

                if (currentScene.name.Contains("Level"))
                {
                    Cursor.visible = false;
                }
                else
                {
                    Cursor.visible = true;
                }
            }
        }
        catch{}
    }
}
