using System.Collections;
using System.Collections.Generic;
using System.Net.Sockets;
using UnityEngine;

public class PlayerLineInteract : InteractableObject
{
    private Player player = null;
    [SerializeField] AudioClip line;
    private bool lineSaid = false;
    override public bool Interact(Interact interact)
    {
        //If theres a player
        if (player != null && !lineSaid)
        {
            player.lines.PlaySound(line);
            lineSaid = true;
            return true;
        }
        return false;
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
