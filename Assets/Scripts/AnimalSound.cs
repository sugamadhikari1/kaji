using UnityEngine;

public class AnimalSound : MonoBehaviour
{
    private AudioSource horseAudio;

    void Start()
    {
        horseAudio = GetComponent<AudioSource>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.H))
        {
            horseAudio.Play();
        }
    }
}