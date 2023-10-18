using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class InteractableObject : MonoBehaviour
{
    public string InteractionPrompt;
    virtual public bool Interact(Interact interact)
    {
        return false;
    }
}
