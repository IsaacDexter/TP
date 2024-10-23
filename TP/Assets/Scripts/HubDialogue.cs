using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HubDialogue : Dialogue
{
    [SerializeField] private string CorrespondingScene;

    override public void Play()
    {
        if (PlayerPrefs.GetString("lastScene") == CorrespondingScene)
        {
            base.Play();
        }
    }
}
