using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FlushableToilet : MonoBehaviour
{
    private string sceneName = "Hub";
    [SerializeField] private float TargetPosX = -1f, TargetPosY, TargetPosZ;

    [SerializeField] private AudioSource flushSound;
    [SerializeField] private GameObject barrier;

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            string currentSceneName = gameObject.scene.name;
            PlayerPrefs.SetInt(currentSceneName, 1);

            if(TargetPosX != -1f)
            {
                PlayerPrefs.SetFloat("pos_x", TargetPosX);
                PlayerPrefs.SetFloat("pos_y", TargetPosY);
                PlayerPrefs.SetFloat("pos_z", TargetPosZ);
            }

            flushSound.Play();
            StartCoroutine(WaitForSound());
            barrier.SetActive(true);
            GetComponent<Collider>().enabled = false;
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
