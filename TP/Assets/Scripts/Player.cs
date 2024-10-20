using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Player : MonoBehaviour
{
    [Header("Components")]

    public PlayerUIManager ui;
    public FirstPersonController controller;
    public PlayerLineManager lines;

    /// <summary>Scare the player, increasing the poop stat and updating the HUD</summary>
    public void Scare()
    {
        lines.PlayTurtleneckingLine();
    }

    private void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {

    }
}
