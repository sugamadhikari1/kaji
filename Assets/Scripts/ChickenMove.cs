using UnityEngine;

public class ChickenMove : MonoBehaviour
{
    public float speed = 2f;

    void Update()
    {
        transform.Translate(Vector3.forward * speed * Time.deltaTime);

        if (Random.Range(0, 100) < 1)
        {
            transform.Rotate(0, Random.Range(0, 360), 0);
        }
    }
}