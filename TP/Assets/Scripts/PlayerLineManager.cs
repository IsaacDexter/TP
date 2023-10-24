using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLineManager : MonoBehaviour
{
    [SerializeField] private AudioSource backgroundMusic;
    [SerializeField] private float backgroundMusicVolume;
    [SerializeField] private float backgroundMusicAttenuatedVolume;
    [SerializeField] private List<AudioClip> turtleneckingLines;
    private AudioSource audioSource;

    private IEnumerator attenuationCoroutine = null;
    // Start is called before the first frame update
    void Start()
    {
        audioSource = gameObject.GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private IEnumerator Attenuate(float duration)
    {
        yield return new WaitForSeconds(duration);

        backgroundMusic.volume = backgroundMusicVolume;
    }

    public void PlaySound(AudioClip sound)
    {
        //Cut away previous attenuation
        if(attenuationCoroutine != null)
        {
            StopCoroutine(attenuationCoroutine);
        }

        attenuationCoroutine = Attenuate(sound.length);
        StartCoroutine(attenuationCoroutine);
        //Lower volume of background music
        backgroundMusic.volume = backgroundMusicAttenuatedVolume;


        audioSource.Stop();
        audioSource.clip = sound;
        audioSource.Play();

    }

    public void PlayTurtleneckingLine()
    {
        PlaySound(turtleneckingLines[UnityEngine.Random.Range(0, turtleneckingLines.Count - 1)]);
    }

}
