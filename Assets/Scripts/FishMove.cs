using UnityEngine;

public class FishMove : MonoBehaviour
{
    public float speed = 2f;

    // Pond center
    public Vector3 pondCenter;

    // Pond size
    public float pondRadius = 3f;

    void Update()
    {
        // Move forward
        transform.Translate(Vector3.forward * speed * Time.deltaTime);

        // Distance from center
        float distance = Vector3.Distance(transform.position, pondCenter);

        // If fish goes outside pond
        if (distance > pondRadius)
        {
            // Turn back toward center
            Vector3 direction = (pondCenter - transform.position).normalized;

            transform.rotation = Quaternion.LookRotation(direction);
        }

        // Random turning
        if (Random.Range(0, 100) < 1)
        {
            transform.Rotate(0, Random.Range(-90, 90), 0);
        }
    }
}