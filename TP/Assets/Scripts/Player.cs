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

    private string throwMessage = "LMB to Throw TP!";
    private bool canThrow = false;
    [SerializeField] private GameObject TPThrowablePrefab;
    private Transform interactTransform;

    /// <summary>Scare the player, increasing the poop stat and updating the HUD</summary>
    public void Scare()
    {
        lines.PlayTurtleneckingLine();
    }

    private void Start()
    {
        PlayerPrefs.SetInt("Thrown", 0);
        interactTransform = transform.Find("Capsule/Interact");

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
        int toiletRolls = PlayerPrefs.GetInt("ToiletRoll");

        if(toiletRolls >= 3)
        {
            canThrow = true;
        }
        else if (toiletRolls <= 0)
        {
            canThrow = false;
            ui.ClearMessage(throwMessage);
        }

        if (canThrow && Physics.Raycast(transform.position, transform.forward, out var hit, Mathf.Infinity))
        {
            var obj = hit.collider.gameObject;

            if (obj.layer == 9)
            {
                ui.DisplayMessage(throwMessage);
                if (Input.GetMouseButtonUp(0))
                {
                    ThrowTP();
                }
            }
            else
            {
                ui.ClearMessage(throwMessage);
            }
        }
    }

    private void ThrowTP()
    {
        GameObject TP = Instantiate(TPThrowablePrefab, interactTransform.position, interactTransform.rotation);
        TP.GetComponent<Rigidbody>().AddForce(controller.playerCamera.transform.forward * 400 + new Vector3(0.0f, 200.0f, 0.0f));
        PlayerPrefs.SetInt("ToiletRoll", PlayerPrefs.GetInt("ToiletRoll") - 1);
        
        PlayerPrefs.SetInt("Thrown", PlayerPrefs.GetInt("Thrown") + 1);
    }
}
