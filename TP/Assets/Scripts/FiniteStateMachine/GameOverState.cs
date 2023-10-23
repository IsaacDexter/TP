using System.Collections;
using System.Collections.Generic;
using System.Net.Mail;
using Unity.VisualScripting.Antlr3.Runtime.Misc;
using UnityEditorInternal;
using UnityEngine;

public class GameOverState : State
{
    private float quitTimer = 5.0f;

    public GameOverState()
    {

    }

    public override void Enter(Player agent)
    {
        agent.GameOver();
    }
    public override void Exit(Player agent)
    {
        Application.Quit();
    }
    public override void Update(Player agent)
    {
        quitTimer -= Time.deltaTime;
    }
    public override State Check(Player agent)
    {
        if(quitTimer < 0)
        {
            Application.Quit();
        }
        return this;
    }
}
