using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToggleObjects : MonoBehaviour
{
    [SerializeField] private List<GameObject> objectsToToggle;
    [SerializeField] private bool startActive = false;

    public void Start()
    {
        foreach (GameObject gameObject in objectsToToggle)
        {
            gameObject.SetActive(startActive);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "Player")
        {
            foreach (GameObject gameObject in objectsToToggle)
            {
                gameObject.SetActive(!gameObject.activeSelf);
            }
        }
    }

}
