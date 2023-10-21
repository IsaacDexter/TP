using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public PlayerStatManager stats;
    public PlayerUIManager ui;

    private int MashCounter = 20;
    private int MashLives = 2;


    /// <summary>Scare the player, increasing the poop stat and updating the HUD</summary>
    /// <param name="amount">The amount to increase poop by</param>
    public void Scare(float amount)
    {
        stats.IncreasePoop(amount);
        ui.UpdateFace(stats.GetPoop());
        ui.ShowScaredFace();
    }

    // Update is called once per frame
    void Update()
    {
        if (stats.GetPoop() < 1)  //if poop not maxed out, increase over time
        {
            stats.IncreasePoop(stats.poopIncreaseOverTime);
        }
        else if ((stats.GetPoop() >= 1f) && MashLives > 0) //if poop maxed out and we still have lives, do button mashing
        {
            ui.DisplayMessage("ABOUT TO POOP!!!! MASH F");

            if (Input.GetKeyUp(KeyCode.F) && MashCounter > 0)  //mash counter is how many times we need to press the button 
            {
                MashCounter--;
            }
            else if (MashCounter <= 0) //finished mashing
            {
                MashCounter = 20; //reset counter
                ui.ClearMessage(); 
                stats.DecreasePoop(MashLives * 0.25f); //decrease poop by amount based on lives. 50% first time, then 25% 
                MashLives--;
            }
        }
        else
        {
            Debug.Log("GAME OVER");
        }
    }

    void ButtonMash()
    {
        
    }
}
