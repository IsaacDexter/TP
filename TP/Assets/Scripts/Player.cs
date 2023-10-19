using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public PlayerStatManager stats;
    public PlayerUIManager ui;
    // Start is called before the first frame update

    /// <summary>Scare the player, increasing the poop stat and updating the HUD</summary>
    /// <param name="amount">The amount to increase poop by</param>
    public void Scare(float amount)
    {
        stats.IncreasePoop(amount);
        ui.UpdateFace(stats.GetPoop());
        ui.ShowScaredFace();
    }

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
