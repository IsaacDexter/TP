using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChaserActivator : MonoBehaviour
{
    [SerializeField] private GameObject chaser;
    [SerializeField] private AudioSource backgroundMusic;
    private AudioSource chaseMusic;
    // Start is called before the first frame update
    void Start()
    {
        chaser.SetActive(false);
        chaseMusic = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "Player")
        {
            chaser.SetActive(true);
            GetComponent<Collider>().enabled = false;
        }
        backgroundMusic.Pause();
        chaseMusic.Play();
    }

    public void Cleanup()
    {
        Destroy(chaser);
        backgroundMusic.UnPause();
        chaseMusic.Stop();
        Destroy(this.gameObject);
    }
}
