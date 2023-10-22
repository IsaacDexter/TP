using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.ProBuilder;

public class FadableImage : UnityEngine.UI.Image
{
    private Queue<UnityEngine.UI.Image> transitions = new Queue<UnityEngine.UI.Image>();
    private Queue<UnityEngine.UI.Image> timedOverlays = new Queue<UnityEngine.UI.Image>();
    private Dictionary<Sprite, UnityEngine.UI.Image> overlays = new Dictionary<Sprite, UnityEngine.UI.Image>();
    public void TransitionSprite(Sprite sprite, float fadeDuration, Transform transform)
    {
        //Make a clone copy of the image in the parent.
        UnityEngine.UI.Image transition = Instantiate(this, transform);
        //Make it appear as the last sibling
        transition.transform.SetAsLastSibling();

        //store a reference to it
        ref UnityEngine.UI.Image transition_ref = ref transition;
        //Put a reference to image in the queue
        this.transitions.Enqueue(transition);

        //Set the new images's canvas renderer to be invisible, allowing crossfade alpha to function while rendering the sprite initially invisible
        transition_ref.GetComponent<CanvasRenderer>().SetAlpha(0.0f);
        //Set the new images sprite to the desired one
        transition_ref.sprite = sprite;
        //Crossfade the new image's alpha 
        transition_ref.CrossFadeAlpha(1.0f, fadeDuration, false);
        //Queue a coroutine to destroy the newImage and change the old image when the duration is up.
        StartCoroutine(FinishTransition(fadeDuration));
    }
    private IEnumerator FinishTransition(float fadeDuration)
    {
        //Delay until the transition is complete
        yield return new WaitForSeconds(fadeDuration);

        //Update this' sprite to match the temporary overlay's
        this.sprite = transitions.Peek().sprite;
        //destroy the temporary overlay
        Destroy(transitions.Dequeue().gameObject);
    }

    public void OverlaySprite(Sprite sprite, float fadeDuration, float duration, Transform transform)
    {
        //Make a clone copy of the image in the parents parent.
        UnityEngine.UI.Image timedOverlay = Instantiate(this, transform);
        //Make it appear as the last sibling
        timedOverlay.transform.SetAsLastSibling();

        //store a reference to it
        ref UnityEngine.UI.Image timedOverlay_ref = ref timedOverlay;
        //Put a reference to image in the queue
        this.timedOverlays.Enqueue(timedOverlay);

        //Set the new images's canvas renderer to be invisible, allowing crossfade alpha to function while rendering the sprite initially invisible
        timedOverlay_ref.GetComponent<CanvasRenderer>().SetAlpha(0.0f);
        //Set the new images sprite to the desired one
        timedOverlay_ref.sprite = sprite;
        //Crossfade the new image's alpha 
        timedOverlay_ref.CrossFadeAlpha(1.0f, fadeDuration, false);
        //Queue a coroutine to destroy the newImage and change the old image when the duration is up.
        StartCoroutine(FadeTimedOverlay(fadeDuration, duration));
    }
    public void OverlaySprite(Sprite sprite, float fadeDuration, Transform transform)
    {
        if (!overlays.ContainsKey(sprite))
        {
            //Make a clone copy of the image in the parents parent.
            UnityEngine.UI.Image overlay = Instantiate(this, transform);
            //Make it appear as the last sibling
            overlay.transform.SetAsLastSibling();

            //store a reference to it
            ref UnityEngine.UI.Image overlay_ref = ref overlay;

            //Put a reference to image in the dictionary
            overlays.TryAdd(sprite, overlay);
            //Set the new images's canvas renderer to be invisible, allowing crossfade alpha to function while rendering the sprite initially invisible
            overlay_ref.GetComponent<CanvasRenderer>().SetAlpha(0.0f);
            //Set the new images sprite to the desired one
            overlay_ref.sprite = sprite;
            //Crossfade the new image's alpha 
            overlay_ref.CrossFadeAlpha(1.0f, fadeDuration, false);
        }
    }
    
    public void RemoveOverlay(Sprite sprite, float fadeDuration)
    {
        //Start the overlay fading out
        if (overlays.TryGetValue(sprite, out var overlay))
        {
            StopCoroutine(FadeOverlay(sprite, fadeDuration));
            overlay.CrossFadeAlpha(0.0f, fadeDuration, false);
            StartCoroutine(FadeOverlay(sprite, fadeDuration));
        }
    }

    private IEnumerator FadeOverlay(Sprite sprite, float fadeDuration)
    {
        //Delay until the fade out is complete
        yield return new WaitForSeconds(fadeDuration);

        //if the overlay exists
        if (overlays.TryGetValue(sprite, out var overlay))
        {
            //destroy it
            Destroy(overlay.gameObject);
            overlays.Remove(sprite);
        }
    }
    
    private IEnumerator FadeTimedOverlay(float fadeDuration, float duration)
    {
        //Delay until the fade in is complete, and for the scare to be on screen for its duration
        yield return new WaitForSeconds(fadeDuration + duration);

        //Start the overlay fading out
        timedOverlays.Peek().CrossFadeAlpha(0.0f, fadeDuration, false);
        //Set the overlay to be deleted once the fade out is complete
        StartCoroutine(RemoveTimedOverlay(fadeDuration));
    }
    
    private IEnumerator RemoveTimedOverlay(float fadeDuration)
    {
        //Delay until the fade out is complete
        yield return new WaitForSeconds(fadeDuration);

        //destroy the overlay
        Destroy(timedOverlays.Dequeue().gameObject);
    }
}
