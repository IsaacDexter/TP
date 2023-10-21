using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStatManager : MonoBehaviour
{
    [Header("Comedy")]
    [SerializeField, Tooltip("Diameter of the sphincter, in cm")] private float sphincterDiameter = 0.25f;
    [SerializeField, Tooltip("Percentage multipler for the diameter of the sphincter")] private float sphincterDiameterMultiplier = 1.0f;
    [SerializeField, Tooltip("Length of the small intestine in cm")] private float smallIntestineLength = 700.0f;
    [SerializeField, Tooltip("Width of the small intestine in cm")] private float smallIntestineWidth = 2.5f;
    [SerializeField, Tooltip("Volume of colon in ml")] private float colonVolume = 200.0f;
    [SerializeField] private float logsPerMinute = 1.0f;
    [SerializeField] private float solidity = 0.7f;
    [SerializeField, Tooltip("Stinkiness")] private float stinkyness = 0.2f;

    [Header("Gameplay")]
    [SerializeField, Range(0.0f, 1.0f), Tooltip("Player's poop level, with 0 being empty, and 1 being turtlenecking")] private float poop;

    [SerializeField, Range(0.0f, 0.0001f), Tooltip("Poop increase per update")] public float poopIncreaseOverTime;

    /// <summary>Increase the players poop, to a maximum of 1</summary>
    /// <param name="amount">The amount to increase poop by</param>
    public void IncreasePoop(float amount)
    {
        this.poop = Mathf.Clamp01(poop + amount);
    }

    /// <summary>Reduces the players poop, to a minimum of 0</summary>
    /// <param name="amount">The amount to reduce poop by</param>
    public void DecreasePoop(float amount)
    {
        this.poop = Mathf.Clamp01(poop - amount);
    }

    public float GetPoop()
    {
        return poop;
    }

    public void SetPoop(float amount)
    {
        poop = amount;
    }

    // Update is called once per frame
    void Update()
    {
           
    }
}
