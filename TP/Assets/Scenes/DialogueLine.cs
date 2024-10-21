using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueLine : MonoBehaviour
{
    public AudioSource source;
    public AudioClip clip;
    public void Play(bool force = false)
    {
        if (!source.isPlaying || force)
        {
            source.PlayOneShot(clip);
        }
    }
}
