using UnityEngine;

public class QuitApplication : MonoBehaviour {

	public void Quit()
	{
		    //If we are running in a standalone build of the game
	    #if UNITY_STANDALONE
		    //Quit the application
		    Application.Quit();
	    #endif

		    //If we are running in the editor
	    #if UNITY_EDITOR
		    //Stop playing the scene
		    UnityEditor.EditorApplication.isPlaying = false;
        #endif

        #if UNITY_IOS
                //Quit the application
                Application.Quit();
        #endif

        #if UNITY_IPHONE
                //Quit the application
                Application.Quit();
        #endif

        #if UNITY_ANDROID
                //Quit the application
                Application.Quit();
        #endif
    }
}
