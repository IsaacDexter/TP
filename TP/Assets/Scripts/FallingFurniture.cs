using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingFurniture : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField, Tooltip("The object to make fall. It must have a rigidbody, and an audiosource")] protected GameObject furniture;
    [SerializeField, Tooltip("What force to apply on the object")] protected Vector3 force = Vector3.zero;
    [SerializeField, Tooltip("Where to apply the force on the object")] protected Transform position;
    protected Rigidbody furnitureRigidbody;
    protected AudioSource furnitureAudioSource;
    void Start()
    {
        furnitureRigidbody = furniture.GetComponent<Rigidbody>();
        furnitureAudioSource = furniture.GetComponent<AudioSource>();
    }

    protected void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "Player")
        {
            Fall();
            GetComponent<BoxCollider>().enabled = false;
        }
    }

    protected virtual void Fall()
    {
        furnitureRigidbody.isKinematic = false;
        
        furnitureRigidbody.AddRelativeForce(force);
        furnitureAudioSource.Play();
    }
}
