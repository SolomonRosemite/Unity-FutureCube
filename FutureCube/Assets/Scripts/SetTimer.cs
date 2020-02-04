using System.Collections;
using UnityEngine;

public class SetTimer : MonoBehaviour
{
    public float WaitSec;

    public MeshRenderer V1;
    public MeshRenderer V2;
    public MeshRenderer V3;
    public MeshRenderer V4;
    public MeshRenderer V5;

    void Start()
    {
        V1.enabled = false;
        V2.enabled = false;
        V3.enabled = false;
        V4.enabled = false;
        V5.enabled = false;

        StartCoroutine(Example());
    }

    IEnumerator Example()
    {
        yield return new WaitForSeconds(WaitSec);
        Render();
    }

    public void Render()
    {
        V1.enabled = true;
        V2.enabled = true;
        V3.enabled = true;
        V4.enabled = true;
        V5.enabled = true;
    }
}
