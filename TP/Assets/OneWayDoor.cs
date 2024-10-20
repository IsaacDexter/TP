using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityStandardAssets.Utility;

public class OneWayDoor : MonoBehaviour
{
    [SerializeField] private AudioSource m_audioSource = null;
    [SerializeField] private AudioClip m_clip = null;
    [SerializeField] private Animator m_animator = null;
    [SerializeField] private bool m_isOpenTrigger = true;
    [SerializeField] private Collider m_otherTrigger = null;
    // Start is called before the first frame update

    public void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            if (m_isOpenTrigger)
            {
                Open();
            }
            else
            {
                Close();
            }
            gameObject.SetActive(false);
            m_otherTrigger.gameObject.SetActive(true);
        }

    }

    public void Open()
    {
        m_animator.Play("DoorOpen", 0, 0.0f);
        m_audioSource.PlayOneShot(m_clip);
    }

    public void Close()
    {
        m_animator.Play("DoorClose", 0, 0.0f);
        m_audioSource.PlayOneShot(m_clip);
    }
}
