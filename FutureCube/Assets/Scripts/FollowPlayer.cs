using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    public static FollowPlayer ins;

    public Transform player;
    public Vector3 offset;

    private void Start() => ins = this;

    void Update() => transform.position = player.position + offset;
}
