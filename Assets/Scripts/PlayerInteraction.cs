using UnityEngine;

public class PlayerInteraction : MonoBehaviour
{
    public float interactDistance = 3f;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.L))
        {
            Collider[] hits = Physics.OverlapSphere(transform.position, interactDistance);
            foreach (Collider hit in hits)
            {
                GateInteraction gate = hit.GetComponent<GateInteraction>();
                if (gate != null)
                {
                    gate.ToggleGate();
                }
            }
        }
    }
}
