using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.UIElements;

public class PlayerUIManager : MonoBehaviour
{
    [SerializeField, Tooltip("List for the scared faces")] private List<Sprite> poopFaces;
    [SerializeField] private UnityEngine.UI.Image poopFace;
    [SerializeField] private UnityEngine.UI.Image scaredFace;

    private const float scareDuration = 1.8f;
    private const float fadeDuration = 0.18f;

    [SerializeField] private TextMeshProUGUI messenger;
    // Start is called before the first frame update
    void Start()
    {
        poopFace.sprite = poopFaces[0];
        scaredFace.color = Color.black;
    }

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

    public void ShowScaredFace(float duration = scareDuration)
    {
        Debug.Log("Showed Scared face");
        CancelInvoke("HideScaredFace");
        scaredFace.CrossFadeColor(Color.white, fadeDuration, false, true);
        Invoke("HideScaredFace", duration);   //Invoke its hiding after the set duration
    }

    void HideScaredFace()
    {
        Debug.Log("Hid Scared face");
        scaredFace.CrossFadeColor(Color.clear, fadeDuration, false, true);
    }

    public void UpdateFace(float poop)
    {
        poop *= poopFaces.Count;    //Multiply the current poop level by the number of faces to find how far through the face should be
        int index = Math.Clamp((int)Math.Truncate(poop), 0, poopFaces.Count - 1);   //Find the index from that poop level by truncating, clamping it within the size incase poop is FULL
        poopFace.sprite = poopFaces[index]; //Set the face to the appropriate poop level
    }
}
