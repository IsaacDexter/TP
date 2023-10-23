using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChaserActivator : MonoBehaviour
{
    [SerializeField] private GameObject chaser;
    // Start is called before the first frame update
    void Start()
    {
        chaser.SetActive(false);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "Player")
        {
            chaser.SetActive(true);
            GetComponent<Collider>().enabled = false;
        }
    }
}
