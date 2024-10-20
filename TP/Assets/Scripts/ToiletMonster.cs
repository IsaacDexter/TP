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
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void PlayClip(AudioClip clip)
    {
        audioSource.clip = clip;
        audioSource.Play();
        StartCoroutine(WaitForSound(audioSource));
    }

    private IEnumerator WaitForSound(AudioSource source)
    {
        while (source.isPlaying)
        {
            animator.SetTrigger("StartLidMovement");
            yield return null;
        }
        animator.SetTrigger("StopLidMovement");
    }
}
