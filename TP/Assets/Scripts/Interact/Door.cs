using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.Antlr3.Runtime.Misc;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Door : InteractableObject
{
    [SerializeField] private string sceneName;
    [SerializeField] private AudioSource openSource;
    [SerializeField] private AudioSource closedSource;
    [SerializeField] private AudioClip lockedLine;
    [SerializeField] private string lockedPrompt = "It's locked...";
    [SerializeField, Tooltip("If the door can be opened")] public bool locked = false;

    private Player player = null;

    override public bool Interact(Interact interact)
    {
        if (player == null)
        {
            return false;
        }
        if (sceneName == null || locked)
        {
            closedSource.Play();
            player.ui.DisplayMessage(lockedPrompt, 1.0f);
            player.lines.PlaySound(lockedLine);
        }

        player.ui.FadeThroughBlack();
        openSource.Play();
        SceneManager.LoadScene(sceneName);
        return true;
    }

    public void OnTriggerEnter(Collider other)
    {
        //if a player enters the trigger
        if (other.CompareTag("Player"))
        {
            //Show it that it can interact
            player = other.GetComponentInParent<Player>();
            player.ui.DisplayMessage(InteractionPrompt);
        }
    }

    public void OnTriggerExit(Collider other)
    {
        //if a player exits the trigger
        if (other.CompareTag("Player"))
        {
            //Hide its interact message
            player = other.GetComponentInParent<Player>();
            player.ui.ClearMessage(InteractionPrompt);
        }
    }
}
