using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lightning : MonoBehaviour
{
    [SerializeField] 
    private List<Light> m_lights;
    [SerializeField, Range(0.0f, 300.0f)] 
    private float m_minInterval;
    [SerializeField, Range(0.0f, 300.0f)] 
    private float m_maxInterval;
    [SerializeField, Range(0.0f, 30.0f)] 
    private float m_duration;
    [SerializeField, Range(0.0f, 5.0f)] 
    private float m_intensity;

    [SerializeField] 
    protected AudioSource m_audioSource;
    [SerializeField] 
    private List<AudioClip> m_lightningClips;



    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Flash());
    }

    public IEnumerator Flash()
    {
        float interval = Random.Range(m_minInterval, m_maxInterval);
        while (enabled)
        {
            yield return new WaitForSeconds(interval);

            foreach (Light light in m_lights)
            {
                light.intensity = m_intensity;
            }

            int clipIndex = Random.Range(0, m_lightningClips.Count);
            m_audioSource.clip = m_lightningClips[clipIndex];
            m_audioSource.Play();

            yield return new WaitForSeconds(m_duration);

            foreach (Light light in m_lights)
            {
                light.intensity = 0.0f;
            }

            interval = Random.Range(m_minInterval, m_maxInterval);
        }
    }
}
