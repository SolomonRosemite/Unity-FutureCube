public class Chunk
{
    public int ChunkId { get; private set; }
    public int Difficulty { get; private set; }

    public Chunk(int ChunkId, int Difficulty)
    {
        this.ChunkId = ChunkId;
        this.Difficulty = Difficulty;
    }
}
