using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class BallController : MonoBehaviour
{
    [Tooltip("Initial speed on X and Y axes")]
    public Vector2 initialVelocity = new Vector2(5f, 5f);

    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        // Give the ball its starting velocity:
        rb.velocity = initialVelocity;
    }

    // (Optionally, if you ever want to re‐launch:)
    public void Relaunch(Vector2 newVelocity)
    {
        rb.velocity = newVelocity;
    }
}