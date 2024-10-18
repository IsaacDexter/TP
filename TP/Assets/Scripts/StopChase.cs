using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StopChase : MonoBehaviour
{
    [SerializeField] private ChaserActivator chaserActivator;
    public void OnTriggerEnter(Collider other)
    {
        chaserActivator.Cleanup();
        Destroy(gameObject);
    }
}
