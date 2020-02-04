using UnityEngine;
using UnityEngine.SceneManagement;

public class BackToMenu : MonoBehaviour
{

    public void BackToM()
    {


        //If we are running in a standalone build of the game
#if UNITY_STANDALONE

                    //FadePanel.SetActive(false);
		            SceneManager.LoadScene(1);
#endif

        //If we are running in the editor
#if UNITY_EDITOR
        //Stop playing the scene
        //FadePanel.SetActive(false);
        SceneManager.LoadScene(1);
#endif

#if UNITY_IOS
        //FadePanel.SetActive(false);
        SceneManager.LoadScene(1);
#endif

#if UNITY_IPHONE
        //FadePanel.SetActive(false);
        SceneManager.LoadScene(1);
#endif

#if UNITY_ANDROID
        //FadePanel.SetActive(false);
        SceneManager.LoadScene(1);
        #endif
    }

}
