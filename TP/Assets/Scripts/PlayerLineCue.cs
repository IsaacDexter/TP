using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLineCue : MonoBehaviour
{
    [SerializeField] AudioClip line;
    public void OnTriggerEnter(Collider other)
    {
        //if a player enters the trigger
        if (other.gameObject.name == "Player")
        {
            Player player = other.GetComponentInParent<Player>();
            player.lines.PlaySound(line);
        }
        Destroy(this.gameObject);
    }
}
