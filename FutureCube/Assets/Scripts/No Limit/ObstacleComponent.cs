
public class ObstacleComponent
{
    public ChunkDifficulty Difficulty { get; private set; }
    public UnityEngine.GameObject Prefab { get; private set; }

    public ObstacleComponent(UnityEngine.GameObject Prefab, ChunkDifficulty difficulty)
    {
        this.Difficulty = Difficulty;
        this.Prefab = Prefab;
    }
}
