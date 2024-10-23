using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueLine : MonoBehaviour
{
    [SerializeField] private DialogueSpeaker speaker;
    [SerializeField] private AudioClip clip;
    [SerializeField] private bool force;
    public void Play()
    {
        speaker.Play(clip, force);
    }

    public void Stop()
    {
        speaker.Stop();
    }

    public float GetLength()
    {
        return clip.length;
    }
}
