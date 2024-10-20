using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Footstep : MonoBehaviour
{
    public List<AudioClip> clips;
    public PhysicMaterial material;
    [SerializeField, Range(-3.0f, 3.0f)] private float pitchVariationRange = 0.2f;
    [SerializeField, Range(-3.0f, 3.0f)] private float pitch = 1.0f;
    public float GetPitch()
    {
        float pitchVariation = 0.0f;
        if (pitchVariationRange != 0.0f)
        {
            pitchVariation = UnityEngine.Random.Range(-pitchVariationRange, pitchVariationRange);
        }
        return pitch + pitchVariation;
    }
}
