using System.Collections.Generic;
using System.Collections;
using UnityEngine;

public class ChunkManager : MonoBehaviour
{
    public static ChunkManager ins;
    // public Object prefab = Resources.Load("Assets/PreMade/Prefab/InGameObjects/no limit/Chunk.prefab");
    public Object prefab;

    void Start() => ins = this;

    public void OnEnterNewChunk(GameObject go, Chunk chunk)
    {
        var position = go.transform.position;

        float z = position.z + go.transform.localScale.z;

        print(go.transform.position);
        CreateChunk
        (
            new Chunk(chunk.ChunkId + 1, chunk.Difficulty),
            new Vector3(position.x, position.y - .1f, z)
        );
    }

    public void CreateChunk(Chunk values, Vector3 position)
    {
        GameObject chunk = Instantiate(prefab, position, new Quaternion()) as GameObject;
        ChunkHolder chunkHolder = chunk.GetComponent<ChunkHolder>();

        chunkHolder.updateChunkValues(values);
    }
}
