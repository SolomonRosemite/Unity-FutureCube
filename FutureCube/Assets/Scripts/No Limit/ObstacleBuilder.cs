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

    private static readonly System.Random getRandom = new System.Random();

    void Start() => StartCoroutine(LateStart(.5f));

    IEnumerator LateStart(float waitSeconds)
    {
        yield return new WaitForSeconds(waitSeconds);
        chunk = parent.GetComponent<ChunkHolder>().chunk;

        var components = GetObstacleComponets(chunk.Difficulty);

        if (components.Count != 0) { BuildObstacles(components, chunk.Id); }
    }

    private List<ObstacleComponent> GetObstacleComponets(ChunkDifficulty difficulty)
    {
        List<ObstacleComponent> components = new List<ObstacleComponent>();

        int length = (int)(gameObject.transform.localScale.z / 100);

        int min = 0;
        int max = 100;

        switch (difficulty)
        {
            case ChunkDifficulty.none:
                return components;
            case ChunkDifficulty.easy:
                for (int i = 0; i < length; i++)
                {
                    ChunkDifficulty chunkDifficulty = difficulty;

                    if (i == 0)
                    {
                        components.Add(new ObstacleComponent(obstacle, difficulty));
                        continue;
                    }

                    if (components[i - 1].Difficulty == ChunkDifficulty.hard)
                    {
                        components.Add(
                            new ObstacleComponent(
                            GetObstacleGroupComponent(ChunkDifficulty.easy),
                            ChunkDifficulty.easy
                        ));

                        continue;
                    }

                    int value = GetRandomNumber(min, max);

                    if (value <= 7)
                        chunkDifficulty = ChunkDifficulty.hard;
                    else if (value <= 25)
                        chunkDifficulty = ChunkDifficulty.medium;

                    components.Add(
                        new ObstacleComponent(GetObstacleGroupComponent(chunkDifficulty), chunkDifficulty)
                    );
                }
                break;
            case ChunkDifficulty.medium:
                for (int i = 0; i < length; i++)
                {
                    ChunkDifficulty chunkDifficulty = difficulty;

                    if (i == 0)
                    {
                        components.Add(new ObstacleComponent(obstacle, difficulty));
                        continue;
                    }

                    if (components[i - 1].Difficulty == ChunkDifficulty.hard)
                    {
                        int rng = GetRandomNumber(0, 2);

                        components.Add(
                            new ObstacleComponent(
                            GetObstacleGroupComponent(rng == 0 ? ChunkDifficulty.easy : ChunkDifficulty.medium),
                            rng == 0 ? ChunkDifficulty.easy : ChunkDifficulty.medium
                        ));

                        continue;
                    }

                    int value = GetRandomNumber(min, max);

                    if (value <= 15)
                        chunkDifficulty = ChunkDifficulty.hard;
                    else if (value <= 70)
                        chunkDifficulty = ChunkDifficulty.medium;
                    else
                        chunkDifficulty = ChunkDifficulty.easy;

                    components.Add(
                        new ObstacleComponent(GetObstacleGroupComponent(chunkDifficulty), chunkDifficulty)
                    );
                }
                break;
            case ChunkDifficulty.hard:
                for (int i = 0; i < length; i++)
                {
                    ChunkDifficulty chunkDifficulty = difficulty;

                    if (i == 0)
                    {
                        components.Add(new ObstacleComponent(obstacle, difficulty));
                        continue;
                    }

                    if (components[i - 1].Difficulty == ChunkDifficulty.hard)
                    {
                        int rng = GetRandomNumber(0, 2);

                        components.Add(
                            new ObstacleComponent(
                            GetObstacleGroupComponent(rng == 0 ? ChunkDifficulty.easy : ChunkDifficulty.medium),
                            rng == 0 ? ChunkDifficulty.easy : ChunkDifficulty.medium
                        ));

                        continue;
                    }

                    int value = GetRandomNumber(min, max);

                    if (value <= 45)
                        chunkDifficulty = ChunkDifficulty.hard;
                    else if (value <= 85)
                        chunkDifficulty = ChunkDifficulty.medium;
                    else
                        chunkDifficulty = ChunkDifficulty.easy;

                    components.Add(
                        new ObstacleComponent(GetObstacleGroupComponent(chunkDifficulty), chunkDifficulty)
                    );
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
            componentPos = pos + new Vector3(0, 0, 100 * i);

            Instantiate(
                components[i].Prefab,
                componentPos,
                new Quaternion(),
                mainParent.transform
            );
        }
    }

    private static int GetRandomNumber(int min, int max)
    {
        lock (getRandom)
        {
            return getRandom.Next(min, max);
        }
    }

    private GameObject GetObstacleGroupComponent(ChunkDifficulty difficulty)
    {
        return ChunkManager.ins.obstacleHolder.GetRandomObstacleComponent(difficulty, GetRandomNumber).Item1;
    }
}
