using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public interface InteractableObject
{
    public string InteractionPrompt { get; }
    public bool Interact(Interact interact);
}
