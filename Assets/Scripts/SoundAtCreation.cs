using UnityEngine;

public class SoundAtCreation : MonoBehaviour
{
    public AudioClip soundAtCreation;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        AudioSource.PlayClipAtPoint(soundAtCreation, transform.position, 1f);
    }
}
