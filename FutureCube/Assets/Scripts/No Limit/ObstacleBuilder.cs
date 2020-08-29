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

        // Todo: When Choosing a difficulty Randomize it with the others.
        /* Example:
           difficulty = ChunkDifficulty.medium
           length = 3
           
           i = 0 => new ObstacleComponent with medium difficulty
           i = 1 => new ObstacleComponent with easy difficulty
           i = 2 => new ObstacleComponent with hard difficulty
        */
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
        GameObject mainParent = GameObject.Find($"Chunk {id}");
        Vector3 pos = transform.position;

        // Shift the z Position
        var greenZone = transform.parent.GetComponent<ObstacleGroupManager>().greenZone;

        pos = new Vector3(
            pos.x,
            pos.y,
            greenZone.position.z + greenZone.localScale.z / 2 + 1
        );

        Vector3 componentPos;
        for (int i = 0; i < components.Count; i++)
        {
            componentPos = pos + new Vector3(1, 3, 100 * i);

            Instantiate(
                components[i].Prefab,
                componentPos,
                new Quaternion(),
                mainParent.transform
            );
        }
    }
}
