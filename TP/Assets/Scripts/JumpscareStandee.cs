using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpscareStandee : MonoBehaviour
{
    [SerializeField, Range(0.0f, 1.0f), Tooltip("The amount of poop to increase the scaree by.")] private float poopIncrease = 0.0f;
    private AudioSource scareSound;
    [SerializeField] private Animator anim;
    [SerializeField, Tooltip("False for wall, true for floor")] bool wallOrFloor;

    private void Start()
    {
        scareSound = GetComponent<AudioSource>();
        anim = GetComponentInChildren<Animator>();
    }

    public void OnTriggerEnter(Collider other)
    {
        //if a player enters the trigger
        if(other.gameObject.name == "Player")   
        {
            //play anim
            if(wallOrFloor)
            {
                anim.SetTrigger("FlipUp");
            }
            else
            {
                anim.SetTrigger("FlipWall");
            }

            Player player = other.GetComponentInParent<Player>();
            player.Scare(poopIncrease);
            scareSound.Play();
        }
        GetComponent<Collider>().enabled = false;
    }
}
