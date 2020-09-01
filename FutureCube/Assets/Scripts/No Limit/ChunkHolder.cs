using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class ChunkHolder : MonoBehaviour
{
    public Chunk chunk { get; private set; }
    private ChunkManager chunkManager;

    private bool repeated = false;

    void Start()
    {
        if (chunk == null) { chunk = new Chunk(0, ChunkDifficulty.easy); }
        new GameObject($"Chunk {chunk.Id}");

        StartCoroutine(LateStart(.5f));
    }

    IEnumerator LateStart(float seconds)
    {
        yield return new WaitForSeconds(seconds);

        chunkManager = ChunkManager.ins.gameObject.GetComponent<ChunkManager>();

        chunkManager.OnNewChunk += OnNewChunk;
    }

    private void OnNewChunk(object x, ChunkManager.OnNewChunkEventArgs args)
    {
        if (args.chunkId == chunk.Id || repeated == false && chunk.Id == 0)
        {
            repeated = true;
            chunkManager.LoadNewChunk(gameObject, chunk);
        }
    }

    public void updateChunkValues(Chunk chunk) => this.chunk = chunk;
}
