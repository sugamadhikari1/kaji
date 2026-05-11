using UnityEngine;

public class CropInteraction : MonoBehaviour
{
    public GameObject harvestedVersion;

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player") && Input.GetKeyDown(KeyCode.E))
        {
            harvestedVersion.SetActive(true);
            gameObject.SetActive(false);
        }
    }
}