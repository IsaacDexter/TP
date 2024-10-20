using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AdjustVolume : MonoBehaviour
{
    public AudioSource audioSource;
    [Range(0.0f, 5.0f)] public float volume = 1.0f;
    private float audioSourceVolume = 0.0f;
    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            audioSourceVolume = audioSource.volume;
            audioSource.volume = volume;
        }
    }

    public void OnTriggerExit(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            audioSource.volume = audioSourceVolume;
        }
    }
}
