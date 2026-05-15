using UnityEngine;

public class PlayerInteraction : MonoBehaviour
{
    public float interactDistance = 3f;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.L))
        {
            Ray ray = new Ray(transform.position, transform.forward);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit, interactDistance))
            {
                GateInteraction gate = hit.collider.GetComponent<GateInteraction>();

                if (gate != null)
                {
                    gate.ToggleGate();
                }
            }
        }
    }
}
