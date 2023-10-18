using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour, InteractableObject
{
    [SerializeField] private string interactPrompt;
    [SerializeField] private GameObject teleportLocation;
    private GameObject player;
    public string InteractionPrompt { get; }

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    public bool Interact(Interact interact)
    {
        Debug.Log("Open door"); //add ui text for this

        player.transform.position = teleportLocation.transform.position;
        
        //add transition + sfx :)
        
        return true;
    }
}
