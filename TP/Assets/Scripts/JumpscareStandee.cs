using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpscareStandee : MonoBehaviour
{
    [SerializeField, Range(0.0f, 1.0f), Tooltip("The amount of poop to increase the scaree by.")] private float poopIncrease = 0.0f;
    [SerializeField, Tooltip("Whether the scare has already been triggered")] private bool triggered = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnTriggerEnter(Collider other)
    {
        //if a player enters the trigger
        if(other.gameObject.name == "Player")   
        {
            Player player = other.GetComponentInParent<Player>();
            player.Scare(poopIncrease);
        }
    }
}
