using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour, InteractableObject
{
    [SerializeField] private string interactPrompt;

    public string InteractionPrompt { get; }

    public bool Interact(Interact interact)
    {
        Debug.Log("Open door");
        return true;
    }
}
