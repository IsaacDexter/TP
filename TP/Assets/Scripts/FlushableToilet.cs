using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FlushableToilet : MonoBehaviour
{
    private string sceneName = "Hub";
    private AudioSource flushSound;

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            flushSound.Play();
            SceneManager.LoadScene(sceneName);
        }
    }
}
