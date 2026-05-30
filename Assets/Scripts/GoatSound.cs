using UnityEngine;

public class GoatSound : MonoBehaviour
{
    private AudioSource goatAudio;

    void Start()
    {
        goatAudio = GetComponent<AudioSource>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.G))
        {
            goatAudio.Play();
        }
    }
}