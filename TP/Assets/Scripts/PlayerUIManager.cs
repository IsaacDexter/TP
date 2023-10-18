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
    [Tooltip("Currently Selected Face")] public Sprite currentFace;
    private const float scareDuration = 1.8f;
    private const float messageDuration = 2.5f;
    [SerializeField] private UnityEngine.UI.Image scaredFace;
    [SerializeField] private TextMeshProUGUI messenger;
    // Start is called before the first frame update
    void Start()
    {
        currentFace = poopFaces[0];
    }

    public void Message(string message, float duration = messageDuration)
    {
        CancelInvoke("RemoveMessage");
        messenger.SetText(message);
        Invoke("RemoveMessage", duration);
    }

    private void RemoveMessage()
    {
        messenger.SetText("");
    }

    public void Scare(float duration = scareDuration)
    {
        CancelInvoke("Unscare");
        scaredFace.enabled = true;  //enable the usually disabled scared face sprite over the top of the scared faces
        Invoke("Unscare", duration);   //Invoke its hiding after the set duration
    }

    void Unscare()
    {
        scaredFace.enabled = false;
    }

    public void UpdateFace(float poop)
    {
        poop *= poopFaces.Count;    //Multiply the current poop level by the number of faces to find how far through the face should be
        int index = Math.Clamp((int)Math.Truncate(poop), 0, poopFaces.Count - 1);   //Find the index from that poop level by truncating, clamping it within the size incase poop is FULL
        currentFace = poopFaces[index]; //Set the face to the appropriate poop level
    }
}
