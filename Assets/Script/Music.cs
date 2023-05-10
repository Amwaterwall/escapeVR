using UnityEngine;

public class Music : MonoBehaviour
{
    public AudioSource musicSource;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            musicSource.Play();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            musicSource.Stop();
        }
    }
}