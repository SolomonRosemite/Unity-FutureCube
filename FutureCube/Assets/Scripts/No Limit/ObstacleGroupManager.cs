using System;
using System.Collections.Generic;
using System.Collections;
using UnityEngine;

public class ObstacleGroupManager : MonoBehaviour
{
    public Transform blueZone;
    public Transform whiteZone;
    public Transform greenZone;

    const int length = 500;

    void Start()
    {
        // Get Random number and assign that number to the localScale z scale of the greenZone.
        int zScale = new System.Random().Next(10, 35);

        Vector3 greenZoneVector = greenZone.localScale;
        greenZoneVector.z = zScale;

        greenZone.localScale = greenZoneVector;

        Vector3 whiteZoneVector = whiteZone.localScale;
        whiteZoneVector.z = length - blueZone.localScale.z - zScale;

        whiteZone.localScale = whiteZoneVector;

        SetPostions();
    }

    private void SetPostions()
    {
        Vector3 whiteZonePosition = whiteZone.position;

        whiteZonePosition.z = blueZone.position.z;

        whiteZonePosition.z -= whiteZone.localScale.z / 2;
        whiteZonePosition.z -= 10;

        whiteZone.position = whiteZonePosition;

        Vector3 greenZonePosition = greenZone.position;

        greenZonePosition.z = blueZone.position.z;

        greenZonePosition.z -= greenZone.localScale.z / 2;
        greenZonePosition.z -= 10 + whiteZone.localScale.z;

        greenZone.position = greenZonePosition;
    }
}
