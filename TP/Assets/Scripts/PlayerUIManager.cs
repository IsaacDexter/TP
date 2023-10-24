using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
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
    private IEnumerator poopSliderFadeRoutine;
    [SerializeField] private FadableImage blackscreen;
    [SerializeField] private FadableImage gameOverScreen;
    [SerializeField] private FadableImage hurtScreen;
    [SerializeField] private FadableImage MashImg;


    [Header("Sprites")]
    [SerializeField, Tooltip("List of sprites for the pooping stages")] private List<Sprite> poopFaces;
    [SerializeField, Tooltip("sprite for the scared stage")] private Sprite scaredFace;
    [SerializeField, Tooltip("sprite for running")] private Sprite runningFace;
    [SerializeField, Tooltip("sprite for turtlenecking")] private Sprite turtleneckingFace;
    [SerializeField, Tooltip("Colour of running bar")] private UnityEngine.Color runningColor;
    [SerializeField, Tooltip("Colour of poop bar")] private UnityEngine.Color poopColor;
    [SerializeField, Tooltip("Colour of turtlenecking bar")] private UnityEngine.Color turtleneckingColor;

    [Header("Transitions")]
    [SerializeField, Range(0.0f, 5.0f), Tooltip("How long to display the scared face")] private float scaredDuration = 1.5f;
    [SerializeField, Range(0.0f, 5.0f), Tooltip("How quick to fade in/out the scared face")] public float scaredFadeDuration = 0.25f;
    [SerializeField, Range(0.0f, 5.0f), Tooltip("How quick to fade between the poop stages")] private float poopFadeDuration = 0.5f;
    /// <summary>The current face's index, with the default being the starting index. stored for early outs.</summary>
    private int currentIndex = 0;

    // Start is called before the first frame update
    void Start()
    {
        poopSlider.color = poopColor;
        //Set the face and the face to the default
        face.sprite = poopFaces[currentIndex];
        blackscreen.FadeOut(scaredFadeDuration);
        gameOverScreen.FadeOut(0.0f);
        hurtScreen.FadeOut(0.0f);
        MashImg.FadeOut(0.0f);
    }
    public void DisplayMessage(string message)
    {
        messenger.SetText(message);
    }
    public void DisplayMessage(TextMeshProUGUI message)
    {
        messenger = message;
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
    
    public void ShowRunningFace()
    {
        face.OverlaySprite(runningFace, scaredFadeDuration, overlayTransform);
        FadeBar(runningColor, scaredFadeDuration);
    }
    
    public void HideRunningFace()
    {
        face.RemoveOverlay(runningFace, scaredFadeDuration);
        FadeBar(poopColor, scaredFadeDuration);
    }
    
    public void ShowTurtleneckingFace()
    {
        face.OverlaySprite(turtleneckingFace, scaredFadeDuration, overlayTransform);
        FadeBar(turtleneckingColor, scaredFadeDuration);
    }
    
    public void HideTurtleneckingFace()
    {
        face.RemoveOverlay(turtleneckingFace, scaredFadeDuration);
        FadeBar(poopColor, scaredFadeDuration);
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

    private IEnumerator FadeColor(UnityEngine.UI.Image image, UnityEngine.Color startColor, UnityEngine.Color color, float duration, float timer)
    {
        while (image.color != color)
        {
            timer += Time.deltaTime;
            image.color = UnityEngine.Color.Lerp(startColor, color, timer / duration);
            yield return null;
        }
    }

    private void FadeBar(UnityEngine.Color color, float duration)
    {
        if (poopSliderFadeRoutine != null)
        {
            StopCoroutine(poopSliderFadeRoutine);
        }
        poopSliderFadeRoutine = FadeColor(poopSlider, poopSlider.color, color, duration, 0.0f);
        StartCoroutine(poopSliderFadeRoutine);
    }

    public void FadeToBlack()
    {
        blackscreen.FadeIn(scaredDuration);
    }
    public void FadeToBlack(float duration)
    {
        blackscreen.FadeIn(duration);
    }
    
    public void FadeThroughBlack()
    {
        blackscreen.FadeInAndOut(scaredFadeDuration, 0.0f);
    }

    public void ShowGameOver()
    {
        gameOverScreen.FadeIn(scaredDuration);
    }

    public void ShowHurtScreen(float fadeDuration)
    {
        hurtScreen.FadeIn(fadeDuration);
    }
    
    public void HideHurtScreen()
    {
        hurtScreen.FadeOut(scaredDuration);
    }

    public void ShowMashImg(float fadeDuration)
    {
        MashImg.FadeIn(fadeDuration);
    }

    public void HideMashImg()
    {
        MashImg.FadeOut(scaredFadeDuration);
    }
}
