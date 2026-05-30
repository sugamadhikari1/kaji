using UnityEngine;

public class ChickenSound : MonoBehaviour
{
    private AudioSource chickenAudio;

    void Start()
    {
        chickenAudio = GetComponent<AudioSource>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.C))
        {
            chickenAudio.Play();
        }
    }
}
