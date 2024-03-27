using UnityEngine;

public class ContinuousSmoothMovementZAxis : MonoBehaviour
{
    public float acceleration = 0.1f; // Acceleration rate for easing effect
    public float maxSpeed = 5f; // Maximum speed of the object
    private float currentSpeed = 0f; // Current moving speed of the object
    private int direction = 0; // Direction of movement: 0 = stop, 1 = forward, -1 = backward

    void Update()
    {
        // Check for up arrow key input to move forward
        if (Input.GetKey(KeyCode.UpArrow))
        {
            direction = 1;
        }
        // Check for down arrow key input to move backward
        else if (Input.GetKey(KeyCode.DownArrow))
        {
            direction = -1;
        }
        else
        {
            direction = 0;
        }

        // Calculate current speed based on direction
        if (direction != 0)
        {
            // Increase current speed with acceleration until max speed is reached
            currentSpeed = Mathf.MoveTowards(currentSpeed, maxSpeed * direction, acceleration * Time.deltaTime);
        }
        else
        {
            // Decelerate to stop
            currentSpeed = Mathf.MoveTowards(currentSpeed, 0, acceleration * Time.deltaTime);
        }

        // Move the GameObject using the current speed
        transform.Translate(currentSpeed * Time.deltaTime, 0, 0);
    }
}
