using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Collectible : MonoBehaviour
{
    [SerializeField] string CollectibleName;
    [SerializeField] AudioSource AudioSource;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if(!PlayerPrefs.HasKey(CollectibleName))
            {
                PlayerPrefs.SetInt(CollectibleName, 1);
            }
            else
            {
                PlayerPrefs.SetInt(CollectibleName, PlayerPrefs.GetInt(CollectibleName) + 1);
            }

            if (AudioSource)
            {
                AudioSource.Play();
                StartCoroutine(WaitForSound(AudioSource));
            }
            Object.Destroy(gameObject);
        }
    }
    private IEnumerator WaitForSound(AudioSource source)
    {
        while (source.isPlaying)
        {
            yield return null;
        }
    }
}
