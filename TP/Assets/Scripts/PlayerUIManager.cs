using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.UIElements;

public class PlayerUIManager : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private FadableImage face;
    [SerializeField, Tooltip("These should be siblings with the face, so use the face's parent")] private Transform transitionTransform;
    [SerializeField, Tooltip("These should be siblings with the parent of the face, so use the face's parent's parent")] private Transform overlayTransform;
    [SerializeField] private TextMeshProUGUI messenger;
    [SerializeField] private UnityEngine.UI.Image poopSlider;


    [Header("Sprites")]
    [SerializeField, Tooltip("List of sprites for the pooping stages")] private List<Sprite> poopFaces;
    [SerializeField, Tooltip("sprite for the scared stage")] private Sprite scaredFace;
    [SerializeField, Tooltip("sprite for running")] private Sprite runningFace;
    [SerializeField, Tooltip("Colour of running bar")] private Color runningColor;
    [SerializeField, Tooltip("Colour of poop bar")] private Color poopColor;

    [Header("Transitions")]
    [SerializeField, Range(0.0f, 5.0f), Tooltip("How long to display the scared face")] private float scaredDuration = 1.5f;
    [SerializeField, Range(0.0f, 5.0f), Tooltip("How quick to fade in/out the scared face")] private float scaredFadeDuration = 0.25f;
    [SerializeField, Range(0.0f, 5.0f), Tooltip("How quick to fade between the poop stages")] private float poopFadeDuration = 0.5f;
    /// <summary>The current face's index, with the default being the starting index. stored for early outs.</summary>
    private int currentIndex = 0;

    // Start is called before the first frame update
    void Start()
    {
        poopSlider.color = poopColor;
        //Set the face and the face to the default
        face.sprite = poopFaces[currentIndex];}

    public void DisplayMessage(string message)
    {
        messenger.SetText(message);
    }
    public void DisplayMessage(string message, float duration)
    {
        CancelInvoke("ClearMessage");
        messenger.SetText(message);
        Invoke("ClearMessage", duration);
    }
    public void ClearMessage()
    {
        messenger.SetText("");
    }
    public void ClearMessage(string message)
    {
        if (messenger.GetParsedText() == message)
        {
            messenger.SetText("");
        }
    }

    public void ShowScaredFace()
    {
        face.OverlaySprite(scaredFace, scaredFadeDuration, scaredDuration, overlayTransform);
    }
    
    public void ToggleRunningFace()
    {
        face.ToggleOverlaySprite(runningFace, scaredFadeDuration, overlayTransform);
        if(poopSlider.color == poopColor)
        {
            poopSlider.color = runningColor;
        }
        else
        {
            poopSlider.color = poopColor;
        }
    }

    public void UpdateFace(float poop)
    {
        //find the new index by finding how far through the indexes the poop, is and truncating
        int newIndex = (int)Math.Truncate(poop * poopFaces.Count);
        //if a change needs to be made
        if (newIndex != currentIndex)
        {
            currentIndex = Math.Min(newIndex, poopFaces.Count - 1);
            //Clone the transition face.
            face.TransitionSprite(poopFaces[currentIndex], poopFadeDuration, transitionTransform);
        } 
    }
}
