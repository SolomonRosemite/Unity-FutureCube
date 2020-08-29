using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChunkHolder : MonoBehaviour
{
    public Chunk chunk { get; private set; }

    void Start()
    {
        if (chunk == null) { chunk = new Chunk(0, ChunkDifficulty.hard); }
        new GameObject($"Chunk {chunk.Id}");
    }

    public void updateChunkValues(Chunk chunk) => this.chunk = chunk;

    private void OnCollisionEnter(Collision other) => ChunkManager.ins.OnEnterNewChunk(this.gameObject, chunk, other);
}
