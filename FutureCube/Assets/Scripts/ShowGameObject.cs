using UnityEngine;

public class ShowGameObject : MonoBehaviour
{
    public GameObject gameobject;

    private bool HideOrShow = true;

    void OnCollisionEnter(Collision collisioninfo)
    {
        if (collisioninfo.gameObject.name == "Player")
        {
            gameobject.SetActive(HideOrShow);
        }
    }
}
