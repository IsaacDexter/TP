using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Player : MonoBehaviour
{
    [Header("Mash")]
    [SerializeField, Range(0.0f, 1.0f), Tooltip("How much poop is required before mashing commences")] private float MashThreshold = 1.0f;
    private const int MashCounter_default = 20;
    private int MashCounter = MashCounter_default;
    [SerializeField, Range(0, 10), Tooltip("How many times mash can save you")] private int MashLives = 2;
    [SerializeField, Tooltip("The string to display when mashing")] string MashMessage = "ABOUT TO POOP!!!! MASH F";

    [Header("Components")]
    public PlayerStatManager stats;
    public PlayerUIManager ui;
    public FirstPersonController controller;


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
        //If poop is full
        if (stats.TickPoop() >= 1.0f)
        {
            if (MashLives > 0) //if poop maxed out and we still have lives, do button mashing
            {
                ButtonMash();
            }
            else
            {
                GameOver();
            }
        }
        else
        {
            //If the player started/stopped running
            bool running = controller.IsRunning();
            if (running != stats.isRunning)
            {
                stats.isRunning = running;
                ui.ToggleRunningFace();
            }
        }
        ui.UpdateFace(stats.GetPoop());
    }

    

    void GameOver()
    {

    }

    void ButtonMash()
    {
        ui.DisplayMessage(MashMessage);
        if (Input.GetKeyUp(KeyCode.F) && MashCounter > 0)  //mash counter is how many times we need to press the button 
        {
            MashCounter--;
        }
        else if (MashCounter <= 0) //finished mashing
        {
            MashCounter = MashCounter_default; //reset counter
            ui.ClearMessage(MashMessage);
            stats.DecreasePoop(MashLives * 0.25f); //decrease poop by amount based on lives. 50% first time, then 25% 
            MashLives--;
        }
    }
}
