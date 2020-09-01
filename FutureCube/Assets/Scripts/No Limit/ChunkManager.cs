using System.Collections.Generic;
using UnityEngine;
using System;

public class ChunkManager : MonoBehaviour
{
    public static ChunkManager ins;

    // Events
    public event EventHandler<OnNewChunkEventArgs> OnNewChunk;

    public class OnNewChunkEventArgs : EventArgs
    {
        public int chunkId;
    }

    // GameObjects
    public UnityEngine.Object prefab;

    [Space]

    public GameObject player;

    [Space]

    public GameObject[] Easy;
    public GameObject[] Medium;
    public GameObject[] Hard;


    [Space]

    // Testing
    public GameObject testObstacle;
    public bool enableTestObstacle;

    // Gameobject Data
    public int PreviousId { get; private set; } = 0;
    private float nextChunkPosition = 0;
    public ObstacleHolder obstacleHolder;

    private Queue<GameObject> queueOfChunks = new Queue<GameObject>();
    private const float chunkDropOff = 0.03f;


    void Start()
    {
        ins = this;

        obstacleHolder = testObstacle != null && enableTestObstacle ?
        (new ObstacleHolder(testObstacle))
        : (new ObstacleHolder(Easy, Medium, Hard));
    }

    void Update()
    {
        if (player.transform.position.z > nextChunkPosition)
            EmitNewChunkEvent();
    }

    private void EmitNewChunkEvent() => OnNewChunk?.Invoke(this, new OnNewChunkEventArgs { chunkId = PreviousId + 1 });

    public void LoadNewChunk(GameObject previous, Chunk chunk)
    {
        nextChunkPosition += 1200;

        var position = previous.transform.position;
        float z = position.z + previous.transform.localScale.z;

        PreviousId = chunk.Id;

        queueOfChunks.Enqueue(previous);

        CreateChunk(
            new Chunk(chunk.Id + 1, SetDifficulty(chunk.Difficulty, chunk.Id + 1)),
            new Vector3(position.x, position.y - chunkDropOff, z)
        );

        UnloadChunk();
    }

    private ChunkDifficulty SetDifficulty(ChunkDifficulty chunkDifficulty, int stageId)
    {
        if (chunkDifficulty == ChunkDifficulty.hard)
            return ChunkDifficulty.hard;

        if (stageId == 5)
            return chunkDifficulty == ChunkDifficulty.easy ? ChunkDifficulty.medium : ChunkDifficulty.hard;

        if (stageId == 10)
            return ChunkDifficulty.hard;

        return chunkDifficulty;
    }

    private void CreateChunk(Chunk values, Vector3 position)
    {
        GameObject chunk = Instantiate(prefab, position, new Quaternion()) as GameObject;
        ChunkHolder chunkHolder = chunk.GetComponent<ChunkHolder>();

        chunkHolder.updateChunkValues(values);
    }

    private void UnloadChunk()
    {
        if (queueOfChunks.Count > 2)
        {
            var chunkGameObject = queueOfChunks.Dequeue();

            Destroy(GameObject.Find($"Chunk {chunkGameObject.GetComponent<ChunkHolder>().chunk.Id}"));
            Destroy(chunkGameObject);
        }
    }
}
