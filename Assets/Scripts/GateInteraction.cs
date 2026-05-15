using UnityEngine;

public class GateInteraction : MonoBehaviour
{
    public bool isOpen = false;

    public Vector3 closedRotation;
    public Vector3 openRotation;

    public float speed = -2f;

    private Quaternion targetRotation;

    void Start()
    {
        closedRotation = transform.eulerAngles;
        targetRotation = Quaternion.Euler(closedRotation);
    }

    void Update()
    {
        transform.rotation = Quaternion.Lerp(
            transform.rotation,
            targetRotation,
            Time.deltaTime * speed
        );
    }

    public void ToggleGate()
    {
        isOpen = !isOpen;

        if (isOpen)
        {
            targetRotation = Quaternion.Euler(openRotation);
        }
        else
        {
            targetRotation = Quaternion.Euler(closedRotation);
        }
    }
}