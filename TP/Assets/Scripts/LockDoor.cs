using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LockDoor : MonoBehaviour
{
    [SerializeField] private List<Door> doorsToToggle;
    [SerializeField] private bool startLocked = true;

    public void Start()
    {
        foreach (Door door in doorsToToggle)
        {
            door.locked = startLocked;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "Player")
        {
            foreach (Door door in doorsToToggle)
            {
                door.locked = !startLocked;
            }
        }
    }

}
