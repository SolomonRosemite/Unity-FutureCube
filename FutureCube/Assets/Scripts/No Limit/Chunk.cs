public enum ChunkDifficulty
{
    none,
    easy,
    medium,
    hard
}

public class Chunk
{
    public int Id { get; private set; }
    public ChunkDifficulty Difficulty { get; private set; }

    public Chunk(int ChunkId, ChunkDifficulty Difficulty)
    {
        this.Id = ChunkId;
        this.Difficulty = Difficulty;
    }
}
