using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FlushableToilet : MonoBehaviour
{
    private string sceneName = "Hub";
    [SerializeField] private AudioSource flushSound;

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            flushSound.Play();
            StartCoroutine(WaitForSound());
        }
    }

    private IEnumerator WaitForSound()
    {
        while (flushSound.isPlaying)
        {
            yield return null;
        }

        SceneManager.LoadScene(sceneName);
    }
}
