using UnityEngine;

public class EndTrigger : MonoBehaviour
{

    public GameManager gameManager;

    public GameObject GameOb;

    public void OnTriggerEnter()
    {
        if (PauseV2.pauseV2.OverGame != true)
        {
            GameManager.gameManager.LevelCompleted = true;
            gameManager.CompleteLevel();
            PointSystem.pointSystem.ForText();
        }
    }

}
