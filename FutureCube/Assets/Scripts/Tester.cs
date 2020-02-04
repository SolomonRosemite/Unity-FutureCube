using System.Collections;
using UnityEngine;

public class Tester : MonoBehaviour
{
    private float y = 1;

    private void Start()
    {
        StartCoroutine(Trash());
    }

    public IEnumerator Trash()
    {
        while (y > 0)
        {
            y -= Time.deltaTime;
            print(y);
            yield return null;
        }
    }
}