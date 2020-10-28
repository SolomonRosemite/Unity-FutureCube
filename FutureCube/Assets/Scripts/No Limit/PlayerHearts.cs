using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PlayerHearts : MonoBehaviour
{
    void Start()
    {
        var playerCollision = gameObject.GetComponent<PlayerCollision>();

        playerCollision.onHitObstacle += OnHitObstacle;
    }

    private void OnHitObstacle(object _, PlayerCollision.OnHitObstacleEventArgs args)
    {
        // Todo: Show Remaining Hearts in Player UI.
        print($"Remaining Hearts: {args.heartsRemaining}");
    }
}
