using UnityEngine;

public class GoatSound : MonoBehaviour
{
    private AudioSource horseAudio;

    void Start()
    {
        horseAudio = GetComponent<AudioSource>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.G))
        {
            horseAudio.Play();
        }
    }
}