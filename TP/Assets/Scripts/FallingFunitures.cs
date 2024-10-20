using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingFurnitures : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField, Tooltip("The object to make fall. It must have a rigidbody, and an audiosource")] protected List<GameObject> furnitures;
    [SerializeField, Tooltip("What force to apply on the object")] protected Vector3 force = Vector3.zero;
    [SerializeField, Tooltip("Where to apply the force on the object")] protected Transform position;
    [SerializeField] protected AudioSource audioSource;
    [SerializeField] protected Lightning lightning;

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
        foreach (GameObject furniture in furnitures)
        {
            Rigidbody rigidbody = furniture.GetComponent<Rigidbody>();
            rigidbody.isKinematic = false;
            rigidbody.AddRelativeForce(force);
        }
        audioSource.Play();
        lightning.Strike();
    }
}
