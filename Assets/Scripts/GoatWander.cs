using UnityEngine;

public class GoatWander : MonoBehaviour
{
    public float speed = 1.5f;
    public float turnSpeed = 2f;
    public Transform penCenter;  // drag your pen's center object here
    public Vector3 areaSize = new Vector3(12f, 0f, 12f);

    private Vector3 target;
    private float waitTimer;

    void Start() => PickTarget();

    void Update()
    {
        if (waitTimer > 0) { waitTimer -= Time.deltaTime; return; }

        transform.position = Vector3.MoveTowards(transform.position, target, speed * Time.deltaTime);

        Vector3 dir = (target - transform.position).normalized;
        if (dir != Vector3.zero)
            transform.rotation = Quaternion.Slerp(transform.rotation,
                Quaternion.LookRotation(dir), turnSpeed * Time.deltaTime);

        if (Vector3.Distance(transform.position, target) < 0.3f)
        {
            PickTarget();
            waitTimer = Random.Range(1f, 4f);
        }

        // 🔒 Force goat back inside if it somehow escapes
        ClampToPen();
    }

    void PickTarget()
    {
        Vector3 center = penCenter != null ? penCenter.position : Vector3.zero;

        target = center + new Vector3(
            Random.Range(-areaSize.x / 2 + 0.5f, areaSize.x / 2 - 0.5f),  // 0.5 padding
            transform.position.y,
            Random.Range(-areaSize.z / 2 + 0.5f, areaSize.z / 2 - 0.5f)
        );
    }

    void ClampToPen()
    {
        Vector3 center = penCenter != null ? penCenter.position : Vector3.zero;
        Vector3 pos = transform.position;

        // Hard clamp — goat physically cannot leave the box
        pos.x = Mathf.Clamp(pos.x, center.x - areaSize.x / 2, center.x + areaSize.x / 2);
        pos.z = Mathf.Clamp(pos.z, center.z - areaSize.z / 2, center.z + areaSize.z / 2);

        transform.position = pos;
    }

    void OnDrawGizmosSelected()
    {
        Vector3 center = penCenter != null ? penCenter.position : Vector3.zero;
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireCube(center, new Vector3(areaSize.x, 1f, areaSize.z));
    }
}