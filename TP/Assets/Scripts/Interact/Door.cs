using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.Antlr3.Runtime.Misc;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Door : InteractableObject
{
    [SerializeField] private GameObject teleportLocation;
    [SerializeField] private AudioSource openSource;
    [SerializeField] private AudioSource closedSource;
    [SerializeField] private AudioClip lockedLine;
    [SerializeField] private string lockedPrompt = "It's locked...";
    [SerializeField, Tooltip("If the door can be opened")] public bool locked = false;

    private Player player = null;
    private IEnumerator delayedTask;

    private void Start()
    {
    }

    override public bool Interact(Interact interact)
    {

        //If theres a player
        if (player != null)
        {
            //And the door Leads somewhere
            if (teleportLocation != null && !locked)
            {
                player.ui.FadeThroughBlack();
                openSource.Play();

                //teleport the player to that somewhere
                Teleport();

                return true;
            }
            //If the door leads nowhere
            else
            {
                closedSource.Play();
                player.ui.DisplayMessage(lockedPrompt, 1.0f);
                player.lines.PlaySound(lockedLine);
                //It's locked
                return false;            
            }
        }
        //The player was not close enough
        return false;
    }

    private void Teleport()
    {
        player.transform.position = teleportLocation.transform.position;
    }

    public void OnTriggerEnter(Collider other)
    {
        //if a player enters the trigger
        if (other.gameObject.name == "Player")
        {
            //Show it that it can interact
            player = other.GetComponentInParent<Player>();
            player.ui.DisplayMessage(InteractionPrompt);
        }
    }

    public void OnTriggerExit(Collider other)
    {
        //if a player exits the trigger
        if (other.gameObject.name == "Player")
        {
            //Hide its interact message
            player = other.GetComponentInParent<Player>();
            player.ui.ClearMessage(InteractionPrompt);
        }
    }
}
