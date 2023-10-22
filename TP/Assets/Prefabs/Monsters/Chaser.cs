using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class Chaser : MonoBehaviour
{
    [SerializeField, Tooltip("A collection of empties, marking out a path")] private List<GameObject> waypoints;
    private int index = 0;
    [SerializeField, Range(0.0f, 10.0f), Tooltip("The speed of the chaser")] private float speed;
    [SerializeField, Range(0.0f, 1.0f), Tooltip("how much poop to bestow upon the player")] private float poop;
    //How far from the waypoint must the chaser be before it's hit it
    private const float sqrDistance = 1.0f;

    private AudioSource audioSource;

    private GameObject destination = null;
    private Vector3 direction = Vector3.zero;

    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        if (waypoints.Count > 0)
        {
            destination = waypoints[0];
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (destination != null)
        {
            //Find the vector to the destination
            direction = destination.transform.position - transform.position;
            //if we've reached our destination
            if (direction.sqrMagnitude < sqrDistance)
            {
                //move onto the next if it exists
                index++;
                if (index < waypoints.Count)
                {
                    destination = waypoints[index];
                }
                else
                {
                    destination = null;
                }
            }
            
            direction = direction.normalized;
            transform.position += Time.deltaTime * speed * direction;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Hit summit");
        //If we've hit the player
        if (other.gameObject.name == "Player")
        {
            Debug.Log("Hit Player");
            Player player = other.GetComponentInParent<Player>();
            player.Scare(poop);
            audioSource.Play();
        }
    }
}
