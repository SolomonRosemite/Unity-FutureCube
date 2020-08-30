using UnityEngine;

public class ObstacleHolder
{
    private GameObject[] Easy;
    private GameObject[] Medium;
    private GameObject[] Hard;

    public ObstacleHolder(GameObject[] Easy, GameObject[] Medium, GameObject[] Hard)
    {
        this.Easy = Easy;
        this.Medium = Medium;
        this.Hard = Hard;
    }

    public ObstacleHolder(GameObject TestObstacle)
    {
        this.Easy = new GameObject[] { TestObstacle };
        this.Medium = new GameObject[] { TestObstacle };
        this.Hard = new GameObject[] { TestObstacle };
    }

    public (GameObject, int) GetRandomObstacleComponent(ChunkDifficulty difficulty, System.Func<int, int, int> method)
    {
        switch (difficulty)
        {
            case ChunkDifficulty.none:
                return (new GameObject(), -1);
            case ChunkDifficulty.easy:
                int i = method(0, Easy.Length);
                return (Easy[i], i);
            case ChunkDifficulty.medium:
                int j = method(0, Medium.Length);
                return (Medium[j], j);
            case ChunkDifficulty.hard:
                int k = method(0, Hard.Length);
                return (Hard[k], k);
        }

        return (new GameObject(), -1);
    }

    public GameObject GetObstacleComponent(ChunkDifficulty difficulty, int index)
    {
        switch (difficulty)
        {
            case ChunkDifficulty.none:
                return new GameObject();
            case ChunkDifficulty.easy:
                return Easy[index];
            case ChunkDifficulty.medium:
                return Medium[index];
            case ChunkDifficulty.hard:
                return Hard[index];
        }

        return new GameObject();
    }
}
