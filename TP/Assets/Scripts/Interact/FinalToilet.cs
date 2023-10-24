using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinalToilet : InteractableObject
{
    private Player player;
    private AudioSource flushSFX;
    [SerializeField, Tooltip("The players outro dialogue")] AudioClip finalLine;
    private bool interacted = false;

    // Start is called before the first frame update
    private void Start()
    {
        flushSFX = GetComponent<AudioSource>();
    }

    override public bool Interact(Interact interact)
    {
        if (!interacted)
        {
            interacted = true;
            //reset poop bar
            player.stats.SetPoop(0.0f);

            //play flush sfx
            flushSFX.Play();
            player.lines.PlaySound(finalLine);
            player.ui.FadeToBlack(finalLine.length);
            StartCoroutine(QuitAfterDelay(finalLine.length));

        }
        return interacted;
    }

    IEnumerator QuitAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);

        Debug.Log("Quiting...");
        Application.Quit();
    }

    public void OnTriggerEnter(Collider other)
    {
        //if a player enters the trigger
        if (other.gameObject.name == "Player")
        {
            //Show it that it can interact
            player = other.GetComponentInParent<Player>();
            player.ui.DisplayMessage(InteractionPrompt);
        }
    }

    public void OnTriggerExit(Collider other)
    {
        //if a player exits the trigger
        if (other.gameObject.name == "Player")
        {
            //Hide its interact message
            player = other.GetComponentInParent<Player>();
            player.ui.ClearMessage(InteractionPrompt);
        }
    }
}
