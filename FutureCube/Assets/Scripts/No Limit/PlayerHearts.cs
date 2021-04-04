using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PlayerHearts : MonoBehaviour
{
    public GameObject[] hearts;

    void Start()
    {
        var playerCollision = gameObject.GetComponent<PlayerCollision>();

        playerCollision.onHitObstacle += OnHitObstacle;
    }

    private void OnHitObstacle(object _, PlayerCollision.OnHitObstacleEventArgs args)
    {
        // print($"Remaining Hearts: {args.heartsRemaining}");
        hearts[args.heartsRemaining + 1].SetActive(false);
    }
}
