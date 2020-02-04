using UnityEngine;

public class MovingObstacle : MonoBehaviour
{

    public Transform TransformObstacle;
    public Rigidbody RigidbodyObstacle;

    public float Speed;
    public float LeftEnd;
    public float RightEnd;

    private bool RightLeft;

    private void FixedUpdate()
    {
        
        if (TransformObstacle.position.x >= RightEnd)
        {
            RightLeft = true;
        }
        
        if (TransformObstacle.position.x <= LeftEnd)
        {
            RightLeft = false;
        }

        if (RightLeft == true)
        {
            RigidbodyObstacle.AddForce(-Speed * Time.deltaTime, 0, 0);
        }

        if (RightLeft == false)
        {
            RigidbodyObstacle.AddForce(Speed * Time.deltaTime, 0, 0);
        }

    }
}
