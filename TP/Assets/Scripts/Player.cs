using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
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
        if (SceneManager.GetActiveScene().name == "Hub")
        {
            if(PlayerPrefs.HasKey("pos_x"))
            {
                Vector3 newPos = new Vector3(PlayerPrefs.GetFloat("pos_x"), PlayerPrefs.GetFloat("pos_y"), PlayerPrefs.GetFloat("pos_z"));
                transform.position = newPos;
            }

        }
    }

    // Update is called once per frame
    void Update()
    {
        /*if (PlayerPrefs.GetInt("ToiletRoll") == 2)
        {
            ui.DisplayMessage("Throw!");
        }*/
    }
}
