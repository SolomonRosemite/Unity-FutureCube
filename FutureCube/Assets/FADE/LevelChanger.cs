using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelChanger : MonoBehaviour
{

    public Animator animator;

    private bool Clicked = false;
    private string NextScene;
    private float time;
    private string levelToLoad;

    public void Update()
    {
        if (Clicked == true)
        {
            time += 1 * Time.deltaTime;
            if (time > .4)
            {
                FadeToNextLevel();
                Clicked = false;
            }
        }
    }

    public void MainFadeStarter(string NextSceneByRose)
    {
        NextScene = NextSceneByRose;
        Clicked = true;
    }

    public void FadeToNextLevel()
    {
        FadeToLevel(levelIndex: NextScene);
    }

    public void FadeToLevel(string levelIndex)
    {
        levelToLoad = levelIndex;
        animator.SetTrigger("FadeOut");
    }

    public void OnFadeComplete()
    {
        if (levelToLoad == "Reload")
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
        else
        {
            SceneManager.LoadScene(levelToLoad);
        }
    }

    public void Test()
    {
        print("Test");
    }
}
