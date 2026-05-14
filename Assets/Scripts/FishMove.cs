using UnityEngine;

public class FishMove : MonoBehaviour
{
    public float speed = 2f;
    public Vector3 pondCenter = Vector3.zero;
    public float pondRadius = 3f;

    void Start()
    {
        // Place fish inside pond at random position
        Vector2 randomCircle = Random.insideUnitCircle * pondRadius;
        transform.position = pondCenter + new Vector3(randomCircle.x, 0, randomCircle.y);

        // Random facing direction
        transform.rotation = Quaternion.Euler(0, Random.Range(0, 360), 0);
    }

    void Update()
    {
        // Move forward
        transform.Translate(Vector3.forward * speed * Time.deltaTime);

        // Check distance from pond center
        float distance = Vector3.Distance(transform.position, pondCenter);

        if (distance > pondRadius)
        {
            // Smoothly turn back toward center
            Vector3 direction = (pondCenter - transform.position).normalized;
            Quaternion targetRotation = Quaternion.LookRotation(direction);
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, Time.deltaTime * 2f);
        }

        // Random turning
        if (Random.Range(0, 100) < 1)
        {
            transform.Rotate(0, Random.Range(-90, 90), 0);
        }
    }
}
