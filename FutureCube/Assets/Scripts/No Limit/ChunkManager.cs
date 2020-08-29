using System;
using System.Collections.Generic;
using System.Collections;
using UnityEngine;

public class ChunkManager : MonoBehaviour
{
    public static ChunkManager ins;
    public UnityEngine.Object prefab;
    public int PreviousId { get; private set; } = -1;

    private Queue<GameObject> queueOfChunks = new Queue<GameObject>();

    private const string playerGameObjectTag = "PlayerPcOrPhone";
    private const float chunkDropOff = 0.03f;

    void Start() => ins = this;

    public void OnEnterNewChunk(GameObject go, Chunk chunk, Collision collision)
    {
        if (collision.collider.tag != playerGameObjectTag) { return; }

        if (PreviousId == chunk.Id) { return; }

        var position = go.transform.position;
        float z = position.z + go.transform.localScale.z;

        PreviousId = chunk.Id;

        if (PreviousId > 2)
            return;

        queueOfChunks.Enqueue(go);

        CreateChunk(
            new Chunk(chunk.Id + 1, chunk.Difficulty),
            new Vector3(position.x, position.y - chunkDropOff, z)
        );

        UnloadChunk();
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
