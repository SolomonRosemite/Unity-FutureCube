using UnityEngine;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

public class LevelChangerLast : MonoBehaviour {

    public GameObject Panel;
    public Animator animator;

    private bool Clicked = false;
    private int NextSceneByRose;
    private int NextScene;
    private float time;
	private int levelToLoad;

    // Update is called once per frame
    public void Update () {
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

    public void MainFadeStarter(int NextSceneByRose)
    {
        NextScene = NextSceneByRose;
        Clicked = true;
    }

	public void FadeToNextLevel ()
	{
        FadeToLevel(levelIndex: NextScene);
	}

	public void FadeToLevel (int levelIndex)
	{
		levelToLoad = levelIndex;
		animator.SetTrigger("FadeOut");
        Panel.SetActive(false);
    }

	public void OnFadeComplete ()
	{
		SceneManager.LoadScene(levelToLoad);
    }

    public void Test()
    {
        print("Test");
    }
}
