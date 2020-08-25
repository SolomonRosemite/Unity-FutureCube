using System;
using System.Collections.Generic;
using System.Collections;
using UnityEngine;

public class ChunkManager : MonoBehaviour
{
    public static ChunkManager ins;
    public UnityEngine.Object prefab;
    public int PreviousId { get; private set; } = -1;

    void Start() => ins = this;

    public void OnEnterNewChunk(GameObject go, Chunk chunk)
    {
        if (PreviousId == chunk.ChunkId) { return; }
        var position = go.transform.position;
        float z = position.z + go.transform.localScale.z;

        PreviousId = chunk.ChunkId;
        print(PreviousId);

        CreateChunk(
            new Chunk(chunk.ChunkId + 1, chunk.Difficulty),
            new Vector3(position.x, position.y - 0.03f, z)
        );
    }

    private void CreateChunk(Chunk values, Vector3 position)
    {
        GameObject chunk = Instantiate(prefab, position, new Quaternion()) as GameObject;
        ChunkHolder chunkHolder = chunk.GetComponent<ChunkHolder>();

        chunkHolder.updateChunkValues(values);
    }
}
