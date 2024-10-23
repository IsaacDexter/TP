using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToiletDialogueSpeaker : DialogueSpeaker
{
    [SerializeField] private ToiletMonster toiletMonster;
    [SerializeField] private bool isFlushable = true;

    override public void Play(AudioClip clip, bool force = false)
    {
        if (force)
        {
            source.Stop();
        }
        if (!source.isPlaying)
        {
            toiletMonster.PlayClip(clip, isFlushable);
        }
    }
}
