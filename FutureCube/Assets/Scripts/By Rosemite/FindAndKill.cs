using UnityEngine;

public class FindAndKill : MonoBehaviour
{
    public static FindAndKill ins;
    private GameObject DeadGameObject;
    private bool Go = false;
    private float time;

    // Start is called before the first frame update
    void Start()
    {
        ins = this;

        try
        {
            DeadGameObject = GameObject.FindGameObjectWithTag("OnLoadDestroy");
        }
        catch
        {
            Debug.LogWarning("Kill and find couldn't find target");
        }
    }

    public void EndOfSence()
    {
        Go = true;
    }

    public void FindAndKillGameObject(string gameObjectTag)
    {
        try
        {
            DeadGameObject = GameObject.FindGameObjectWithTag(gameObjectTag);
            Go = true;
        }
        catch
        {
            Debug.LogWarning("GameObject could not be found");
        }
    }

    private void Update()
    {
        if (Go == true)
        {
            time += 100 * Time.deltaTime;
            if (time > 110)
            {
                Destroy(DeadGameObject);
                Go = false;
            }
        }
    }
}
