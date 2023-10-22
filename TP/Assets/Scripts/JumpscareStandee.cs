using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpscareStandee : MonoBehaviour
{
    [SerializeField, Range(0.0f, 1.0f), Tooltip("The amount of poop to increase the scaree by.")] private float poopIncrease = 0.0f;
    private AudioSource scareSound;

    private void Start()
    {
        scareSound = GetComponent<AudioSource>();
    }

    public void OnTriggerEnter(Collider other)
    {
        //if a player enters the trigger
        if(other.gameObject.name == "Player")   
        {
            Player player = other.GetComponentInParent<Player>();
            player.Scare(poopIncrease);
            scareSound.Play();
        }
        GetComponent<Collider>().enabled = false;
    }
}
