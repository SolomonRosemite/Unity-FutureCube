using UnityEngine;

public class MovingObstacle : MonoBehaviour
{
    public Transform transformObstacle;
    public Rigidbody rigidbodyObstacle;

    public float speed;
    public float leftEnd;
    public float rightEnd;

    private bool rightOrLeft;

    // Moves the Obstacle Left and Right
    private void FixedUpdate()
    {
        if (rigidbodyObstacle == null)
        {
            print(gameObject.name);
        }
        if (transformObstacle.position.x >= rightEnd)
        {
            rightOrLeft = true;
        }

        if (transformObstacle.position.x <= leftEnd)
        {
            rightOrLeft = false;
        }

        if (rightOrLeft == true)
        {
            rigidbodyObstacle.AddForce(-speed * Time.deltaTime, 0, 0);
        }

        if (rightOrLeft == false)
        {
            rigidbodyObstacle.AddForce(speed * Time.deltaTime, 0, 0);
        }

    }
}
