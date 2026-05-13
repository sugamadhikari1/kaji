using UnityEngine;

public class TractorWaypoints : MonoBehaviour
{
    public Transform[] waypoints;
    public float speed = 5f;
    public float turnSpeed = 3f;
    public float waypointRadius = 1f;

    private int currentWaypoint = 0;
    private bool isRunning = false;
    private bool isDone = false;

    void Update()
    {
        // Press E to start
        if (Input.GetKeyDown(KeyCode.E) && !isDone)
        {
            isRunning = !isRunning; // toggle on/off

            if (isRunning)
                Debug.Log("Ploughing Started!");
            else
                Debug.Log("Ploughing Paused!");
        }

        if (!isRunning) return;
        if (waypoints.Length == 0) return;

        // All waypoints done
        if (currentWaypoint >= waypoints.Length)
        {
            isRunning = false;
            isDone = true;
            Debug.Log("Ploughing Complete!");
            return;
        }

        Transform target = waypoints[currentWaypoint];
        Vector3 direction = (target.position - transform.position).normalized;

        transform.position += direction * speed * Time.deltaTime;

        Quaternion lookRot = Quaternion.LookRotation(direction);
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRot, turnSpeed * Time.deltaTime);

        if (Vector3.Distance(transform.position, target.position) < waypointRadius)
        {
            currentWaypoint++;
        }
    }
}