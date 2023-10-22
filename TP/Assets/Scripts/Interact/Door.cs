using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : InteractableObject
{
    [SerializeField] private GameObject teleportLocation;
    private GameObject player;
    [SerializeField]private AudioSource doorOpen;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        //doorOpen = GetComponentInChildren<AudioSource>();
    }

    override public bool Interact(Interact interact)
    {
        player.transform.position = teleportLocation.transform.position;
        
        //add transition + sfx :)
        doorOpen.Play();
        
        return true;
    }

    public void OnTriggerEnter(Collider other)
    {
        //if a player enters the trigger
        if (other.gameObject.name == "Player")
        {
            //Show it that it can interact
            Player player = other.GetComponentInParent<Player>();
            player.ui.DisplayMessage(InteractionPrompt);
        }
    }

    public void OnTriggerExit(Collider other)
    {
        //if a player exits the trigger
        if (other.gameObject.name == "Player")
        {
            //Hide its interact message
            Player player = other.GetComponentInParent<Player>();
            player.ui.ClearMessage(InteractionPrompt);
        }
    }
}
