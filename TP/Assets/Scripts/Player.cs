using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Player : MonoBehaviour
{
    [Header("Components")]
    public PlayerStatManager stats;
    public PlayerUIManager ui;
    public FirstPersonController controller;

    public StateMachine stateMachine;

    /// <summary>The amount of lives the player has to survive button mashing</summary>
    public int lives { get; set; } = 2;


    /// <summary>Scare the player, increasing the poop stat and updating the HUD</summary>
    /// <param name="amount">The amount to increase poop by</param>
    public void Scare(float amount)
    {
        stats.IncreasePoop(amount);
        ui.ShowScaredFace();
    }

    private void Start()
    {
        stateMachine = new StateMachine(this);
        stateMachine.SetState(new WalkState());
    }

    // Update is called once per frame
    void Update()
    {
        stateMachine.Update();
    }

    public void Blink()
    {
        ui.FadeThroughBlack();
    }

    public void GameOver()
    {
        ui.FadeToBlack();
    }
}
