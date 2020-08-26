public class Chunk
{
    public int Id { get; private set; }
    public int Difficulty { get; private set; }

    public Chunk(int ChunkId, int Difficulty)
    {
        this.Id = ChunkId;
        this.Difficulty = Difficulty;
    }
}
