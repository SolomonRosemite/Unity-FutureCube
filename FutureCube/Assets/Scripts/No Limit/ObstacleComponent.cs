using System.Collections;
using System.Collections.Generic;

public class ObstacleComponent
{
    public ChunkDifficulty Difficulty { get; private set; }
    public UnityEngine.Object Prefab { get; private set; }
    public UnityEngine.Vector3 Vector { get; private set; }

    public ObstacleComponent(UnityEngine.Object Prefab, ChunkDifficulty Difficulty, UnityEngine.Vector3 Vector)
    {
        this.Difficulty = Difficulty;
        this.Prefab = Prefab;
        this.Vector = Vector;
    }
}
