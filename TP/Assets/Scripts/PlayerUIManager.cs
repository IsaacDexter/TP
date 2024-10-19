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
    [SerializeField] private TextMeshProUGUI m_messenger;
    [SerializeField] private TextMeshProUGUI m_timer;
    [SerializeField] private FadableImage m_blackImage;
    [SerializeField, Range(0.0f, 20.0f)] private float m_fadeDuration;

    // Start is called before the first frame update
    void Start()
    {
        m_blackImage.FadeOut(m_fadeDuration);
    }
    public void DisplayMessage(string message)
    {
        m_messenger.SetText(message);
    }
    public void DisplayMessage(TextMeshProUGUI message)
    {
        m_messenger = message;
    }
    public void DisplayMessage(string message, float duration)
    {
        CancelInvoke("ClearMessage");
        m_messenger.SetText(message);
        Invoke("ClearMessage", duration);
    }
    public void ClearMessage()
    {
        m_messenger.SetText("");
    }
    public void ClearMessage(string message)
    {
        if (m_messenger.GetParsedText() == message)
        {
            m_messenger.SetText("");
        }
    }

    public void FadeToBlack()
    {
        m_blackImage.FadeIn(m_fadeDuration);
    }
    public void FadeToBlack(float duration)
    {
        m_blackImage.FadeIn(duration);
    }
    
    public void FadeThroughBlack()
    {
        m_blackImage.FadeInAndOut(m_fadeDuration, 0.0f);
    }
}
