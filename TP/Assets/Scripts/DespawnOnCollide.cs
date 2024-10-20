using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DespawnOnCollide : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        Object.Destroy(gameObject);
    }
}
