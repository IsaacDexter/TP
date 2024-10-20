using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.Mathematics;
using Unity.VisualScripting;
using UnityEngine;

public class Footsteps : MonoBehaviour
{
    private Footstep[] m_footsteps;
    [SerializeField, Range(0.0f, 10.0f)] private float m_maxFloorDistance = 2.0f;

    [SerializeField, Range(0.0f, 10.0f)] private float m_frequency = 0.5f;
    private float m_timeSince = 0.0f;

    [SerializeField] private AudioSource m_audioSource = null;

    private Footstep m_footstep;

    private CharacterController m_characterController = null;


    // Start is called before the first frame update
    void Start()
    {
        m_characterController = GetComponent<CharacterController>();
        m_footsteps = GetComponents<Footstep>();
        m_footstep = m_footsteps.First();
    }

    // Update is called once per frame
    void Update()
    {
        if (m_characterController.velocity.sqrMagnitude > 0.0f)
        m_timeSince += Time.deltaTime;
        if(m_timeSince > m_frequency)
        {
            Step();
            m_timeSince = 0.0f;
        }
    }

    public void Step()
    {
        if (m_characterController.isGrounded)
        {
            UpdateFootstepClips();
            AudioClip footstepClip = GetFootstepClip();
            m_audioSource.pitch = m_footstep.GetPitch();
            m_audioSource.PlayOneShot(footstepClip);
        }
    }

    private AudioClip GetFootstepClip()
    {
        int index = UnityEngine.Random.Range(0, m_footstep.clips.Count - 1);
        return m_footstep.clips[index];
    }

    private bool UpdateFootstepClips()
    {
        RaycastHit hit;
        Ray ray = new Ray(gameObject.transform.position, -gameObject.transform.up);
        if (!Physics.Raycast(ray, out hit, m_maxFloorDistance, gameObject.layer))
        {
            return false;
        }
        PhysicMaterial sharedMaterial = hit.collider.sharedMaterial;
        if (sharedMaterial == null)
        {
            return false;
        }
 
        if (sharedMaterial.Equals(m_footstep.material))
        {
            return false;
        }

        Footstep found = Array.Find(m_footsteps, pmfc => pmfc.material.Equals(sharedMaterial));
        if (found == null)
        {
            return false;
        }

        m_footstep = found;
        return true;
    }
}
