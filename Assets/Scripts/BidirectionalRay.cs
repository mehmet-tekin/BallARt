using UnityEngine;
using System.Collections;

public class BidirectionalRay : MonoBehaviour
{
    [Header("Laser Settings")]
    public GameObject laserSpritePrefab;     // prefab with SpriteRenderer
    public float rayDistance = 20f; //TODO
    public float rayInterval = 0.2f;
    public float laserDuration = 3f;

    [Header("Sprite Settings")]
    public float laserThickness = 0.1f;
    public Color laserColor = Color.red;

    private bool isFiring = false;

    void Update()
    {
        if (Input.GetMouseButtonDown(0) && !isFiring)
        {
            Vector3 mouseWorldPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector2 clickPoint = new(mouseWorldPos.x, mouseWorldPos.y);

            StartCoroutine(FireRandomLaserFromPoint(clickPoint));
        }
    }

    IEnumerator FireRandomLaserFromPoint(Vector2 origin)
    {
        isFiring = true;
        float elapsed = 0f;

        Vector2 direction = Random.insideUnitCircle.normalized;

        while (elapsed < laserDuration)
        {
            CastLaser(origin, direction);
            CastLaser(origin, -direction);

            elapsed += rayInterval;
            yield return new WaitForSeconds(rayInterval);
        }

        isFiring = false;
    }

    void CastLaser(Vector2 origin, Vector2 direction)
    {
        RaycastHit2D hit = Physics2D.Raycast(origin, direction, rayDistance);
        float length = hit.collider ? hit.distance : rayDistance;

        DrawLaserSprite(origin, direction, length);
    }

    void DrawLaserSprite(Vector2 origin, Vector2 direction, float length)
    {
        GameObject laser = Instantiate(laserSpritePrefab, origin, Quaternion.identity);
        
        if (laser.TryGetComponent<SpriteRenderer>(out var sr))
        {
            sr.color = laserColor;
            
            laser.transform.right = direction; 
            laser.transform.localScale = new Vector3(length, laserThickness, 1f);
        }

        Destroy(laser, rayInterval);
    }
}
