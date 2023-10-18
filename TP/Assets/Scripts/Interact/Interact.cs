using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Interact : MonoBehaviour
{
    [SerializeField] private Transform interaction;
    [SerializeField] private float interactionRadius;
    [SerializeField] private LayerMask interactLayer;

    private readonly Collider[] colliders = new Collider[3];
    [SerializeField] private int _numfound;

    // Update is called once per frame
    void Update()
    {
        _numfound = Physics.OverlapSphereNonAlloc(interaction.position, interactionRadius, colliders, 
            interactLayer);    //check how many interactable objects are in range
        
        if (_numfound > 0)
        {
            var interactable = colliders[0].GetComponent<InteractableObject>();  //get interactable object

            if (interactable != null && Input.GetKey(KeyCode.E)) //if there is an object and we press E, interact!
            {
                interactable.Interact(this);
            }
        }
         
    }
}
