using UnityEngine.SceneManagement;
using UnityEngine;

public class SetPlayerSkin : MonoBehaviour
{
    private Renderer PlayerRenderer;

    void Start()
    {
        PlayerRenderer = gameObject.GetComponent<Renderer>();

        PlayerRenderer.material.SetColor("_Color", SkinSystem.ins.PlayerColor);


        // Create a temporary reference to the current scene.
        Scene currentScene = SceneManager.GetActiveScene();

        if (currentScene.name.Contains("Level06"))
        {
            PlayerRenderer.material.SetColor("_Color", Color.white);
        }

    }
}
