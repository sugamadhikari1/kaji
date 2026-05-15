using UnityEngine;

public class PlayerFeed : MonoBehaviour
{
    public float interactDistance = 3f;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            Ray ray = new Ray(transform.position, transform.forward);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit, interactDistance))
            {
                if (hit.collider.CompareTag("Food"))
                {
                    Destroy(hit.collider.gameObject); // eat food

                    Debug.Log("Food given to buffalo");
                }

                Buffalo buffalo = hit.collider.GetComponentInParent<Buffalo>();

                if (buffalo != null)
                {
                    buffalo.Feed(20f);
                }
            }
        }
    }
}