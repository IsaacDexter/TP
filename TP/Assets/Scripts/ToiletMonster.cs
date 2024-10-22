using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToiletMonster : MonoBehaviour
{
    private Animator animator;
    private AudioSource audioSource;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        audioSource = GetComponentInChildren<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void PlayClip(AudioClip clip, bool small = false)
    {
        audioSource.PlayOneShot(clip);
        if (small)
        {
            animator.SetTrigger("StartLidMovementSmall");

        }
        else
        {
            animator.SetTrigger("StartLidMovement");
        }
        StartCoroutine(StopAnimationAfterSound(clip));
    }

    private IEnumerator StopAnimationAfterSound(AudioClip clip)
    {
        yield return new WaitForSeconds(clip.length);
        animator.SetTrigger("StopLidMovement");
    }
}
