using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Toilet : InteractableObject
{
    private GameObject player;
    private PlayerStatManager stats;
    private PlayerUIManager ui;

    private AudioSource flushSFX;

    // Start is called before the first frame update
    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        stats = player.GetComponent<PlayerStatManager>();
        ui = player.GetComponentInChildren<PlayerUIManager>();
        flushSFX = GetComponent<AudioSource>();
    }

    override public bool Interact(Interact interact)
    {
        Debug.Log("interacted");
        //sit player on toilet
        

        //reset poop bar
        stats.SetPoop(0.0f);

        //play flush sfx
        flushSFX.Play();

        //list stats and increases 
        ui.ClearMessage();
        ui.DisplayMessage(stats.GetStatIncreases());
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
