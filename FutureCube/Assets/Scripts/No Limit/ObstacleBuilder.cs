using System.IO;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleBuilder : MonoBehaviour
{
    public GameObject parent;
    private Chunk chunk;

    [Space]

    public GameObject obstacle;
    public GameObject move;
    public GameObject house;
    public GameObject row;

    void Start() => StartCoroutine(LateStart(.5f));

    IEnumerator LateStart(float waitSeconds)
    {
        yield return new WaitForSeconds(waitSeconds);
        chunk = parent.GetComponent<ChunkHolder>().chunk;

        var components = GetObstacles(chunk.Difficulty);

        if (components.Count != 0)
        {
            BuildObstacles(components, chunk.Id);
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
                    components.Add(new ObstacleComponent(obstacle, ChunkDifficulty.easy, Vector3.zero));
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

    private void BuildObstacles(List<ObstacleComponent> components, int id)
    {
        Vector3 pos = gameObject.transform.position;
        GameObject mainParent = GameObject.Find($"Chunk {id}");

        string name = transform.parent.name;

        name = name.Substring(name.Length - 1);

        GameObject group = new GameObject(name);
        group.transform.parent = mainParent.transform;

        print(group.name);

        for (int i = 0; i < components.Count; i++)
        {
            Vector3 componentPos = pos + new Vector3(1, 3, 100 * i);

            Instantiate(
                components[i].Prefab,
                componentPos,
                new Quaternion(),
                group.transform
            );
        }
    }
}
