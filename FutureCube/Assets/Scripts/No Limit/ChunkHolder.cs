using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChunkHolder : MonoBehaviour
{
    public bool firstChunk = false;
    Chunk chunk;

    void Start()
    {
        if (firstChunk == true) { chunk = new Chunk(0, 0); }
    }

    public void updateChunkValues(Chunk chunk)
    {
        this.chunk = chunk;
    }

    private void OnCollisionEnter(Collision other)
    {
        ChunkManager.ins.OnEnterNewChunk(this.gameObject, chunk);
    }
}
