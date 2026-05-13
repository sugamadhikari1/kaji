using UnityEngine;

public class FarmerSteering : MonoBehaviour
{
    public Transform tractor;
    public float tiltAmount = 15f;

    private Vector3 lastPos;

    void Start()
    {
        lastPos = tractor.position;
    }

    void Update()
    {
        Vector3 moveDir = tractor.position - lastPos;

        // Tilt body slightly into turns
        float turnAmount = Vector3.Dot(moveDir.normalized, tractor.right);
        transform.localRotation = Quaternion.Euler(0, 0, -turnAmount * tiltAmount);

        lastPos = tractor.position;
    }
}