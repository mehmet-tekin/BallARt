
using UnityEngine;

public class BallWallCollisionChecker : MonoBehaviour
{
    private int hitCount = 0;
    public int maxHits = 4;
    public float scaleFactor = 1.2f; // Factor to grow after each hit


    void OnCollisionEnter2D(Collision2D collision)
    {

        if (collision.gameObject.CompareTag("Wall"))
        {

            hitCount++;

            transform.localScale *= scaleFactor;

            if (hitCount >= maxHits)
            {
                Destroy(this.gameObject);
            }
        }
    }
}
