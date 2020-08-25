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
        Vector3 whiteZoneVector = whiteZone.localScale;

        greenZoneVector.z = zScale;
        whiteZoneVector.z = length - blueZone.localScale.z - zScale;

        greenZone.localScale = greenZoneVector;
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
        // whiteZonePosition.z = blueZone.position.z;

        // whiteZonePosition.z -= whiteZone.localScale.z / 2 - 30;
        // whiteZone.position = whiteZonePosition;

        // // Vector3 greenZonePosition = greenZone.position;

        // // print(blueZone.localScale.z);
        // // print(whiteZone.localScale.z);
        // // print(blueZone.localScale.z / 2 + whiteZone.localScale.z / 2);

        // whiteZonePosition.z = 150 - blueZone.localScale.z + whiteZone.localScale.z;

        // // whiteZone.position = whiteZonePosition;
    }
}
