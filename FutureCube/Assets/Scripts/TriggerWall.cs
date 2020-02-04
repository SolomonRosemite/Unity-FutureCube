using UnityEngine;

public class TriggerWall : MonoBehaviour
{

    public Rigidbody RigidbodyWalls;
    public GameObject Tr;

    public float radius = 5.0F;
    public float power = 10.0F;

    private void Start()
    {
        Vector3 explosionPos = Tr.transform.position;
        RigidbodyWalls.AddExplosionForce(power, explosionPos, radius, 3.0F);
    }
    /*
    void OnTriggerEnter ()
	{
        Vector3 explosionPos = Tr.transform.position;
        RigidbodyWalls.AddExplosionForce(power, explosionPos, radius, 3.0F);

    }
    */
}
