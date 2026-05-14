using UnityEngine;

public class ChickenSound : MonoBehaviour
{
    private AudioSource horseAudio;

    void Start()
    {
        horseAudio = GetComponent<AudioSource>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.C))
        {
            horseAudio.Play();
        }
    }
}
