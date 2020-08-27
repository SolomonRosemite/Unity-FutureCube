using System.IO;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleBuilder : MonoBehaviour
{
    public GameObject parent;
    private Chunk chunk;

    [Space]

    public UnityEngine.Object obstacle;
    public UnityEngine.Object move;
    public UnityEngine.Object house;
    public UnityEngine.Object row;

    void Start() => StartCoroutine(LateStart(.5f));

    IEnumerator LateStart(float waitSeconds)
    {
        yield return new WaitForSeconds(waitSeconds);
        chunk = parent.GetComponent<ChunkHolder>().chunk;

        var components = GetObstacles(chunk.Difficulty);

        if (components.Count != 0)
        {
            BuildObstacles(components);
        }
    }

    private List<ObstacleComponent> GetObstacles(ChunkDifficulty difficulty)
    {
        List<ObstacleComponent> components = new List<ObstacleComponent>();

        int length = (int)(gameObject.transform.localScale.z / 100);

        switch (difficulty)
        {
            case ChunkDifficulty.none:
                return components;
            case ChunkDifficulty.easy:
                for (int i = 0; i < length; i++)
                {
                    components.Add(new ObstacleComponent(row, ChunkDifficulty.easy, Vector3.zero));
                }
                break;
            case ChunkDifficulty.medium:
                for (int i = 0; i < length; i++)
                {

                }
                break;
            case ChunkDifficulty.hard:
                for (int i = 0; i < length; i++)
                {

                }
                break;
        }

        return components;
    }

    private void BuildObstacles(List<ObstacleComponent> components)
    {
        int z = 0;

        foreach (var component in components)
        {
            print(z);
            GameObject item = Instantiate(
                component.Prefab,
                component.Vector != Vector3.zero ? component.Vector : new Vector3(0.447f, 1, 1.61009f),
                new Quaternion(), gameObject.transform
                ) as GameObject;
            z++;
            return;
        }
    }
}
