using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChunkHolder : MonoBehaviour
{
    Chunk chunk;

    void Start() => StartCoroutine(LateStart(.5f));

    IEnumerator LateStart(float waitTime)
    {
        yield return new WaitForSeconds(waitTime);
        if (ChunkManager.ins.PreviousId == -1) { chunk = new Chunk(0, 0); }
    }

    public void updateChunkValues(Chunk chunk) => this.chunk = chunk;

    private void OnCollisionEnter(Collision other) => ChunkManager.ins.OnEnterNewChunk(this.gameObject, chunk);
}
