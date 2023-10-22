using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Door : InteractableObject
{
    [SerializeField] private GameObject teleportLocation;
    private GameObject player;
    [SerializeField]private AudioSource doorOpen;
    private PlayerStatManager stats;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        stats = player.GetComponent<PlayerStatManager>();
    }

    override public bool Interact(Interact interact)
    {
        if(stats.PlayerUsedToilet)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1); //if player used toilet, door takes them to next level
        }
        else
        {
            player.transform.position = teleportLocation.transform.position;
        
            //add transition + sfx :)
            doorOpen.Play();
        }

        
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
