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
                player.Blink();
                openSource.Play();

                //teleport the player to that somewhere
                Teleport(player.ui.scaredFadeDuration);

                return true;
            }
            //If the door leads nowhere
            else
            {
                closedSource.Play();
                player.ui.DisplayMessage(lockedPrompt, 1.0f);
                //It's locked
                return false;            
            }
        }
        //The player was not close enough
        return false;
    }

    private IEnumerator TeleportAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);

        player.transform.position = teleportLocation.transform.position;
        delayedTask = null;
    }

    private void Teleport(float delay)
    {
        if (player.stats.PlayerUsedToilet)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1); //if player used toilet, door takes them to next level
        }
        //Prevent double teleport
        if (delayedTask == null)
        {
            delayedTask = TeleportAfterDelay(delay);
            StartCoroutine(delayedTask);
        }

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
