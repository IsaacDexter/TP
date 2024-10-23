using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueSpeaker : MonoBehaviour
{
    [SerializeField] protected AudioSource source;
    public bool IsSpeaking()
    {
        return source.isPlaying;
    }

    virtual public void Play(AudioClip clip, bool force = false)
    {
        if (force)
        {
            source.Stop();
        }
        if (!source.isPlaying)
        {
            source.PlayOneShot(clip);
        }
    }

    public void Stop()
    {
        source.Stop();
    }
}
