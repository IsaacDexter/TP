using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using Unity.VisualScripting.Antlr3.Runtime.Misc;
using UnityEngine;
using Random = UnityEngine.Random;

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
    [SerializeField, Range(0.0f, 1.0f), Tooltip("Poop increase per second")] public float poopIncrease;
   
    [HideInInspector] public bool isRunning = false;
    [SerializeField, Range(0.0f, 1.0f), Tooltip("Poop increase per second. Does not stack!")] public float runningPoopIncrease;

    

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

    /// <summary>Ticks up the poop according to the increase and delta time </summary>
    /// <returns>Whether or not the poop is full</returns>
    public float TickPoop()
    {
        IncreasePoop((isRunning ? runningPoopIncrease : poopIncrease) * Time.deltaTime);
        return poop;
    }

    public string GetStatIncreases()
    {
        //Sphincter Diameter
        float sDiam = Mathf.Round(Random.Range(0.0f, 1.0f) * 100.0f) * 0.01f;
        sphincterDiameter += sDiam;
        //Sphincter Diameter Multiplier
        float sDiamMul = Mathf.Round(Random.Range(0.0f, 5.0f) * 100.0f) * 0.1f;
        sphincterDiameterMultiplier += sDiamMul;
        //Small Intestine Length
        float sIntLen = Mathf.Round(Random.Range(0.0f, 100.0f) * 100.0f) * 0.1f;
        smallIntestineLength += sIntLen;
        //Small Intestine Width
        float sIntWid = Mathf.Round(Random.Range(0.0f, 5.0f) * 100.0f) * 0.1f;
        smallIntestineWidth += sIntWid;
        //Colon Volume
        float colVol = Mathf.Round(Random.Range(0.0f, 50.0f) * 100.0f) * 0.1f;
        colonVolume += colVol;
        //Logs Per Minute
        float lpm = Mathf.Round(Random.Range(0.0f, 1.0f) * 100.0f) * 0.1f;
        logsPerMinute += lpm;
        //Solidity
        float sol = Mathf.Round(Random.Range(0.0f, 1.0f) * 100.0f) * 0.1f;
        solidity += sol;
        //Stinkiness
        float stink = Mathf.Round(Random.Range(0.0f, 3.0f) * 100.0f) * 0.1f;
        stinkyness += stink;

        return (
            "+ " + sDiam + "cm Sphincter Diameter" +
            "\n+ " + sDiamMul + " Sphincter Diameter Multiplier" +
            "\n+ " + sIntLen + "cm Small Intestine Length" +
            "\n+ " + sIntWid + "cm Small Intestine Width" +
            "\n+ " + colVol + "ml Colon Volume" +
            "\n+ " + lpm + " Logs Per Minute" +
            "\n+ " + sol + " Solidity" +
            "\n+ " + stink + " Stinkiness"
            );
    }

    public string GetStatDisplay()
    {
        return (
            "Sphincter Diameter : " + sphincterDiameter + "cm" +
            "\nSphincter Diameter Multiplier : " + sphincterDiameterMultiplier +
            "\nSmall Intestine Length : " + smallIntestineLength + "cm" +
            "\nSmall Intestine Width : " + smallIntestineWidth + "cm" +
            "\nColon Volume : " + colonVolume + "ml" +
            "\nLogs Per Minute : " + logsPerMinute +
            "\nSolidity : " + solidity +
            "\n Stinkiness : " + stinkyness
            );
    }
}
